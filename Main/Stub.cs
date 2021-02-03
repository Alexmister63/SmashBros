using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Modele;

namespace Data
{
    public class Stub
    {

        /// <summary>
        /// Méthode qui créé des personnages 
        /// </summary>
        /// <returns></returns>
        public static ListPerso CreationDePersonnages()
        {
            ListPerso ListeDePerso = new ListPerso();
            
            if (File.Exists("personnages.bin")) //Cherche si le fichier personnages.bin existe car si il existe il y a des données donc il faut les charger
            {
                ListeDePerso.Chargement();  //Ici on charge les données des personnages si elles existent dans le fichier
            }
            else   //Sinon éxecuter l'instanciation des personnages (que au premier lancement sauf si suppression du fichier personnages.bin)
            {
                Personnage Mario = new Personnage("/Images;component/Personnages/1-Mario.png", CreationDeTerrainsFavorisRandom(), "Mario", 1, "Super Mario", 28, "Jab(frame 2)", "Bonjour, je suis mario");
                Personnage DonkeyKong = new Personnage("/Images;component/Personnages/2-Donkey_Kong.png", CreationDeTerrainsFavorisRandom(), "Donkey Kong", 2, "Donkey Kong", 3, "Up B aérien (frame 4)", "Un poids lourd qui joue beaucoup avec ses choppes");
                Personnage Link = new Personnage("/Images;component/Personnages/3-Link.png", CreationDeTerrainsFavorisRandom(), "Link", 3, "The Legend of Zelda", 19, "Grab (frame 6)", "Un combattant versatile avec de nombreux projectiles.");
                Personnage Samus = new Personnage("/Images;component/Personnages/4-Samus.png", CreationDeTerrainsFavorisRandom(), "Samus", 4, "Metroid", 9, "Jab (frame 3)", "Samus Aran est un personnage de fiction et la protagoniste de la série de jeux vidéo de science fiction Metroid");
                Personnage Yoshi = new Personnage("/Images;component/Personnages/5-Yoshi.png", CreationDeTerrainsFavorisRandom(), "Yoshi", 5, "Yoshi's Island", 19, "Nair (frame 3)", "Un dragon pas tès commun");
                Personnage Kirby = new Personnage("/Images;component/Personnages/6-Kirby.png", CreationDeTerrainsFavorisRandom(), "Kirby", 6, "Kirby", 68, "Jab (frame 2)", "Un personnage tout mimi");
                Personnage Fox = new Personnage("/Images;component/Personnages/7-Fox.png", CreationDeTerrainsFavorisRandom(), "Fox", 7, "Star Fox", 72, "Jab (frame 2)", "Le renard de l'espace");
                Personnage Pikachu = new Personnage("/Images;component/Personnages/8-Pikachu.png", CreationDeTerrainsFavorisRandom(), "Pikachu", 8, "Pokémon", 68, "Jab (frame 2)", "PIKAAAAAAAACHUUUUUUUUUUUUUUUUUUUUU");
                Personnage Luigi = new Personnage("/Images;component/Personnages/9-Luigi.png", CreationDeTerrainsFavorisRandom(), "Luigi", 9, "Super Mario", 31, "Jab (frame 2)", "Il est plus grand que son frère mais a peur de tout");
                Personnage Ness = new Personnage("/Images;component/Personnages/10-Ness.png", CreationDeTerrainsFavorisRandom(), "Ness", 10, "Mother/Earthbound", 41, "Dtilt (frame 3)", "Ness, le petit garçon à la force de brute");
                Personnage CaptainFalcon = new Personnage("/Images;component/Personnages/11-Captain_Falcon.png", CreationDeTerrainsFavorisRandom(), "Captain Falcon", 19, "F-ZERO", 9, "Jab (frame 3)", "Grand pilote de course");
                Personnage Rondoudou = new Personnage("/Images;component/Personnages/12-Rondoudou.png", CreationDeTerrainsFavorisRandom(), "Rondoudou", 12, "Pokémon", 76, "Down B (frame 2)", "Aussi mignon que Kirby et pourtant très agressif ");

                ListeDePerso.ListeDesPersos.Add(Mario);
                ListeDePerso.ListeDesPersos.Add(DonkeyKong);
                ListeDePerso.ListeDesPersos.Add(Link);
                ListeDePerso.ListeDesPersos.Add(Samus);
                ListeDePerso.ListeDesPersos.Add(Yoshi);
                ListeDePerso.ListeDesPersos.Add(Kirby);
                ListeDePerso.ListeDesPersos.Add(Fox);
                ListeDePerso.ListeDesPersos.Add(Pikachu);
                ListeDePerso.ListeDesPersos.Add(Luigi);
                ListeDePerso.ListeDesPersos.Add(Ness);
                ListeDePerso.ListeDesPersos.Add(CaptainFalcon);
                ListeDePerso.ListeDesPersos.Add(Rondoudou);

            }


            return ListeDePerso;
        }

