using System;
using Modele;
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
    /// Logique d'interaction pour Réglages.xaml
    /// </summary>
    public partial class Réglages : Window
    {
        Personnage perso;
       
        public Réglages()
        {
            InitializeComponent();
          
            comboboxpersos.DataContext = (Application.Current as App).lespersos;     //Préciser le chemin du binding sur la combobox de la liste de personnages 
            comboboxterrain.DataContext = (Application.Current as App).lesterrains;  //Préciser le chemin du binding sur la combobox de la liste des terrains
            comboboxterrain.SelectedIndex = 0;   //Le premier élément de la liste des terrains dans comboboxterrains est sélectionné
        }
       
        /// <summary>
        /// Méthode du bouton pour ouvrir la page AjouterTerrain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton_AjouterTerrain(object sender, RoutedEventArgs e)
        {
            AjouterTerrain win = new AjouterTerrain();
            this.Close();
            win.Show();
        }

        /// <summary>
        /// Méthode bouton pour ouvrir la page ajouter perso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton_AjouterPerso(object sender, RoutedEventArgs e)
        {
            AjouterPerso win = new AjouterPerso();
            this.Close();
            win.Show();
        }

        /// <summary>
        /// Méthode qui correspond à l'événement selectionchanged de la comboboxpersos qui lorsqu'un personnage est sélectionné dans la comboboxpersos alors son image en dessous change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxpersos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxpersos.SelectedItem != null)
            {
                perso = comboboxpersos.SelectedItem as Personnage;
                imagesource.Source = new BitmapImage(new Uri(perso.ImagePersoSource, UriKind.RelativeOrAbsolute));
            }
        }

        /// <summary>
        /// Méthode qui correspond à l'événement selectionchanged de la comboboxterrains qui lorsqu'un personnage est sélectionné dans la comboboxterrains alors son image en dessous change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxterrain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxterrain.SelectedItem != null)
            {
             
                imageterrain.DataContext = comboboxterrain.SelectedItem;
            }
        }

        /// <summary>
        /// Méthode du bouton supprimer personnage qui va supprimer le personnage sélectionné dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupprimerPerso(object sender, RoutedEventArgs e)
        {
            if(comboboxpersos.SelectedItem != null)
            {
                Personnage leperso = comboboxpersos.SelectedItem as Personnage;         //instancie le personnage sélectionné dans la combobox
                (Application.Current as App).lespersos.ListeDesPersos.Remove(leperso);  //Supprime ce personnage de la liste des personnages
                MessageBox.Show($"Personnage {leperso.NomPerso} supprimé");             //Messagebox pour confirmer que le personnage a été supprimé
                comboboxpersos.SelectedIndex = 0;                                       //Une fois le personnage supprimé la comboboxpersos re affiche le premier personnage de la liste des personnages
            }
        }

        /// <summary>
        /// Méthode qui si un personnage est sélectionné dans la comboboxpersos on peut ouvrir la PageModifPerso pour modifier ce personnage sinon elle affiche un messagebox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonModifierPerso(object sender, RoutedEventArgs e)
        {
            if (comboboxpersos.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un personnage !");
            }
            else
            {
                PageModifPerso win = new PageModifPerso(perso);
                this.Close();
                win.Show();
            }

        }

       

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).lespersos.Sauvegarde();    //Sauvegarde des personnages lors de la fermeture de la fenêtre
            (Application.Current as App).lesterrains.Sauvegarde();  //Sauvegarde des terrains lors de la fermeture de la fenêtre
        }

    }
}
