using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.BaseTypes
{
    public interface ILoginForm
    {
        bool IsLoggedIn { get; }
    }
}
