using Modele;
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
using System.ComponentModel;

namespace PartieGraphique
{
    /// <summary>
    /// Logique d'interaction pour PagePerso.xaml
    /// </summary>
    public partial class PagePerso : Window
    {
        public PagePerso(Personnage perso)
        {
            InitializeComponent();
            chargementperso(perso);            //Appel de la méthode chargementperso
            CaractPerso.DataContext = perso;   //Précise le chemin du binding des caractéristiques du personnage. 
            lesterrains.DataContext = perso;   //Précise le chemin du binding des terrains favoris du personnage 
        }


        /// <summary>
        /// Cette méthode va convertir le string d'une image en BitmapImage
        /// </summary>
        /// <param name="perso"></param>
        private void chargementperso(Personnage perso)
        {
            imageperso.Source = new BitmapImage(new Uri(perso.ImagePersoSource, UriKind.RelativeOrAbsolute)); //L'objet ImagePersoSource va être converti en BitmapImage appliquable aux éléments de notre vue
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).lespersos.Sauvegarde();    //Sauvegarde des personnages lors de la fermeture de la fenêtre
            (Application.Current as App).lesterrains.Sauvegarde();  //Sauvegarde des terrains lors de la fermeture de la fenêtre
        }
    }
}
