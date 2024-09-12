using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test.Models;
using test.ViewModels.Commands;
using static test.ViewModels.Delegates.ViewModelDelegates;

namespace test.ViewModels
{
    public class AccueilViewModel : BaseViewModel
    {
        public AccueilViewModel(MessageErreur erreur, Question question) : base(erreur, question) 
        {
            
        }
    }
}
