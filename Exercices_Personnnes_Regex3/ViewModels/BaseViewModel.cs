using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static test.ViewModels.Delegates.ViewModelDelegates;

namespace test.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected MessageErreur _erreur;
        protected Question _question;
        public BaseViewModel(MessageErreur erreur, Question question)
        {
            _erreur = erreur;
            _question = question;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
