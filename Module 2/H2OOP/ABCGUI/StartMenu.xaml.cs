using ABCLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ABCGUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        public Trainer Trainer { get; private set; }
        public Pokémon SelectedStarter;
        private RadioButton[] StarterButtons;
        public StartPage()
        {
            InitializeComponent();
            Loaded += SetStarters;
        }

        private void SetStarters(object sender, RoutedEventArgs e)
        {
            StarterButtons = new RadioButton[] { StarterOne, StarterTwo, StarterThree };
            for (int i = 0; i < StarterButtons.Length; i++)
                StarterButtons[i].Content = Pokémon.PokémonAvailable[i];
        }

        private void TextBox_Click(object sender, RoutedEventArgs e)
        {
            TextBox txtblckSender = (TextBox)sender;
            if (txtblckSender.Text.Contains("Enter"))
                txtblckSender.Text = "";
        }
        private void StarterButton_Click(object sender, RoutedEventArgs e) =>
            SelectedStarter = Pokémon.PokémonAvailable
            .Find(pkmn => pkmn == ((RadioButton)sender).Content);

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsSubmissionValid() != MessageBoxResult.None) return;
            DialogResult = true;
            Close();
        }
        private MessageBoxResult IsSubmissionValid()
        {
            if (txtblckTrainerName.Text == string.Empty || txtblckTrainerName.Text.Contains("Enter"))
                return MessageBox.Show("Please tell me your name!");

            try
            {
                Trainer = new Trainer(txtblckTrainerName.Text, SelectedStarter, "playerTeam.txt");
                return MessageBoxResult.None;
            }
            catch (NullReferenceException e) { return MessageBox.Show("You didn't select a pokémon!\n\n" + e.Message); }
        }
    }
}
