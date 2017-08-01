using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using SimpleRDS.DataLayer;
using SimpleRDS.DataLayer.Base;
using SimpleRDS.DataLayer.Business;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Forms;
using SimpleRDS.Properties;

namespace SimpleRDS
{
    //application uses https://github.com/ServiceStack/ServiceStack.OrmLite
    public static class Program
    {
        public static IContainer Resolver { get; private set; }

        [STAThread]
        public static void Main()
        {
            var builder = new ContainerBuilder();

            FillResolver(builder);

            Resolver = builder.Build();

            FillDataBase(Resolver.Resolve<IContext>(), Resolver.Resolve<IPasswordHasher<User>>());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void FillResolver(ContainerBuilder resolver)
        {
            resolver.RegisterInstance(new DbContext(Settings.Default.ConnectionString))
                    .As<IContext>();

            resolver.RegisterType<PasswordHasher>().As<IPasswordHasher<User>>();
            resolver.RegisterType<AccountRepository>();
            resolver.RegisterType<SettingsRepository>();
            resolver.RegisterType<ClientsRepository>();
            resolver.RegisterType<InvoiceRepository>();
            resolver.RegisterType<SubscriptionRepository>();
            resolver.RegisterType<PlanRepository>();

        }

        private static async void FillDataBase(IContext context, IPasswordHasher<User> hasher)
        {
            context.UpdateDatabase();
            await context.SeedData(hasher);
        }
    }
}
