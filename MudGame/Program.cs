using System.Collections.Generic;
using System;

namespace MudGame
{
    class Program
    {
        private static object playerRandomName;

        static void Main(string[] args)
        {
            Console.WriteLine("유저님 환영합니다!");

            

            List<string> names = new List<String>();

            names.Add("동환");
            names.Add("명수");
            names.Add("성운");
            names.Add("성현");
            names.Add("찬선");

            Random random = new Random();

            int index = random.Next(names.Count);
            string playerName = names[index];

            string powerString = Console.ReadLine();
            string hpString = Console.ReadLine();

            int power = int.Parse(powerString);
            int hp = int.Parse(hpString);

            Player player = new Player(playerName, power, hp);

            Monster monster = new Monster();

            monster.hp -= player.power;
        }

        private static string SetRandomPlayerName()
        {
            throw new NotImplementedException();
        }
    }
}
