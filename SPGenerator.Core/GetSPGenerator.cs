
using SPGenerator.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SPGenerator.Core
{
    class GetSPGenerator : BaseSPGenerator
    {
        protected override string GetSpName(string tableName)
        {
            return prefixGetSp + tableName;
        }

        public override void GenerateStatement(string tableName, StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            var schema = "";
            whereConditionFields = selectedFields;
            sb.Append(Environment.NewLine + "\tSELECT ");

            foreach (DBTableColumnInfo colInf in selectedFields)
            {
                if (colInf.Exclude)
                    continue;
                sb.Append("\n");
                sb.Append(WrapIfKeyWord(colInf.ColumnName));
                sb.Append(" ,");

            }
            sb[sb.Length - 1] = ' ';
            //Remove Commma from end
            sb[sb.Length - 1] = ' ';
            sb.Append(Environment.NewLine + "\tFROM " + schema + WrapIfKeyWord(tableName) + " ");
            GenerateWherePrimaryKeyStatement(whereConditionFields, sb);
            GenerateBal(tableName, selectedFields);
        }

        protected override void GenerateInputParameters(List<DBTableColumnInfo> tableFields, StringBuilder sb)
        {
            var pk = tableFields.Where(c => c.IsPrimaryKey).FirstOrDefault();

            sb.Append(Environment.NewLine + prefixInputParameter + pk.ColumnName[0].ToString().ToLower() + pk.ColumnName.Substring(1));
            sb.Append(" " + pk.DataType);
            if (pk.CharacterMaximumLength > 0)
            {
                sb.Append("(" + pk.CharacterMaximumLength.ToString() + ")");
            }
            sb.Append(" ,");

            //Remove Commma from end
            sb[sb.Length - 1] = ' ';

        }

        public override void GenerateBal(string tableName, List<DBTableColumnInfo> selectedFields)
        {
            var pk = selectedFields.Where(c => c.IsPrimaryKey).FirstOrDefault();

            StringBuilder code = new StringBuilder();
            code.Append(Environment.NewLine);
            code.Append("public static List<Get");
            code.Append(tableName);
            code.Append("_Result> Get");
            code.Append(tableName);
            code.Append("(");
            code.Append(base.GetTypeName(pk.DataType) + " " + pk.ColumnName[0].ToString().ToLower() + pk.ColumnName.Substring(1));
            code.Append(")");
            code.Append(Environment.NewLine + "{" + Environment.NewLine + " using (EntitiesConnecter e = new EntitiesConnecter()) ");
            code.Append(Environment.NewLine + "{" + Environment.NewLine + " return ");
            code.Append("e.Get" + tableName + "(");
            code.Append(pk.ColumnName[0].ToString().ToLower() + pk.ColumnName.Substring(1));
            code.Append(")");
            code.Append(".ToList();" + Environment.NewLine + "}" + Environment.NewLine + "}" + Environment.NewLine);
            code.Append(Environment.NewLine);
            code.Append("#endregion ");
            code.Append(Environment.NewLine);
            File.AppendAllText("BalGenerator.txt", code.ToString());
           
        }
    }
}
