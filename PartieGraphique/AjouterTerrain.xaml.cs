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
using Microsoft.Win32;
using Modele;
using System.ComponentModel;

namespace PartieGraphique
{
    /// <summary>
    /// Logique d'interaction pour AjouterTerrain.xaml
    /// </summary>
    public partial class AjouterTerrain : Window
    {
        public AjouterTerrain()
        {
            InitializeComponent();
        }

        

        public string ImgTerrain { get; set; }      //Variable de l'image du terrain
        /// <summary>
        /// Méthode qui permet d'ouvrir l'explorateur de fichiers pour sélectionner une image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjoutImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();           //ouvrir explorateur de fichier
            op.Title = "Choisissez une image";                  //Titre en haut de la fenêtre lors du choix de l'image
            op.Filter = "Une Image|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";  //Sélection d'extensions d'images uniquement
            if (op.ShowDialog() == true)
            {
                ImgTerrain = op.FileName;
                imageterrain.Source = new BitmapImage(new Uri(op.FileName, UriKind.RelativeOrAbsolute)); //définir le lien de l'image
            }
        }


        /// <summary>
        /// Méthode qui permet d'ajouter un terrain, si aucun nom, aléa ou image n'est sélectionné elle renvoie une messagebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonAjouterTerrain(object sender, RoutedEventArgs e)
        {
            Boolean champrempli = true;
           
            Boolean alea = new Boolean();
            if (NomTerrain.Text.Length == 0)
            {
                champrempli = false;
                MessageBox.Show("Ecrire un nom de terrain");
            }            
            if (ImgTerrain == null)
            {
                champrempli = false;
                MessageBox.Show("Sélectionner une image");
            }
            if(CheckOn.IsChecked is false || CheckOn == null)
            {              
                alea = false;
            }
            if(CheckOn.IsChecked is true)
            {
            
                alea = true;
            }
            if (champrempli)
            {
                Terrain arene = new Terrain(NomTerrain.Text, alea, ImgTerrain);                    //Instanciation du terrain créé 
                (Application.Current as App).lesterrains.ListeDesTerrains.Add(arene);       //Ajout du terrain créé à la liste lesterrains
                MessageBox.Show($"Terrain {arene.NomTerrain} créé");                        //Messagebox pour indiquer que le terrain a été créé
            }

            
          
            
           
                
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).lespersos.Sauvegarde();    //Sauvegarde des personnages lors de la fermeture de la fenêtre
            (Application.Current as App).lesterrains.Sauvegarde();  //Sauvegarde des terrains lors de la fermeture de la fenêtre
        }
    }
}
