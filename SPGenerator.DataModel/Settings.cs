using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.DataModel
{
    public class Settings
    {
        public string prefixWhereParameter = "@";
        public string prefixInputParameter = "@";
        public string prefixInsertSp = "Insert";
        public string prefixUpdateSp = "Set";
        public string prefixDeleteSp = "Delete";
        public string prefixGetSp = "Get";
        public string  errorHandling = "No";
    }
}
