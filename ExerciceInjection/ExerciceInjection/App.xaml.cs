using Autofac.Configuration;
using Autofac;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Windows;
using ExerciceInjection.ViewModels.Interfaces;
using ExerciceInjection.ViewModels;
using ExerciceInjection.Views;
using ExerciceInjection.Models;

namespace ExerciceInjection
{
    public partial class App : Application
    {
        public App()
        {
            string langue = ExerciceInjection.Properties.Settings.Default.langue;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var config = new ConfigurationBuilder();
            // https://autofac.readthedocs.io/en/latest/configuration/xml.html
            config.AddJsonFile("di.json");

            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            FournisseurDI.Container = builder.Build();
        }

    }
}
