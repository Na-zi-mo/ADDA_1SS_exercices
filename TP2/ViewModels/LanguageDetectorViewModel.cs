using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2.ViewModels.Commands;
using TP2.Views;
using TP2.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TP2.ViewModels
{
    public class LanguageDetectorViewModel : BaseViewModel
    {
        private string _text = string.Empty;
        private bool _enExecution;
        private ObservableCollection<Detection> _detections;
        private Detection _currentDetection;


        public LanguageDetectorViewModel()
        {
            Detections = new ObservableCollection<Detection>(); 
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

                ApiClient client = new ApiClient("https://ws.detectlanguage.com/0.2");

                client.SetHttpRequestHeader("Authorization", "Bearer " + "7edd3ef1b07ec37d12032e2045b14391");

                string json = await client.RequeteGetAsync($"/detect?q={Text}");

                List<Detection> detections = new List<Detection>();

                LanguageDetector languageDetector = JsonConvert.DeserializeObject<LanguageDetector>(json) ?? new LanguageDetector();

                Detections = new ObservableCollection<Detection>(languageDetector.data.detections);

                CurrentDetection = Detections[0];

                client.Dispose();

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
        public ObservableCollection<Detection> Detections
        {
            get { return _detections; }
            set
            {
                _detections = value;
                OnPropertyChanged();
            }
        }
        public Detection CurrentDetection
        {
            get { return _currentDetection; }
            set
            {
                if (value != null)
                {
                    _currentDetection = value;
                    OnPropertyChanged();
                }

            }
        }


        public AsyncCommand DetectLanguageCmd { get; set; }
    }
}
