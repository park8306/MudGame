namespace MyMud
{
    public class Inventory
    {

        public CoinInfo playerCoinInfo;
        public int CoinCount;

        public Inventory()
        {

        }
        
        public Inventory(CoinInfo playerCoinInfo, int CoinCount)
        {
            this.playerCoinInfo = playerCoinInfo;
            this.CoinCount = CoinCount;
        }

    }
}