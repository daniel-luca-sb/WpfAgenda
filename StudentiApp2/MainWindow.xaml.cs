using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace StudentiApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentiEntities context = new StudentiEntities();
        CollectionViewSource studentiViewSource = null;

        public MainWindow()
        {
            InitializeComponent();
            studentiViewSource = (CollectionViewSource)(FindResource("studentiViewSource"));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Studenti.Load();
            studentiViewSource.Source = context.Studenti.Local;
        }
    }
}
