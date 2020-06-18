﻿using SPGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPGenerator.Core
{
   public abstract class SPFactory
    {
        public static BaseSPGenerator GetSpGeneratorObject(string nodeText)
        {
            BaseSPGenerator spGeneraror = null;
            switch (nodeText)
            {
                case Constants.insertTreeNodeText:
                    spGeneraror = new InsertSPGenerator();
                    break;
                case Constants.updateTreeNodeText:
                    spGeneraror = new UpdateSPGenerator();
                    break;
                case Constants.deleteTreeNodeText:
                    spGeneraror = new DeleteSPGenerator();
                    break;
                case Constants.getTreeNodeText:
                    spGeneraror = new GetSPGenerator();
                    break;
            }
            return spGeneraror;
        }
    }
}
