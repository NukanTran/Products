using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Data.Infrastructure
{
    public interface IContext
    {
        void SetLazyLoadingEnabled(bool value);
        void Commit();
    }
}
