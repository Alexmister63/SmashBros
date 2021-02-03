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
    /// Logique d'interaction pour PageModifPerso.xaml
    /// </summary>
    public partial class PageModifPerso : Window
    {
        Terrain ter1;
        Terrain ter2;
        Terrain ter3;
        Personnage persomodif;
        public PageModifPerso(Personnage perso)
        {
            InitializeComponent();          
            
            Nom.Text = perso.NomPerso;
            Numero.Text = perso.Numero.ToString();
            SerieOrigine.Text = perso.SerieOrigine;
            Poids.Text = perso.Poids.ToString();
            Move.Text = perso.MoveLePlusRapide;
            imageperso.Source = new BitmapImage(new Uri(perso.ImagePersoSource, UriKind.RelativeOrAbsolute)); //L'objet ImagePersoSource va être converti en BitmapImage appliquable aux éléments de notre vue

            leterrain1.DataContext = (Application.Current as App).lesterrains;    //Préciser le chemin du binding sur la combobox leterain1 sur la liste des terrains.
            leterrainN2.DataContext = (Application.Current as App).lesterrains;   //Préciser le chemin du binding sur la combobox leterainN2 sur la liste des terrains.
            leterrain3.DataContext = (Application.Current as App).lesterrains;    //Préciser le chemin du binding sur la combobox leterain3 sur la liste des terrains.

            leterrain1.SelectedItem = perso.TerrainsAv[0];
            leterrainN2.SelectedItem = perso.TerrainsAv[1];
            leterrain3.SelectedItem = perso.TerrainsAv[2];

            persomodif = perso;  //personnage qui va être modifié qui est égal au personnage d'origine avant sa modification
        }


        public string ImgPers { get; set; }
       
        /// <summary>
        /// Fonction qui permet d'ajouter une image via l'explorateur de fichiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void ChoisirImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();           //ouvrir explorateur de fichier
            op.Title = "Choisissez une image";                  //Titre de la fenêtre pour chosir l'image
            op.Filter = "Une Image|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";  //extensions d'images uniquement
            if (op.ShowDialog() == true)
            {
                ImgPers = op.FileName;
                imageperso.Source = new BitmapImage(new Uri(op.FileName, UriKind.RelativeOrAbsolute)); //définir le lien de l'image

            }
        }

        /// <summary>
        /// Cette méthode permet d'afficher un terrain lorsqu'on le sélectionne dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Terrainnum1(object sender, SelectionChangedEventArgs e)
        {
            if (leterrain1.SelectedItem != null)
            {
                ter1 = leterrain1.SelectedItem as Terrain;             //Récupère le terrain sélectionné dans la combobox
                imageterrain.DataContext = leterrain1.SelectedItem;   //Ajoute le terrain à l'image pour pouvoir l'afficher sous la combobox
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
        /// Méthode du bouton pour modifier un personnage
        /// Cette méthode va tout comme la méthode BoutonAjouterPerso dans AjouterPerso.xaml.cs vérifier si les textbox ne sont pas nulles et si les 3 terrains favoris sélectionnés sont bien différents
        /// Puis elle va instancier un personnage et remplacer ses attributs actuels par ceux saisis dans les textbox
        /// Une messagebox va s'afficher pour confirmer la modification du personnage si celui-ci est modifié.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonModifPerso(object sender, RoutedEventArgs e)
        {
            if (Nom.Text == null)
            {
                MessageBox.Show("Ecrire un nom");
            }
            else if (Numero.Text == null)
            {
                MessageBox.Show("Saisir un numéro");
            }
            else if (SerieOrigine.Text == null)
            {
                MessageBox.Show("Ecrire une série d'origine");
            }
            else if (Poids.Text == null)
            {
                MessageBox.Show("Saisir un poids");
            }
            else if (Move.Text == null)
            {
                MessageBox.Show("Ecrire un move");
            }
            else if (leterrain1.SelectedItem == null || leterrainN2.SelectedItem == null || leterrain3.SelectedItem == null ||
                    leterrain1.SelectedItem == leterrainN2.SelectedItem || leterrain1.SelectedItem == leterrain3.SelectedItem || leterrainN2.SelectedItem == leterrain3.SelectedItem)
            {
                MessageBox.Show("Veuillez Sélectionner des terrains différents");
            }
            else
            {
                ListTerrain lesterrains = new ListTerrain();
                lesterrains.ListeDesTerrains.Add(ter1);
                lesterrains.ListeDesTerrains.Add(ter2);
                lesterrains.ListeDesTerrains.Add(ter3);

                int Numperso = int.Parse(Numero.Text); //convertir le string en int
                int PoidsPerso = int.Parse(Poids.Text);

                Personnage Bot = new Personnage(ImgPers, lesterrains.ListeDesTerrains, Nom.Text, Numperso, SerieOrigine.Text, PoidsPerso, Move.Text);                

                int NumpersoInt = int.Parse(Numero.Text); //convertir le string en int
                int PoidsPersoInt = int.Parse(Poids.Text);

                persomodif.NomPerso = Nom.Text;  //Le nom du personnage modifié est égal au nom du personnage saisi dans la textbox
                persomodif.Numero = NumpersoInt;
                persomodif.SerieOrigine = SerieOrigine.Text;
                persomodif.Poids = PoidsPersoInt;
                persomodif.MoveLePlusRapide = Move.Text;
                if(ImgPers != null)
                {
                    persomodif.ImagePersoSource = ImgPers;
                }               
                persomodif.TerrainsAv = lesterrains.ListeDesTerrains;

                MessageBox.Show($"Personnage {Bot.NomPerso} modifié");
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
