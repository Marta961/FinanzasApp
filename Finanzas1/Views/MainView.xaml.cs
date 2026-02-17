using System.Windows.Controls;

namespace Finanzas1.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = App.MainVM;
        }
    }
}
