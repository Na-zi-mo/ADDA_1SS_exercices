﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static TP1.ViewModels.Delegates.ViewModelDelegates;

namespace TP1.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected MessageErreur _erreur;
        protected Question _question;
        protected OpenFileDialogInput _openFileDialog;
        public BaseViewModel(MessageErreur erreur, Question question, OpenFileDialogInput openFileDialog)
        {
            _erreur = erreur;
            _question = question;
            _openFileDialog = openFileDialog;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}