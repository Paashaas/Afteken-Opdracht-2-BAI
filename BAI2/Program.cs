using System;
using System.Collections.Generic;

namespace BAI
{
    public partial class BAI_Afteken2
    {
        public static bool Vooruit(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return (b & 0b10000000) == 128;
        }
        public static uint Vermogen(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            if((b & 0b01100000) == 96)
            {
                return 100;
            }
            if((b & 0b01000000) == 64)
            {
                return 67;
            } if((b & 0b00100000) == 32)
            {
                return 33;
            }
            return 0;
        }
        public static bool Wagon(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return (b & 0b00010000) == 16;
        }
        public static bool Licht(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return (b & 0b00001000) == 8;
        }
        public static uint ID(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return (b & 0b00000111);
        }

        public static HashSet<uint> Alle(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            set.UnionWith(inputStroom);
            return set;
        }
        public static HashSet<uint> ZonderLicht(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            foreach(uint i in inputStroom)
            {
                if(!Licht(i))
                {
                    set.Add(i);
                }
            }
            return set;
        }
        public static HashSet<uint> MetWagon(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            foreach (uint i in inputStroom)
            {
                if (Wagon(i))
                {
                    set.Add(i);
                }
            }
            return set;
        }
        public static HashSet<uint> SelecteerID(List<uint> inputStroom, uint lower, uint upper)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            foreach (uint i in inputStroom)
            {
                var id = ID(i);
                if(id >= lower && id <= upper)
                {
                    set.Add(i);
                } 
            }
            return set;
        }

        public static HashSet<uint> Opdr3a(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            set.UnionWith(inputStroom);
            set.IntersectWith(ZonderLicht(inputStroom));
            set.IntersectWith(SelecteerID(inputStroom, 0, 2));
            return set;
        }

        public static HashSet<uint> Opdr3b(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            HashSet<uint> set3a = Opdr3a(inputStroom);
            HashSet<uint> alles = Alle(inputStroom);

            alles.ExceptWith(set3a);

            set = alles;
            return set;
        }

        public static void ToonInfo(uint b)
        {
            Console.WriteLine($"ID {ID(b)}, Licht {Licht(b)}, Wagon {Wagon(b)}, Vermogen {Vermogen(b)}, Vooruit {Vooruit(b)}");
        }

        public static List<uint> GetInputStroom()
        {
            List<uint> inputStream = new List<uint>();
            for (uint i = 0; i < 256; i++)
            {
                inputStream.Add(i);
            }
            return inputStream;
        }

        public static void PrintSet(HashSet<uint> x)
        {
            Console.Write("{");
            foreach (uint i in x)
                Console.Write($" {i}");
            Console.WriteLine($" }} ({x.Count} elementen)");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("=== Opgave 1 ===");
            ToonInfo(210);
            Console.WriteLine();

            List<uint> inputStroom = GetInputStroom();

            Console.WriteLine("=== Opgave 2 ===");
            HashSet<uint> alle = Alle(inputStroom);
            PrintSet(alle);
            HashSet<uint> zonderLicht = ZonderLicht(inputStroom);
            PrintSet(zonderLicht);
            HashSet<uint> metWagon = MetWagon(inputStroom);
            PrintSet(metWagon);
            HashSet<uint> groter6 = SelecteerID(inputStroom, 6, 7);
            PrintSet(groter6);
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3a ===");
            HashSet<uint> opg3a = Opdr3a(inputStroom);
            PrintSet(opg3a);
            foreach (uint b in opg3a)
            {
                ToonInfo(b);
            }
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3b ===");
            HashSet<uint> opg3b = Opdr3b(inputStroom);
            PrintSet(opg3b);
            foreach (uint b in opg3b)
            {
                ToonInfo(b);
            }
            Console.WriteLine();
        }
    }
}
