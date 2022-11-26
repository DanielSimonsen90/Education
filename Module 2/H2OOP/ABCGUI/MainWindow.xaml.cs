using ABCLibrary;
using ABCLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using DanhoLibrary;

namespace ABCGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public Trainer Trainer { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            Loaded += delegate
            {
                StartPage Introduction = new StartPage();
                while (Introduction.DialogResult is null || !(bool)Introduction.DialogResult)
                    try { Introduction.ShowDialog(); }
                    catch { Close(); }
                Trainer = Introduction.Trainer;
                Slot1.member = Trainer.GetPokémon(0);
            };
        }

        private void Adventure_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Trainer.AddEncounter(new List<ITeamMember>(Pokémon.PokémonAvailable) { new Egg() }.GetRandomItem());
                MessageBox.Show($"You ran outside and caught a {Trainer.LastAdded.Name}!");
            }
            catch (TooManyTeamMembersException) { MessageBox.Show("You already have 6 Pokémon in your team!"); }
        }
        private void UpdateHeldItem_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Release_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
