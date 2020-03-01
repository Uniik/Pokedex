using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    class Pokemon
    {
        private string nom;
        private string dresseur; // pas attrapé si null
        private bool male;
        private int generation;
        private int HP;
        private int Attack;
        private int Defense;
        private int Speed;
        private int TotalStats;
        private int element1Index;
        private int element2Index;
        private string element1;
        private string element2 = null; // seulement un élément si null

        public static readonly string[] elements = {
            "ACIER","COMBAT","DRAGON","EAU","ÉLECRIK","FÉE",
            "FEU","GLACE","INSECTE","NORMAL","PLANTE","POINSON",
            "PSY","ROCHE","SOL","SPECTRE","TÉNEBRE","VOL"
    };

        public string Nom { get => nom; set => nom = value; }
        public string Dresseur { get => dresseur; set => dresseur = value; }
        public bool Male { get => male; set => male = value; }
        public int Generation { get => generation; set => generation = value; }
        public string Element1 { get => element1; set => element1 = value; }
        public string Element2 { get => element2; set => element2 = value; }
        public int HP1 { get => HP; set => HP = value; }
        public int Attack1 { get => Attack; set => Attack = value; }
        public int Defense1 { get => Defense; set => Defense = value; }
        public int Speed1 { get => Speed; set => Speed = value; }
        public int TotalStats1 { get => TotalStats; set => TotalStats = value; }
        public int Element1Index { get => element1Index; set => element1Index = value; }
        public int Element2Index { get => element2Index; set => element2Index = value; }

        public Pokemon(string nom, bool male, int generation, string dresseur, int element1, int element2 = -1)
        {
            this.nom = nom;
            this.male = male;
            this.generation = generation;
            this.dresseur = dresseur;
            this.element1Index = element1;
            this.element2Index = element2;
            this.element1 = elements[element1];
            if(element2 > -1)
            {
                this.element2 = elements[element2];
            }
            switch (generation)
            {
                case 1:
                    generateStats(25, 175);
                    break;
                case 2:
                    generateStats(50, 200);
                    break;
                case 3:
                    generateStats(75, 200);
                    break;
                case 4:
                    generateStats(100, 225);
                    break;
                case 5:
                    generateStats(125, 225);
                    break;
                case 6:
                    generateStats(150, 250);
                    break;
                case 7:
                    generateStats(175, 250);
                    break;

            }
            
        }

        private void generateStats(int min, int max)
        {
            Random rand = new Random();
            this.HP =rand.Next(min, max);
            this.Attack = rand.Next(min, max);
            this.Defense = rand.Next(min, max);
            this.Speed = rand.Next(min, max);
            this.TotalStats = this.HP + this.Attack + this.Defense + this.Speed;
        }
    }
}
