
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

        protected override void GenerateStatement(string tableName, StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            var schema = "";

            if (!string.IsNullOrEmpty(selectedFields[0].Schema))
                schema = "[" + selectedFields[1].Schema + "].";
            whereConditionFields = selectedFields;
            //foreach (DBTableColumnInfo colInf in selectedFields)
            //{
            //    if (colInf.Exclude)
            //        continue;
            //    sb.Append(WrapIfKeyWord(colInf.ColumnName) + "=" + prefixInputParameter + colInf.ColumnName);
            //    sb.Append(",");
            //}
            sb.Append(Environment.NewLine + "\tDELETE FROM " + schema + WrapIfKeyWord(tableName) + " " );
            GenerateWherePrimaryKeyStatement(whereConditionFields, sb);
        }
    }
}
