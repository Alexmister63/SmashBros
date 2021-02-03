using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modele
{
    [Serializable()]

    public class Personnage
    {
        //source de l'image du personnage
        public string ImagePersoSource { get;  set; }

        //3 terrains avantageux du personnage
        public ObservableCollection<Terrain> TerrainsAv { get;  set; }

        //nom du personnage
        public string NomPerso { get;  set; }

        //numéro du personnage
        public int Numero { get;  set; }

        //série d'origine du personnage
        public string SerieOrigine { get;  set; }

        //poids du personnage
        public int Poids { get;  set; }

        //coup spécial le plus rapide du personnage
        public string MoveLePlusRapide { get;  set; }

        //note du personnage
        public string NotePerso { get; set; }

       
        /// <summary>
        /// Constructeur d'un personnage
        /// </summary>
        /// <param name="imagePersoSource">source de l'image du personnage</param>
        /// <param name="terrainsAv">3 terrains avantageux du personnage</param>
        /// <param name="nomPerso">nom du personnage</param>
        /// <param name="numero">numéro du personnage</param>
        /// <param name="serieOrigine">série d'origine du personnage</param>
        /// <param name="poids">poids du personnage</param>
        /// <param name="moveLePlusRapide">coup spécial le plus rapide du personnage</param>
        /// <param name="notePerso">note du personnage</param>
        public Personnage(string imagePersoSource, ObservableCollection<Terrain> terrainsAv, string nomPerso, int numero, string serieOrigine, int poids, string moveLePlusRapide, string notePerso)
        {
            this.TerrainsAv = terrainsAv;
            this.ImagePersoSource = imagePersoSource;
            this.NomPerso = nomPerso;
            this.Numero = numero;
            this.SerieOrigine = serieOrigine;
            this.Poids = poids;
            this.MoveLePlusRapide = moveLePlusRapide;
            this.NotePerso = notePerso;
        }

        /// <summary>
        /// Constructeur d'un personnage sans la note
        /// </summary>
        /// <param name="imagePersoSource">source de l'image du personnage</param>
        /// <param name="terrainsAv">3 terrains avantageux du personnage</param>
        /// <param name="nomPerso">nom du personnage</param>
        /// <param name="numero">numéro du personnage</param>
        /// <param name="serieOrigine">série d'origine du personnage</param>
        /// <param name="poids">poids du personnage</param>
        /// <param name="moveLePlusRapide">coup spécial le plus rapide du personnage</param>
        public Personnage(string imagePersoSource, ObservableCollection<Terrain> terrainsAv, string nomPerso, int numero, string serieOrigine, int poids, string moveLePlusRapide)
        {
            this.TerrainsAv = terrainsAv;
            this.ImagePersoSource = imagePersoSource;
            this.NomPerso = nomPerso;
            this.Numero = numero;
            this.SerieOrigine = serieOrigine;
            this.Poids = poids;
            this.MoveLePlusRapide = moveLePlusRapide;
        
        }

      
        /// <summary>
        /// Méthode ToString redéfinie
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
           
          //return $"{ImagePersoSource}\n{retourTerrains}\n{NomPerso}\n{Numero}\n{SerieOrigine}\n{Poids}\n{MoveLePlusRapide}\n{NotePerso}\n";
            return $"{NomPerso}";
        }


       
    }
}
