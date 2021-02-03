using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Modele;
using System.ComponentModel;

namespace PartieGraphique
{
    /// <summary>
    /// Logique d'interaction pour AjouterPerso.xaml
    /// </summary>
    public partial class AjouterPerso : Window
    {
        Terrain ter1;
        Terrain ter2;
        Terrain ter3;
        /// <summary>
        /// Constructeur de la page : AjouterPerso
        /// </summary>
        public AjouterPerso()
        {
            InitializeComponent();
            leterrain1.DataContext = (Application.Current as App).lesterrains; //Préciser le chemin du binding sur la combobox leterain1 sur la liste des terrains.
            leterrainN2.DataContext = (Application.Current as App).lesterrains; //Préciser le chemin du binding sur la combobox leterrainN2 sur la liste des terrains.
            leterrain3.DataContext = (Application.Current as App).lesterrains; //Préciser le chemin du binding sur la combobox leterrain3 sur la liste des terrains.
        }

       
        public string ImgPers { get; set; } //Variable de l'image du personnage
        /// <summary>
        /// Méthode qui permet d'ouvrir l'explorateur de fichiers pour sélectionner une image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OuvreImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();           //ouvrir explorateur de fichier
            op.Title = "Choisissez une image";                  //Titre en haut de la fenêtre lors du choix de l'image
            op.Filter = "Une Image|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";  //Sélection d'extensions d'images uniquement
            if (op.ShowDialog() == true)
            {
               ImgPers = op.FileName;              
               imageperso.Source = new BitmapImage(new Uri(op.FileName, UriKind.RelativeOrAbsolute)); //définir le lien de l'image
            }
        }

        /// <summary>
        /// Méthode Bouton pour ajouter un personnage
        /// Cette méthode vérifie si aucune textbox est vide et si l'utilisateur a bien sélectionné une image, elle vérifie aussi si l'utilisateur sélectionne bien 3 terrains favoris pour le personnage
        /// et bien 3 terrains différents pour ensuite ajouter ces terrains à la liste des terrains du constructeur du personnage
        /// Enfin un personnage est instancié et ajouté à la listepersos des personnages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonAjouterPerso(object sender, RoutedEventArgs e)
        {
            if (Nom.Text == null)
            {
                MessageBox.Show("Ecrire un nom");
            }

            else if (Numero.Text.ToString() == "")
            {
                MessageBox.Show("Saisir un numéro");
            }
            else if (ImgPers == null)
            {
                MessageBox.Show("Sélectionner une image");
            }
            else if (SerieOrigine.Text == null)
            {
                MessageBox.Show("Ecrire une série d'origine");
            }
            else  if (Poids.Text.ToString() == "")
            {
                MessageBox.Show("Saisir un poids");
            }
            else if (Move.Text == null)
            {
                MessageBox.Show("Ecrire un move");
            }
            else if(leterrain1.SelectedItem == null || leterrainN2.SelectedItem == null || leterrain3.SelectedItem == null ||
                    leterrain1.SelectedItem == leterrainN2.SelectedItem || leterrain1.SelectedItem == leterrain3.SelectedItem || leterrainN2.SelectedItem == leterrain3.SelectedItem)
            {
                MessageBox.Show("Veuillez Sélectionner des terrains différents");
            }
            else
            {
                ListTerrain lesterrains = new ListTerrain(); //instanciation de la listeterrains pour ajouter les 3 terrans favoris du personnage
                lesterrains.ListeDesTerrains.Add(ter1);
                lesterrains.ListeDesTerrains.Add(ter2);
                lesterrains.ListeDesTerrains.Add(ter3);

                int Numperso = int.Parse(Numero.Text); //convertir le string en int
                int PoidsPerso = int.Parse(Poids.Text);

                Personnage Bot = new Personnage(ImgPers, lesterrains.ListeDesTerrains, Nom.Text, Numperso, SerieOrigine.Text, PoidsPerso, Move.Text); //Instanciation du personnage pour l'ajouter à la liste avec les données saisies
                (Application.Current as App).lespersos.ListeDesPersos.Add(Bot); //Ajout du personnage à la liste 
                MessageBox.Show($"Personnage {Bot.NomPerso} créé");
            }
        }

        /// <summary>
        /// Cette méthode permet d'afficher un terrain lorsqu'on le sélectionne dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Terrainnum1 (object sender, SelectionChangedEventArgs e)
        {
            if(leterrain1.SelectedItem != null)
            {
                ter1 = leterrain1.SelectedItem as Terrain;           //Récupère le terrain sélectionné dans la combobox
                imageterrain.DataContext = leterrain1.SelectedItem;  //Ajoute le terrain à l'image pour pouvoir l'afficher sous la combobox
            }
            
        }

        /// <summary>
        /// Cette méthode permet d'afficher un terrain lorsqu'on le sélectionne dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Terrainnum2(object sender, SelectionChangedEventArgs e)
        {
            if (leterrainN2.SelectedItem != null)
            {
                ter2 = leterrainN2.SelectedItem as Terrain;         
                imageterrain2.DataContext = leterrainN2.SelectedItem;
            }
           
        }

        /// <summary>
        /// Cette méthode permet d'afficher un terrain lorsqu'on le sélectionne dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Terrainnum3(object sender, SelectionChangedEventArgs e)
        {
            if (leterrain3.SelectedItem != null)
            {
                ter3 = leterrain3.SelectedItem as Terrain;
                imageterrain3.DataContext = leterrain3.SelectedItem;
            }
            
        }
       
        /// <summary>
        /// Cette évenement vérifie si l'utilisateur ne saisi que des nombres sur son clavier, c'est un Regex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerificationNum(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+"); //instanciation du regex qui ne prend que des chiffres entre 0 et 9;
            e.Handled = regex.IsMatch(e.Text); 
        }


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).lespersos.Sauvegarde();    //Sauvegarde des personnages lors de la fermeture de la fenêtre
            (Application.Current as App).lesterrains.Sauvegarde();  //Sauvegarde des terrains lors de la fermeture de la fenêtre
        }



    }


}
