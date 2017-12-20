using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PokemonEvolution
{
    class Poke
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, List<Evolution>> dataBase =
                new Dictionary<string, List<Evolution>>();

            while ((input = Console.ReadLine()) != "wubbalubbadubdub")
            {
                if ((!input.Contains(" ")) && dataBase.ContainsKey(input))
                {
                    PrintCurrentPokemon(dataBase, input);
                }
                else
                {
                    string[] inputArgs = input.Split(new string[] { " -> " },
                        StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        string pokemonName = inputArgs[0];
                        string evolutionType = inputArgs[1];
                        long evolutionIndex = long.Parse(inputArgs[2]);
                        Evolution evolution = new Evolution();
                        evolution.evolutionIndex = evolutionIndex;
                        evolution.evolutionType = evolutionType;
                        List<Evolution> evolutionList = new List<Evolution>();
                        evolutionList.Add(evolution);

                        if (!dataBase.ContainsKey(pokemonName))
                        {
                            dataBase.Add(pokemonName, evolutionList);
                        }

                        else
                        {
                            dataBase[pokemonName].AddRange(evolutionList);
                        }
                    }

                    catch (Exception)
                    {

                    }
                }
            }

            PrintPokemon(dataBase);
        }

        private static void PrintPokemon(Dictionary<string, List<Evolution>> dataBase)
        {
            foreach (var poke in dataBase)
            {
                Console.WriteLine($"# {poke.Key}");
                foreach (var dataBaseValue in poke.Value.OrderByDescending(a => a.evolutionIndex))
                {
                    Console.WriteLine($"{dataBaseValue.evolutionType} <-> {dataBaseValue.evolutionIndex}");
                }
            }

        }
        private static void PrintCurrentPokemon(Dictionary<string, List<Evolution>> dataBase, string pokemon)
        {
            foreach (var poke in dataBase)
            {
                if (poke.Key == pokemon)
                {
                    Console.WriteLine($"# {poke.Key}");
                    foreach (var dataBaseValue in poke.Value)
                    {
                        Console.WriteLine($"{dataBaseValue.evolutionType} <-> {dataBaseValue.evolutionIndex}");
                    }
                }
            }

        }
    }

    class Evolution
    {
        public string evolutionType { get; set; }
        public long evolutionIndex { get; set; }
    }
}
