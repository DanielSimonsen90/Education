using ABCLibrary;
using System.Windows.Controls;

namespace ABCGUI
{
    /// <summary>
    /// Interaction logic for UCPokemonSlot.xaml
    /// </summary>
    public partial class UCPokemonSlot : UserControl
    {
        public Pokémon member;
        public UCPokemonSlot()
        {
            InitializeComponent();
            DataContext = member;
        }
    }
}
