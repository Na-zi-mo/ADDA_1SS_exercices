using System.Configuration;
using System.Data;
using System.Windows;

namespace TP1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-CA");

            TP1.Properties.Settings.Default.langue = "fr-CA";
            TP1.Properties.Settings.Default.Save();

            string langue = TP1.Properties.Settings.Default.langue;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);
        }
    }

}
