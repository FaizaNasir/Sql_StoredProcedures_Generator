﻿
using SPGenerator.DataModel;
using System;
using System.Collections.Generic;
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
            sb.Append(Environment.NewLine + "\tDELETE FROM " + schema + WrapIfKeyWord(tableName) + " ");
            GenerateWherePrimaryKeyStatement(whereConditionFields, sb);
            sb.Append(";");
            sb.Append(Environment.NewLine + Environment.NewLine + " SELECT 1 as Result");
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
                sb.Append(",");
            
            //Remove Commma from end
            sb[sb.Length - 1] = ' ';

        }
    }
}
