using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2.ViewModels.Commands;
using TP2.Views;

namespace TP2.ViewModels
{
    public class LanguageDetectorViewModel : BaseViewModel
    {
        private string _text = string.Empty;
        private bool _enExecution;

        


        public LanguageDetectorViewModel()
        {

            DetectLanguageCmd = new AsyncCommand(DetectLanguage, (object? parameter) =>
            {
                return (!_enExecution && Text.Trim().Length > 0);
            });
        }
        private async Task DetectLanguage(object? obj)
        {
            try
            {
                _enExecution = true;

                //await Task.Delay(2000);
            }
            catch (Exception)
            {
            }
            finally
            {
                _enExecution = false;
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public AsyncCommand DetectLanguageCmd { get; set; }
    }
}
