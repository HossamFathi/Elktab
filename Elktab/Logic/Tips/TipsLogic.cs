using Elktab.Data.context;
using Elktab.DataAccess.Helper;
using Elktab.Logic.Tips.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Logic.Tips
{
    public class TipsLogic : ITips
    {
       private readonly  IRepository<ImportantTips> _Tips;
        public TipsLogic(IRepository<ImportantTips> Tips)
        {
            _Tips = Tips;
        }
        public ImportantTips Create(ImportantTips tips)
        {

            return _Tips.Add(tips);
        }
    }
}
