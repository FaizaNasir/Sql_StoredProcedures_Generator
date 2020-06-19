using SPGenerator.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPGenerator.Core
{
    class UpdateSPGenerator : BaseSPGenerator
    {
        protected override string GetSpName(string tableName)
        {
            return prefixUpdateSp + tableName;
        }

        public override void GenerateStatement(string tableName,StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            var schema = "";
            whereConditionFields = selectedFields;
            var pk = whereConditionFields.Where(c => c.IsPrimaryKey).FirstOrDefault();
            var inputPk = prefixInputParameter + pk.ColumnName[0].ToString().ToLower() + pk.ColumnName.Substring(1);

            InsertSPGenerator insert = new InsertSPGenerator();
            insert.GenerateStatement(tableName, sb, selectedFields, whereConditionFields);

            sb.Append(Environment.NewLine + "\tELSE ");
            

                if (!string.IsNullOrEmpty(selectedFields[0].Schema))
                    schema = "[" + selectedFields[0].Schema + "].";
            sb.Append(Environment.NewLine + " BEGIN ");

            sb.Append(Environment.NewLine + "\tUPDATE " + schema + WrapIfKeyWord(tableName) + " SET ");

                foreach (DBTableColumnInfo colInf in selectedFields)
                {
                    if (colInf.Exclude)
                        continue;
                if (colInf.ColumnName == pk.ColumnName)
                    continue;

                sb.Append(Environment.NewLine );
                sb.Append(WrapIfKeyWord(colInf.ColumnName) + " = " + prefixInputParameter + colInf.ColumnName[0].ToString().ToLower()+ colInf.ColumnName.Substring(1));
                    sb.Append(",");
                }
                ////Remove Commma from end
                sb[sb.Length - 1] = ' '; 
            GenerateWherePrimaryKeyStatement(whereConditionFields, sb);
            sb.Append(Environment.NewLine + " SELECT " + inputPk + " AS Result; ");

            sb.Append(Environment.NewLine + " END ");

        }
        protected override void GenerateInputParameters(List<DBTableColumnInfo> tableFields, StringBuilder sb)
        {
            var pk = tableFields.Where(c => c.IsPrimaryKey).FirstOrDefault();

            foreach (DBTableColumnInfo colInf in tableFields)
            {
                if (colInf.Exclude)
                    continue;
                sb.Append(Environment.NewLine + prefixInputParameter + colInf.ColumnName[0].ToString().ToLower() + colInf.ColumnName.Substring(1));
                sb.Append(" " + colInf.DataType);
                if (colInf.CharacterMaximumLength > 0)
                {
                    sb.Append("(" + colInf.CharacterMaximumLength.ToString() + ")");
                }
                sb.Append(",");
            }
            //Remove Commma from end
            sb[sb.Length - 1] = ' ';

        }
    }
}
