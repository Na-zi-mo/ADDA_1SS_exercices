﻿using Autofac;
using System.Threading;
using System.Windows;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace ExerciceMockEtTdd
{
    public partial class App : Application
    {
        public App()
        {
            string langue = ExerciceMockEtTdd.Properties.Settings.Default.langue;
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
