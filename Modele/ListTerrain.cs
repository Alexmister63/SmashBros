using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Modele
{
    [Serializable]
    public class ListTerrain : IPersistance
    {

        //Observable collection de personnages, on l'utilise car on a besoin d'actualiser la vue dès qu'il y a une modification (En appelant Inotifycollectionchanged)
        public ObservableCollection<Terrain> ListeDesTerrains { get; set; }

        /// <summary>
        /// Constructeur d'une ListTerrain
        /// </summary>
        public ListTerrain()
        {
            ListeDesTerrains = new ObservableCollection<Terrain>();
        }

       /// <summary>
       /// Méthode sauvegarde qui sauvegarde les données des terrains. Le nom, l'image et l'aléa.
       /// </summary>
        public void Sauvegarde()
        {
            List<Terrain> Listsauvegarde = new List<Terrain>(); //Créer une Liste de Terrains vide pour la remplir lorsqu'on va sauvegarder les données
            foreach (Terrain t in ListeDesTerrains)  //Pour chaque terrains dans la ListeDesTerrains
            {
                Listsauvegarde.Add(t);    //Ajouter ce terrain à la liste qui va être sauvegardé
            }
            using (Stream stream = File.Open("terrains.bin", FileMode.Create)) //Stream est un flot de données qu'on utilise, on créé ici terrains.bin "FileMode.Create"
            {
                BinaryFormatter bin = new BinaryFormatter(); //il faut créer un binaryformateur pour l'utiliser qui permet de sérializer ou désérialiser
                bin.Serialize(stream, Listsauvegarde);  //écrit les données (Sérialise) 
            }
        }

        /// <summary>
        /// Méthode Chargement des données sauvegardées.
        /// </summary>
        public void Chargement()
        {
            using (Stream stream = File.Open("terrains.bin", FileMode.Open))    //On ouvre le fichier créé "terrains.bin"
            {
                BinaryFormatter bin = new BinaryFormatter();     //il faut créer un binaryformateur pour l'utiliser qui permet de sérializer ou désérialiser
                var ListChargement = (List<Terrain>)bin.Deserialize(stream);     //déserialise (charge) les données, la déserialisation sert à décortiquer les données. On utilise la liste de de terrains sauvegardée dans la fonction sauvegarde
                foreach (Terrain t in ListChargement)   //Pour chaque terrain déserialisé
                {
                    ListeDesTerrains.Add(t);    //l'ajouter à la ListeDesTerrains pour charger les données
                }
            }

        }
    }
}
