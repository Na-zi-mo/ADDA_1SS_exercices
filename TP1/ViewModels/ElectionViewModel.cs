using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TP1.ViewModels.Delegates.ViewModelDelegates;

namespace TP1.ViewModels
{
    public class ElectionViewModel : BaseViewModel
    {

        public ElectionViewModel(MessageErreur erreur, Question question) : base(erreur, question) 
        {
            
        }
    }
}
