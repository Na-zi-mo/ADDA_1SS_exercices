using Autofac.Configuration;
using Autofac;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using TP4.DataService;

namespace TP4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string langue = TP4.Properties.Settings.Default.langue;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigurerAutofac();
            EffectuerMigrationBd();
        }

        private void ConfigurerAutofac()
        {
            var config = new ConfigurationBuilder();
            // https://autofac.readthedocs.io/en/latest/configuration/xml.html
            config.AddJsonFile("di.json");

            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            FournisseurDI.Container = builder.Build();
        }

        private void EffectuerMigrationBd()
        {
            MeteoDbContext context = FournisseurDI.Container.Resolve<MeteoDbContext>();
            context.Database.Migrate();
        }
    }

}
