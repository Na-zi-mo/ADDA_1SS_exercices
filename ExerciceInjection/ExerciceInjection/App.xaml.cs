using System.Threading;
using System.Windows;

namespace ExerciceInjection
{
    public partial class App : Application
    {
        public App()
        {
            string langue = ExerciceInjection.Properties.Settings.Default.langue;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);
        }
    }
}
