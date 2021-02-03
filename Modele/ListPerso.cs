using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;


namespace Modele
{ 
    [Serializable]  //Indiquer que la classe est sérializable
    public class ListPerso : IPersistance
    {
        //Observable collection de personnages, on l'utilise car on a besoin d'actualiser la vue dès qu'il y a une modification 
        public ObservableCollection<Personnage> ListeDesPersos { get; set; }

        /// <summary>
        /// Constructeur d'une ListPerso
        /// </summary>
        public ListPerso()
        {
            ListeDesPersos = new ObservableCollection<Personnage>();
        }


        /// <summary>
        /// Fonction sauvegarde qui sauvegarde les données des personnages. Le nom, le numéro, l'image, le poids, le move, la série d'origine, sa note et ses 3 terrains favoris
        /// </summary>
        public void Sauvegarde()
        {
            List<Personnage> Listsauvegarde = new List<Personnage>();   //Créer une Liste de Personnages vide pour la remplir lorsqu'on va sauvegarder les données
            foreach (Personnage p in ListeDesPersos) //Pour chaque personnage dans la ListeDesPersos
            {
                Listsauvegarde.Add(p);      //Ajouter ce personnage à la liste qui va être sauvegardé
            }
            using (Stream stream = File.Open("personnages.bin", FileMode.Create)) //Stream est un flot de données qu'on utilise, on créé ici personnages.bin "FileMode.Create"
            {
                BinaryFormatter bin = new BinaryFormatter();        //il faut créer un binaryformateur pour l'utiliser qui permet de sérializer ou désérialiser
                bin.Serialize(stream, Listsauvegarde);              //écrit les données (Sérialise)
            }
        }

        public void Chargement()
        {
            using (Stream stream = File.Open("personnages.bin", FileMode.Open))     //On ouvre le fichier créé "personnages.bin"
            {
                BinaryFormatter bin = new BinaryFormatter();        //il faut créer un binaryformateur pour l'utiliser qui permet de sérializer ou désérialiser
                var ListChargement = (List<Personnage>)bin.Deserialize(stream);      //déserialise (charge) les données, la déserialisation sert à décortiquer les données. On utilise la liste de de terrains sauvegardée dans la fonction sauvegarde
                foreach (Personnage p in ListChargement)
                {
                    ListeDesPersos.Add(p);          //l'ajouter à la ListeDesPersos pour charger les données
                }
            }

        }
    }
}
