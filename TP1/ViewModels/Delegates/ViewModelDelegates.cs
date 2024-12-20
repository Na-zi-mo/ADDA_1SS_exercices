﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.ViewModels.Delegates
{
    public class ViewModelDelegates
    {
        public delegate void MessageErreur(string message);
        public delegate string OpenFileDialogInput();
        public delegate void OpenConfigurationWindow();
        public delegate void CloseConfigurationWIndow();
        public delegate void ShowInformationDialog(string message);
    }
}
