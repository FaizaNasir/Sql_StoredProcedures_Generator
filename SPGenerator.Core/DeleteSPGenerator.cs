
using SPGenerator.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SPGenerator.Core
{
    class DeleteSPGenerator : BaseSPGenerator
    {
        protected override string GetSpName(string tableName)
        {
            return prefixDeleteSp + tableName;
        }

        public override void GenerateStatement(string tableName, StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            var schema = "";
            whereConditionFields = selectedFields;
            sb.Append(Environment.NewLine + "\tUPDATE " + schema + WrapIfKeyWord(tableName)); 
            sb.Append(Environment.NewLine + "SET ");
            sb.Append(Environment.NewLine + "Active = 0, ");
            sb.Append(Environment.NewLine + "DeletedBy = " + prefixInputParameter + "deletedBy, ");
            sb.Append(Environment.NewLine + "DeletedDate = GETDATE() " + Environment.NewLine);
            GenerateWherePrimaryKeyStatement(whereConditionFields, sb);
            sb.Append(";");
            sb.Append(Environment.NewLine + Environment.NewLine + " SELECT 1 as Result");
            GenerateBal(tableName, selectedFields);
        }
        protected override void GenerateInputParameters(List<DBTableColumnInfo> tableFields, StringBuilder sb)
        {
            var pk = tableFields.Where(c => c.IsPrimaryKey).FirstOrDefault();
          
                sb.Append(Environment.NewLine + prefixInputParameter + pk.ColumnName[0].ToString().ToLower() + pk.ColumnName.Substring(1));
                sb.Append(" " + pk.DataType);
                sb.Append(Environment.NewLine +" ," +prefixInputParameter + "deletedBy");
                sb.Append(" " + pk.DataType);
                if (pk.CharacterMaximumLength > 0)
                {
                    sb.Append("(" + pk.CharacterMaximumLength.ToString() + ")");
                }
                sb.Append(",");
            
            //Remove Commma from end
            sb[sb.Length - 1] = ' ';

        }
        public override void GenerateBal(string tableName, List<DBTableColumnInfo> selectedFields)
        {
            var pk = selectedFields.Where(c => c.IsPrimaryKey).FirstOrDefault();

            StringBuilder code = new StringBuilder();
            code.Append(Environment.NewLine);
            code.Append("public static Nullable<int>");
            code.Append("Delete");
            code.Append(tableName);
            code.Append("(");
            code.Append(base.GetTypeName(pk.DataType) + " " + pk.ColumnName[0].ToString().ToLower() + pk.ColumnName.Substring(1));
            code.Append(" ," + base.GetTypeName(pk.DataType) + " " + "deletedBy");
            code.Append(")");
            code.Append(Environment.NewLine + "{" + Environment.NewLine + " using (EntitiesConnecter e = new EntitiesConnecter())" );
            code.Append(Environment.NewLine + "{" + Environment.NewLine + " return ");
            code.Append("e.Delete" + tableName + "(");
            code.Append(pk.ColumnName[0].ToString().ToLower() + pk.ColumnName.Substring(1));
            code.Append(" ,"  + " deletedBy");
            code.Append(")");
            code.Append(".FirstOrDefault();" + Environment.NewLine + "}" + Environment.NewLine + "}" + Environment.NewLine);
            code.Append(Environment.NewLine);

            File.AppendAllText("BalGenerator.txt", code.ToString());


        }
    }
}
