using TwitterAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwitterAdmin.Views
{
    /// <summary>
    /// Logique d'interaction pour ForumWindow.xaml
    /// </summary>
    public partial class ForumWindow : Window
    {
        public ForumWindow()
        {
            InitializeComponent();
            DataContext = new ForumViewModel();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
