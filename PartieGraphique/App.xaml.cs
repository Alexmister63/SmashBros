using Modele;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PartieGraphique
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ListPerso lespersos = Data.Stub.CreationDePersonnages();          //Instance permettant de manipuler les données de personnage lorsqu'on navigue sur l'application
        public ListTerrain lesterrains = Data.Stub.CreationDeTerrains();   //Instance permettant de manipuler les données de terrain lorsqu'on navigue sur l'application
    }
}
