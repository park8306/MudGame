using System.Collections.Generic;

namespace MyMud
{
    internal class Player
    {
        internal int playerMoney;
        public List<CoinInfo> playerCoins = new List<CoinInfo>();

        public Player(int v)
        {
            this.playerMoney = v;
        }

        public override string ToString()
        {

            string playerInfo = $"플레이어의 금액 : {playerMoney}";
            return playerInfo;
        }
    }
}