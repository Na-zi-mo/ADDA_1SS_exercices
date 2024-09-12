using System.Configuration;
using System.Data;
using System.Windows;

namespace test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-CA");

            //test.Properties.Settings.Default.langue = "en-US";
            //test.Properties.Settings.Default.Save();

            string langue = test.Properties.Settings.Default.langue;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);
        }
    }

}