        /// <summary>
        /// Méthode qui créé des terrains
        /// </summary>
        /// <returns></returns>
        public static ListTerrain CreationDeTerrains()
        {
            ListTerrain ListeTerrains = new ListTerrain();

            if (File.Exists("terrains.bin")) //Cherche si le fichier terrains.bin existe car si il existe il y a des données donc il faut les charger
            {
                ListeTerrains.Chargement();  //Ici on charge les données des personnages si elles existent dans le fichier
            }
            else     //Sinon éxecuter l'instanciation des terrains (que au premier lancement sauf si suppression du fichier terrains.bin)
            {
                Terrain t1 = new Terrain("Smash Ville", false, "/Images;component/Terrains/Smash_Ville.png");
                Terrain t2 = new Terrain("Destination finale", false, "/Images;component/Terrains/Destination_finale.jpg");
                Terrain t3 = new Terrain("Yoshi Story", false, "/Images;component/Terrains/Yoshi_Story.png");
                Terrain t4 = new Terrain("Champ de bataille", false, "/Images;component/Terrains/Champ_de_Bataille.png");
                Terrain t5 = new Terrain("Ile de Yoshi", false, "/Images;component/Terrains/Ile_de_Yoshi.png");
                Terrain t6 = new Terrain("Ligue Pokemon de Kalos", false, "/Images;component/Terrains/Ligue_Pokemon_de_Kalos.png");
                Terrain t7 = new Terrain("Stade Pokemon 2", false, "/Images;component/Terrains/Stade_Pokemon_2.png");
                Terrain t8 = new Terrain("Traversee de Lylat", false, "/Images;component/Terrains/Traversee_de_Lylat.jpg");
                Terrain t9 = new Terrain("Ville et Centre-ville", false, "/Images;component/Terrains/Ville_et_Centre-Ville.jpg");

                ListeTerrains.ListeDesTerrains.Add(t1);
                ListeTerrains.ListeDesTerrains.Add(t2);
                ListeTerrains.ListeDesTerrains.Add(t3);
                ListeTerrains.ListeDesTerrains.Add(t4);
                ListeTerrains.ListeDesTerrains.Add(t5);
                ListeTerrains.ListeDesTerrains.Add(t6);
                ListeTerrains.ListeDesTerrains.Add(t7);
                ListeTerrains.ListeDesTerrains.Add(t8);
                ListeTerrains.ListeDesTerrains.Add(t9);
            }

           
            return ListeTerrains;

        }

        /// <summary>
        /// Méthode qui créé les 3 terrains favoris des personnages au hasard
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Terrain> CreationDeTerrainsFavorisRandom()
        {
            ObservableCollection<Terrain> ListeTerrains = new ObservableCollection<Terrain>();  //On créé la liste des terrains favoris
            ListTerrain ListeComplete = CreationDeTerrains();                                   //Création de tout les terrains de l'application
           
            Random random = new Random();  //On instancie Random
            
            int numrang; //création des rangs qui vont être sélectionnés au hasard, 1 rang correspond à un des trois terrains favoris
            int numrang2;
            int numrang3;

            numrang = random.Next(0, ListeComplete.ListeDesTerrains.Count - 1);    //On créé un nombre au hasard entre 0 (début liste) et le nombre de terrains totaux de l'application
            
            ListeTerrains.Add(ListeComplete.ListeDesTerrains[numrang]);        //On ajoute ce nombre à la liste des terrains favoris

            numrang2 = random.Next(0, ListeComplete.ListeDesTerrains.Count - 1);   //On recréé un nombre au hasard entre 0 (début liste) et le nombre de terrains totaux de l'application
            if (numrang2 == numrang)  //Si le nombre du terrain2 est égal au terrain 3 alors
            {
                while(numrang2 == numrang) //tant qu'ils sont égaux
                {
                    numrang2 = random.Next(0, ListeComplete.ListeDesTerrains.Count - 1);  //On créé un nombre au hasard
                }
            }
            ListeTerrains.Add(ListeComplete.ListeDesTerrains[numrang2]);    //Puis on ajoute ce nombre à la liste des terrains favoris et on répète le processus pour le terrain3

            numrang3 = random.Next(0, ListeComplete.ListeDesTerrains.Count - 1);
            if (numrang3 == numrang || numrang3 == numrang2)
            {
                while (numrang3 == numrang || numrang3 == numrang2)
                {
                    numrang3 = random.Next(0, ListeComplete.ListeDesTerrains.Count - 1);
                }
            }

            ListeTerrains.Add(ListeComplete.ListeDesTerrains[numrang3]);

           

            return ListeTerrains;  //Retourne la liste des 3 terrains favoris du personnage sélectionés au hasard
        }

       



    }
}
