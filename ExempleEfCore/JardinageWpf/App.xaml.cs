using Autofac.Configuration;
using Autofac;
using Microsoft.Extensions.Configuration;
using System.Windows;
using JardinageWpf.DataService;
using Microsoft.EntityFrameworkCore;

namespace JardinageWpf
{
    public partial class App : Application
    {
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
            JardinageDbContext context = FournisseurDI.Container.Resolve<JardinageDbContext>();
            context.Database.Migrate();
        }
    }
}

