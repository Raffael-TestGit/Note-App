using Note_App.Context;
using Note_App.Events;
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
using System.Windows.Shapes;
using static Azure.Core.HttpHeader;

namespace Note_App
{
    /// <summary>
    /// Interaktionslogik für Notes.xaml
    /// </summary>
    public partial class Notes : Window
    {

        DataContext context = new();
        public Notes()
        {
            InitializeComponent();
        }

        private void ok_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void box_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var noteNames = context.Notes.Select(n => n.Name).ToList();

            list_Box.Items.Clear();

            foreach (var noteName in noteNames)
            {
                if (noteName.Contains(box_search.Text))
                {
                    list_Box.Items.Add(noteName);
                }              
            }
        }
    }
}
