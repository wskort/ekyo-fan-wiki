using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOv2
{
    internal struct Resources
    {
        public int Unu { get; set; } //Unubtanium
        public int Sur { get; set; } //Surilium
        public int Dal { get; set; } //Dalium
        public int Bla { get; set; } //Blarnium
        public int Pro { get; set; } //Propanisatol
        public int Bol { get; set; } //Bolinogeen
        public int Ami { get; set; } //Aminoterazine
        public int Ino { get; set; } //Inositoprinofaat 

        /// <summary>
        /// Initialise list of components; all default 0
        /// </summary>
        /// <param name="unu">Unubtanium</param>
        /// <param name="sur">Surilium</param>
        /// <param name="dal">Dalium</param>
        /// <param name="bla">Blarnium</param>
        /// <param name="pro">Propanisatol</param>
        /// <param name="bol">Bolinogeen</param>
        /// <param name="ami">Aminoterazine</param>
        /// <param name="ino">Inositoprinofaat</param>
        public Resources(
            int unu = 0,
            int sur = 0,
            int dal = 0,
            int bla = 0,
            int pro = 0,
            int bol = 0,
            int ami = 0,
            int ino = 0)
        {
            Unu = unu;
            Sur = sur;
            Dal = dal;
            Bla = bla;
            Pro = pro;
            Bol = bol;
            Ami = ami;
            Ino = ino;
        }

        /// <summary>
        /// Calculate cost of material components
        /// </summary>
        /// <param name="perMat">Cost per material; default 15</param>
        /// <returns>Total material cost</returns>
        public int Cost(int perMat=15)
        {
            int sum = Unu + Sur + Dal + Bla + Pro + Bol + Ami + Ino;
            return sum * perMat;
        }
    }
}
