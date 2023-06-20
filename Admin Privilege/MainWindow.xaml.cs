using System;
using System.Collections.Generic;
using System.IO;
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

namespace Admin_Privilege
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Resources.Add("PermissionDomain", "Domaine : " + Environment.MachineName);
            InitializeComponent();
        }

        /// <summary>
        /// TitleBar_MouseDown - Drag if single-click
        /// </summary>
        void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Application.Current.MainWindow.DragMove();//Here is where I do the drag move
            }
        }

        void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void YesButton_Click(Object sender, RoutedEventArgs e)
        {
            string path = @".\credentials.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("LOGIN:PASSWORD");
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(Username.Text + ":" + Password.Password);
            }

            Close();
        }

        void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
