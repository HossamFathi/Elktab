using Elktab.Data.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Logic.Tips.Helper
{
   public interface ITips
    {
        ImportantTips Create(ImportantTips tips);
    }
}
