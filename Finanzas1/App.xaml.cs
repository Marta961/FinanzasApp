using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Finanzas1.Data;
using Finanzas1.Services;
using Finanzas1.ViewModels;

namespace Finanzas1
{
    public partial class App : Application
    {
        public static MainViewModel? MainVM { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connStr = config.GetConnectionString("FinanceDb");

            var options = new DbContextOptionsBuilder<FinanceContext>()
                .UseMySql(connStr, ServerVersion.AutoDetect(connStr))
                .Options;

            var db = new FinanceContext(options);
            db.Database.EnsureCreated(); // “basic” approach (migrations optional)

            var service = new TransactionService(db);
            MainVM = new MainViewModel(service);

            var window = new MainWindow();
            window.Show();

            _ = MainVM.LoadAsync();
        }
    }
}

