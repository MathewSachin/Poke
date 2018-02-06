﻿using System.Windows;

namespace Poke
{
    public partial class DexPage
    {
        public DexPage()
        {
            InitializeComponent();
        }

        void GoToNatures(object Sender, RoutedEventArgs E)
        {
            NavigationService?.Navigate(new NaturesPage());
        }

        void GoToAbilities(object Sender, RoutedEventArgs E)
        {
            NavigationService?.Navigate(new AbilitiesListPage());
        }

        void GoToMoves(object Sender, RoutedEventArgs E)
        {
            NavigationService?.Navigate(new MovesListPage());
        }

        void GoToTypeEffectiveness(object Sender, RoutedEventArgs E)
        {
            NavigationService?.Navigate(new TypeEffectivenessPage());
        }

        void GoToPokemonList(object Sender, RoutedEventArgs E)
        {
            NavigationService?.Navigate(new PokemonListPage());
        }
    }
}
