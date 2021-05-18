using TwitterAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TwitterAdmin.Views
{
    /// <summary>
    /// Logique d'interaction pour ThematiquesWindow.xaml
    /// </summary>
    public partial class ThematiquesWindow: Window
    {
        public ThematiquesWindow()
        {
            InitializeComponent();
            DataContext = new ThematiqueViewModel();
        }

      
    }
}
