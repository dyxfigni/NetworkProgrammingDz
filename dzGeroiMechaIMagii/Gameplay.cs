using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dzTmaSvet.Units;

namespace dzTmaSvet
{
    
    //[DllImport(@"E:\kod\NetworkProgramming\NetworkProgramming\x64\Debug\LibraryOfGame.dll")] 
    //static extern double chance(ref IntPtr thisPtr);

    internal class Gameplay
    {
        public uint CommandChoice { get; set; }
        private List<BaseUnit> command1;
        private List<BaseUnit> command2;
        private double Chance() => new Random().Next(0, 100) / new Random().Next(0, 100);

        public Gameplay()
        {
            ;
        }

        public void buildCommand();
        public void printCommand();
        public void Fight();

        public void Attack(BaseUnit*& u1, BaseUnit*& u2);
    }
}