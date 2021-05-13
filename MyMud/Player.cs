using System.Collections.Generic;

namespace MyMud
{
    internal class Player
    {
        
        internal float playerMoney; // 플레이어의 돈
        int playerTotalMoney; // 플레이어의 코인 수익(코인 가격 * 수량) + 돈
        public List<Inventory> playerCoins = new List<Inventory>(); // 플레이어의 인벤토리
        

        public Player(float v)
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