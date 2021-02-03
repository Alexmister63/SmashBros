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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PartieGraphique.UC
{
    /// <summary>
    /// Logique d'interaction pour boutonhome.xaml
    /// </summary>
    public partial class UCBoutonHome : UserControl
    {
        public UCBoutonHome()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cette méthode sert à ouvrir une nouvelle fenêtre depuis un User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton_Accueil(object sender, RoutedEventArgs e)
        {
            PageAccueil win = new PageAccueil();
            var myWindow = Window.GetWindow(this); //Récupère la page actuelle où il y a l'UC
            myWindow.Close();
            win.Show();
        }
    }
}
