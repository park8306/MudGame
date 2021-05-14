namespace MyMud
{
    public class CoinInfo
    {
        public string CoinNumber;
        public string CoinName;
        public float CoinPrice;
        public int CoinCount;
        public CoinInfo(string CoinNumber, string CoinName, float CoinPrice, float CoinPercent)
        {
            this.CoinNumber = CoinNumber;
            this.CoinName = CoinName;
            this.CoinPrice = CoinPrice;
        }          

        public override string ToString()
        {
            return $"{CoinNumber}. 코인 이름 : {CoinName} 코인 가격 : {CoinPrice}";
        }
    }
}