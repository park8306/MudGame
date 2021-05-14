namespace MyMud
{
    public class CoinInfo
    {
        public string CoinNumber;
        public string CoinName;
        public float CoinPrice;
        public float CoinPercent;
        public int CoinCount;
        public CoinInfo(string CoinNumber, string CoinName, float CoinPrice, float CoinPercent)
        {
            this.CoinNumber = CoinNumber;
            this.CoinName = CoinName;
            this.CoinPrice = CoinPrice;
            this.CoinPercent = CoinPercent;
        }          

        public override string ToString()
        {
            return $"{CoinNumber}. 코인 이름 : {CoinName} 코인 가격 : {CoinPrice} 전날 증감율 : {CoinPercent}";
        }
    }
}