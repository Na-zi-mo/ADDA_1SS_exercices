using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.ViewModels.Delegates
{
    public class ViewModelDelegates
    {
        public delegate void MessageErreur(string message);
        public delegate bool Question(string message);
    }
}
