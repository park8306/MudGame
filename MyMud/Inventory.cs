namespace MyMud
{
    public class Inventory
    {

        public CoinInfo playerCoinInfo;
        public int InventoryCoinCount;

        public Inventory()
        {

        }
        
        public Inventory(CoinInfo playerCoinInfo, int CoinCount)
        {
            this.playerCoinInfo = playerCoinInfo;
            this.InventoryCoinCount = CoinCount;
        }

    }
}