
using SPGenerator.DataModel;
using System;
using System.Collections.Generic;
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

        protected override void GenerateStatement(string tableName, StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            var schema = "";
            whereConditionFields = selectedFields;
            sb.Append(Environment.NewLine + "\tSELECT " );

            foreach (DBTableColumnInfo colInf in selectedFields)
            {
                if (colInf.Exclude)
                    continue;
                sb.Append(WrapIfKeyWord(colInf.ColumnName));
                sb.Append(",\n");

            }

            sb.Append(Environment.NewLine + "\tFROM " + schema + WrapIfKeyWord(tableName) + " ");
            GenerateWherePrimaryKeyStatement(whereConditionFields, sb);
        }

        protected override void GenerateInputParameters(List<DBTableColumnInfo> tableFields, StringBuilder sb)
        {
            var pk = tableFields.Where(c => c.IsPrimaryKey).FirstOrDefault();

            sb.Append(Environment.NewLine + prefixInputParameter + pk.ColumnName);
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
