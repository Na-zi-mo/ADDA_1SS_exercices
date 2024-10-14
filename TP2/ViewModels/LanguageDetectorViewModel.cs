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

namespace TP2.ViewModels
{
    public class LanguageDetectorViewModel : BaseViewModel
    {
        private string _text = string.Empty;

        private string _language;

        public string Language
        {
            get { return _language; }
            set {
                _language = value;
                OnPropertyChanged();
            }
        }

        private double _confidence;

        public double Confidence
        {
            get { return _confidence; }
            set { 
                _confidence = value; 
                OnPropertyChanged();  
            }
        }

        private bool _isReliable;

        public bool IsReliable
        {
            get { return _isReliable; }
            set {
                _isReliable = value;
                OnPropertyChanged();
            }
        }
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

                ApiClient client = new ApiClient("https://ws.detectlanguage.com/0.2");

                client.SetHttpRequestHeader("Authorization", "Bearer " + "7edd3ef1b07ec37d12032e2045b14391");

                string json = await client.RequeteGetAsync($"/detect?q={Text}");

                List<Detection> detections = new List<Detection>();

                LanguageDetector languageDetector = JsonConvert.DeserializeObject<LanguageDetector>(json) ?? new LanguageDetector();

                MessageBox.Show($"{languageDetector.data.detections.Count}");

                Language = languageDetector.data.detections[0].language;

                Confidence = languageDetector.data.detections[0].confidence;

                IsReliable = languageDetector.data.detections[0].isReliable;

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

        public AsyncCommand DetectLanguageCmd { get; set; }
    }
}
