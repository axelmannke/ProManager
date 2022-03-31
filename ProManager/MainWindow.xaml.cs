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
using BusinessLogic;

namespace ProManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectViewModel pvm = new ProjectViewModel();
        public Project SelectedProject;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            pvm.LoadData();

            this.DataContext = pvm;
        }

        private void tvProjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            

        }

        /// <summary>
        /// Berechnung der Gesmatkosten der Projekte 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Project p in pvm.Projects)
            {
                p.CalcTotalProfit();
            }
        }

        private void tvProjects_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(tvProjects.SelectedItem != null)
            {
                SelectedProject = (Project)tvProjects.SelectedItem;

                SelectedProject.GetStuff();

                lbStaff.ItemsSource = null;
                lbStaff.ItemsSource = SelectedProject.ProjectStaff;
            }
        }
    }
}
