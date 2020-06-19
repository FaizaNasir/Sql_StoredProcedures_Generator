using SPGenerator.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
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

        public override void GenerateStatement(string tableName, StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
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
                if (colInf.Exclude || colInf.ColumnName == "CreatedDate" || colInf.ColumnName == "CreatedBy"
                    || colInf.ColumnName == "DeletedDate" || colInf.ColumnName == "DeletedBy" || colInf.ColumnName == pk.ColumnName || colInf.ColumnName == "Active")
                    continue;

                sb.Append(Environment.NewLine);
                if (colInf.ColumnName == "ModifiedDate")
                    sb.Append(Environment.NewLine + colInf.ColumnName + " = GetDate()");
                else if (colInf.ColumnName == "ModifiedBy")
                    sb.Append(Environment.NewLine + colInf.ColumnName + " = " + prefixInputParameter + "userId");
                else
                    sb.Append(WrapIfKeyWord(colInf.ColumnName) + " = " + prefixInputParameter + colInf.ColumnName[0].ToString().ToLower() + colInf.ColumnName.Substring(1));
                sb.Append(" ,");
            }
            ////Remove Commma from end
            sb[sb.Length - 1] = ' ';
            GenerateWherePrimaryKeyStatement(whereConditionFields, sb);
            sb.Append(Environment.NewLine + " SELECT " + inputPk + " AS Result; ");
            sb.Append(Environment.NewLine + " END ");
            GenerateBal(tableName, selectedFields);


        }
        protected override void GenerateInputParameters(List<DBTableColumnInfo> tableFields, StringBuilder sb)
        {
            var pk = tableFields.Where(c => c.IsPrimaryKey).FirstOrDefault();

            foreach (DBTableColumnInfo colInf in tableFields)
            {
                if (colInf.Exclude)
                    continue;
                if (colInf.ColumnName == "CreatedDate" || colInf.ColumnName == "Active" || colInf.ColumnName == "CreatedBy" || colInf.ColumnName == "DeletedDate" || colInf.ColumnName == "DeletedBy" || colInf.ColumnName == "ModifiedBy" || colInf.ColumnName == "ModifiedDate")
                    continue;
                sb.Append(Environment.NewLine + prefixInputParameter + colInf.ColumnName[0].ToString().ToLower() + colInf.ColumnName.Substring(1));
                sb.Append(" " + colInf.DataType);
                if (colInf.CharacterMaximumLength > 0)
                {
                    sb.Append("(" + colInf.CharacterMaximumLength.ToString() + ")");
                }
                sb.Append(" ,");
            }
            sb.Append(Environment.NewLine + prefixInputParameter + "userId int");

        }

        public override void GenerateBal(string tableName, List<DBTableColumnInfo> selectedFields)
        {
            var pk = selectedFields.Where(c => c.IsPrimaryKey).FirstOrDefault();

            StringBuilder code = new StringBuilder();
            code.Append(Environment.NewLine);
            code.Append("#region " + tableName);
            code.Append(Environment.NewLine);
            code.Append(Environment.NewLine);
            code.Append("public static Nullable<int>");
            code.Append("Set");
            code.Append(tableName);
            code.Append("(");
            foreach (DBTableColumnInfo colInf in selectedFields)
            {
                if (colInf.Exclude || colInf.ColumnName == "CreatedDate" || colInf.ColumnName == "CreatedBy" || colInf.ColumnName == "ModifiedBy" || colInf.ColumnName == "ModifiedDate"
                         || colInf.ColumnName == "DeletedDate" || colInf.ColumnName == "DeletedBy" || colInf.ColumnName == "Active")
                    continue;

                else
                    code.Append(" " + base.GetTypeName(colInf.DataType) + " " + colInf.ColumnName[0].ToString().ToLower() + colInf.ColumnName.Substring(1));
                code.Append(",");
            }
            code.Append(base.GetTypeName(pk.DataType) + " " + "userId");
           code.Append(")");
            code.Append(Environment.NewLine + "{" + Environment.NewLine + " using (EntitiesConnecter e = new EntitiesConnecter()) ");
            code.Append(Environment.NewLine + "{" + Environment.NewLine + " return ");
            code.Append("e.Set" + tableName + "(");
            foreach (DBTableColumnInfo colInf in selectedFields)
            {
                if (colInf.Exclude || colInf.ColumnName == "CreatedDate" || colInf.ColumnName == "CreatedBy" || colInf.ColumnName == "ModifiedBy" || colInf.ColumnName == "ModifiedDate"
                       || colInf.ColumnName == "DeletedDate" || colInf.ColumnName == "DeletedBy"  || colInf.ColumnName == "Active")
                    continue;

                code.Append(" " + colInf.ColumnName[0].ToString().ToLower() + colInf.ColumnName.Substring(1));
                code.Append(",");
            }
            code.Append(" userId");
            code.Append(")");
            code.Append(".FirstOrDefault();" + Environment.NewLine + "}" + Environment.NewLine + "}" + Environment.NewLine);
            code.Append(Environment.NewLine);

            File.AppendAllText("BalGenerator.txt", code.ToString());


        }
    }
}
