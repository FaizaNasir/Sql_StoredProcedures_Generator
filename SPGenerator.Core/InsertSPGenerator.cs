using SPGenerator.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPGenerator.Core
{
    public class InsertSPGenerator : BaseSPGenerator
    {

        protected override string GetSpName(string tableName)
        {
            return prefixInsertSp + tableName;
        }

        public override void GenerateStatement(string tableName, StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            var pk = selectedFields.Where(c => c.IsPrimaryKey).FirstOrDefault();
            var inputPk = prefixInputParameter + pk.ColumnName[0].ToString().ToLower() + pk.ColumnName.Substring(1);
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            sb.Append(Environment.NewLine + "\tIF " + inputPk + " IS NULL");
            sb.Append(Environment.NewLine + " BEGIN ");
            foreach (DBTableColumnInfo colInf in selectedFields)
            {
                if (colInf.Exclude || colInf.ColumnName == "ModifiedDate" || colInf.ColumnName == "ModifiedBy" || colInf.ColumnName == "CreatedDate"
                    || colInf.ColumnName == "DeletedDate" || colInf.ColumnName == "DeletedBy" || colInf.ColumnName == pk.ColumnName || colInf.ColumnName == "Active")
                    continue;
                if (colInf.ColumnName == "CreatedBy")
                {
                    sbFields.Append(Environment.NewLine + colInf.ColumnName + ",");
                    sbValues.Append(Environment.NewLine + prefixInputParameter + "userId" + "," );
                }
                else
                {
                    sbValues.Append("\n" + prefixInputParameter + colInf.ColumnName[0].ToString().ToLower() + colInf.ColumnName.Substring(1) + ",");
                    sbFields.Append("\n" + WrapIfKeyWord(colInf.ColumnName) + ",");
                }
            }
            sb[sb.Length - 1] = ' ';
            sb.Append(Environment.NewLine + "\t INSERT INTO " + WrapIfKeyWord(tableName) + " ( " + sbFields.ToString().TrimEnd(',') + " ) ");
            sb.Append(Environment.NewLine + "\t VALUES(" + sbValues.ToString().TrimEnd(',') + " );");
            sb.Append(Environment.NewLine + " SET " + inputPk + " = SCOPE_IDENTITY(); ");
            sb.Append(Environment.NewLine + " END ");

        }
        protected override void GenerateInputParameters(List<DBTableColumnInfo> tableFields, StringBuilder sb)
        {


        }
    }
}
