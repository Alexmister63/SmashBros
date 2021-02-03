using System;
using System.Collections.Generic;

namespace Modele
{
    [Serializable()] 
    public class Terrain
    {
        
        //Nom du terrain
        public string NomTerrain { get;  set; }

        //aléa du terrain
        public Boolean Aleas { get;  set; }

        //source de l'image du terrain
        public string ImageTerrainSource { get;  set; }

        /// <summary>
        /// Constructeur d'un Terrain
        /// </summary>
        /// <param name="nomTerrain">Nom du terrain</param>
        /// <param name="aleas">aléa du terrain</param>
        /// <param name="sourceImage">source de l'image du terrain</param>
        public Terrain(string nomTerrain, Boolean aleas, string sourceImage)
        {
            NomTerrain = nomTerrain;
            Aleas = aleas;
            ImageTerrainSource = sourceImage;
        }

       /// <summary>
       /// Méthode ToString redéfinie
       /// </summary>
       /// <returns></returns>
        public override string ToString()
        {
            return $"{NomTerrain}";
        }

       
    }
}
