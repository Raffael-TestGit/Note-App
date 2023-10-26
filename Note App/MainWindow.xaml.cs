using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Note_App.Context;
using Note_App.Entities;
using Note_App.Events;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using static Azure.Core.HttpHeader;
using Path = System.IO.Path;

namespace Note_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NoteEntity note = new();
        DataContext context = new();
        public MainWindow()
        {
            InitializeComponent();
            context.Database.Migrate();          
        }

        private void SaveEvent(object? sender, EventArgs e)
        {
            
            try
            {                 
                note.Name = Interaction.InputBox("Unter welchem Namen soll deine Notiz abgespeichert werden?");
                note.Content = noteContent.Text;
                context.Notes.Add(note);
                context.SaveChanges();
                MessageBox.Show("Notiz erfolgreich gespeichert!");
            }
            catch
            {
                MessageBox.Show("Name bereits vergeben!");
            }
        }
        private void LookEvent(object? sender, EventArgs e)
        {
            Notes notes = new();
            try
            {
                var noteNames = context.Notes.Select(n => n.Name).ToList();

                foreach (var noteName in noteNames)
                {
                    notes.list_Box.Items.Add(noteName);
                }
                notes.ShowDialog();
                string selectedName = notes.list_Box.SelectedItem as string; // Annahme: Du hast den ausgewählten Namen aus der ListBox extrahiert

                if (selectedName != null)
                {
                    var note = context.Notes.FirstOrDefault(n => n.Name == selectedName);

                    if (note != null)
                    {  
                        noteContent.Text = note.Content;
                        notes.list_Box.Items.Clear();
                    }
                    else
                    {
                        // Behandele den Fall, in dem keine Übereinstimmung für den ausgewählten Namen gefunden wurde.
                    }
                }
            }
            catch
            {

            }            
        }

        private void DeleteEvent(object? sender, EventArgs e)
        {

            try
            {
                note.Name = Interaction.InputBox("Welche Notiz soll gelöscht werden?");
                context.Notes.Remove(note);
                context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Diese Notiz existiert nicht!");
            }
            
        }

        private void SaveClick(object sender, EventArgs e)
        {
            EventClass.HasBeenPushed += SaveEvent;
            EventClass.RaiseEvent(e);
            EventClass.HasBeenPushed -= SaveEvent;
        }

        private void WatchClick(object sender, RoutedEventArgs e)
        {
            EventClass.HasBeenPushed += LookEvent;
            EventClass.RaiseEvent(e);
            EventClass.HasBeenPushed -= LookEvent;
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            EventClass.HasBeenPushed += DeleteEvent;
            EventClass.RaiseEvent(e);
            EventClass.HasBeenPushed -= DeleteEvent;
        }

    }
}
