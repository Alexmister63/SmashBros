using Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PartieGraphique.UC
{
    /// <summary>
    /// Logique d'interaction pour UCDetailsPersonnage.xaml
    /// </summary>
    public partial class UCDetailsPersonnage : UserControl
    {
        Personnage perso;
        public UCDetailsPersonnage()
        {
            InitializeComponent();
            comboboxpersos.DataContext = (Application.Current as App).lespersos; //Préciser le chemin du binding de la combobox sur la liste de personnages       
        }
       
        
        /// <summary>
        /// Bouton pour accéder à la page Personnage si aucun Perso sélectionné alors afficher le message "Sélectionnez un personnage !"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Personnage(object sender, RoutedEventArgs e)
        {
            if(comboboxpersos.SelectedItem != null)
            {
                PagePerso win = new PagePerso(perso);
                var myWindow = Window.GetWindow(this); //Récupère la page actuelle où il y a l'UC
                myWindow.Close();
                win.Show();
            }
            else
            {
                MessageBox.Show("Sélectionnez un personnage !");
            }
            
        }

        /// <summary>
        /// Cette méthode récupère un personnage sélectionné dans la combobox et permet d'ajouter une image (imagesource) sur le bouton de la page personnage 
        /// et d'ajouter les notes du personnage dans la textbox NotePerso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboboxpersos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboboxpersos.SelectedItem != null)
            {
                perso = comboboxpersos.SelectedItem as Personnage;
                imagesource.Source = new BitmapImage(new Uri(perso.ImagePersoSource, UriKind.RelativeOrAbsolute));  //L'objet ImagePersoSource va être converti en BitmapImage appliquable aux éléments de notre vue
                NotePersonnage.Text = perso.NotePerso;
            }
        }
        /// <summary>
        /// Cette méthode créé un nombre au hasard et prend au hasard un personnage entre 0 et le nombre max de personnages dans la liste lespersos
        /// puis ajoute ce personnage à la comboboxpersos ce qui permet d'avoir un personnage choisi au hasard 
        /// et d'ajouter aussi les notes du personnage choisi dans la textbox NotePerso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void choisietoutseul(object sender, RoutedEventArgs e)
        {
            Random random = new Random();           //instanciation de Random
            int randomNumber;                       //création du nombre aléatoire voulu
            int max = (Application.Current as App).lespersos.ListeDesPersos.Count;    //création du nombre qui correspond au nombre total de personnages dans la liste lespersos
            randomNumber = random.Next(0, max);                             //on décide de l'intervalle du nombre random, ici entre 0 et le nombre max de personnages 

            comboboxpersos.SelectedIndex = randomNumber;          //Le personnage de la combobox correspond au nombre choisi au hasard pour actualiser la sélection du personnage dans la combobox + l'image
            NotePersonnage.Text = perso.NotePerso;                //La note du personnage s'actualise aussi en fonction du personnage sélectionné
        }

        /// <summary>
        /// Méthode pour ajouter ce qu'on écrit dans la textbox NotePerso dans NotePersonnage du Personnage sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            perso.NotePerso = NotePersonnage.Text;
        }
    }
}
