using System;
using System.Collections.Generic;

namespace MyMud
{
    class Program
    {
        static void Main(string[] args)
        {
            // 게임 화면을 조정
            // 게임 준비 시작 화면
            // 아무키나 누르면 다음 화면으로 넘어가도록
            //Console.SetWindowSize(40, 20);
            Print("CoinGame!!");
            Print("아무키나 눌러주세요");

            Console.ReadKey(true);
            Console.Clear();
            //Console.SetWindowSize(50, 20);
            Print("게임 화면");
            // 유저 생성
            // 기본 금액을 10만원으로 결정
            Player player = new Player(100000);

            // 코인에 들어가야할 정보
            // 코인의 이름
            // 코인의 가격
            // 코인의 배율(코인의 값이 높아질지 낮아질지 결정해주는 요소)
            // 처음의 배율은 0으로 정해준다. 나중에 랜덤으로 지정해줄 예정
            
            List<CoinInfo> coins = new List<CoinInfo> { 
                new CoinInfo("도장코인", 100.0f, 0.0f),
                new CoinInfo("미로코인", 150.0f, 0.0f),
                new CoinInfo("러플코인", 300.0f, 0.0f),
                new CoinInfo("실라코인", 1000.0f, 0.0f)
            };


            while(true)
            {
                // 코인의 정보를 출력
                foreach (var item in coins)
                {
                    Print(item.ToString());
                }

                Print("\n");
                // 플레이어의 정보를 출력
                Print(player.ToString());
                if (player.playerCoins != null)
                {
                    foreach (var item in player.playerCoins)
                    {
                        Print($"보유한 코인 : {item.CoinName} X {item.CoinCount} ");
                    }
                }
            } 
            
        }

        private static void Print(string log)
        {
            Console.WriteLine(log);
        }
    }
}
