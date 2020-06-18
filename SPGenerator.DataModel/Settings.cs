using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.DataModel
{
    public class Settings
    {
        public string prefixWhereParameter = "@w_";
        public string prefixInputParameter = "@p_";
        public string prefixInsertSp = "Proc_Insert_";
        public string prefixUpdateSp = "Proc_Update_";
        public string prefixDeleteSp = "Proc_Delete_";
        public string prefixGetSp = "Proc_Get";
        public string  errorHandling = "Yes";
    }
}
