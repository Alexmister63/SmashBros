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
using System.Windows.Shapes;
using System.Xml;
using System.ComponentModel;
using Modele;
namespace PartieGraphique
{
    /// <summary>
    /// Logique d'interaction pour PageAccueil.xaml
    /// </summary>
    public partial class PageAccueil : Window
    {
        
        public PageAccueil()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Méthode qui permet au bouton réglages d'ouvrir la page Réglages lorsqu'on clique dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonReglage_Click(object sender, RoutedEventArgs e)
        {
            Réglages win = new Réglages();   //Instanciation de la page Réglages
            this.Close();                    //Fermeture de la page actuelle
            win.Show();                      //Ouverture de la page win de type Réglages
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).lespersos.Sauvegarde();    //Sauvegarde des personnages lors de la fermeture de la fenêtre
            (Application.Current as App).lesterrains.Sauvegarde();  //Sauvegarde des terrains lors de la fermeture de la fenêtre
        }
    }
}
