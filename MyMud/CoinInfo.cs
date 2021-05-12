namespace MyMud
{
    public class CoinInfo
    {
        public string CoinName;
        public float CoinPrice;
        public float CoinPercent;
        public int CoinCount;
        public CoinInfo(string CoinName, float CoinPrice, float CoinPercent)
        {
            this.CoinName = CoinName;
            this.CoinPrice = CoinPrice;
            this.CoinPercent = CoinPercent;
        }          

        public override string ToString()
        {
            return $"코인 이름 : {CoinName} 코인 가격 : {CoinPrice} 전날 증감율 : {CoinPercent}";
        }
    }
}