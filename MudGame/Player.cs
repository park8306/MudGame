namespace MudGame
{
    internal class Player
    {
        public object playerRandomName;
        public int power;
        public int hp;

        public Player(string playerName, int power, int hp)
        {
            this.playerRandomName = playerName;
            this.power = power;
            this.hp = hp;
        }
    }
}