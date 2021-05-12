using System;
using System.Collections.Generic;

namespace MyMud
{
    enum MainMenu
    {
        코인시장확인,
        게임종료
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 게임 화면을 조정
            // 게임 준비 시작 화면
            // 아무키나 누르면 다음 화면으로 넘어가도록
            //Console.SetWindowSize(40, 20);
            StartScreen();
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

            // 게임이 반복되는 부분
            // 이제 메뉴가 들어간다.
            string selectedMenu;

            while (true)
            {
                Print("사용할 메뉴를 선택해주세요!");
                Print("1. 코인시장확인");
                Print("2. 게임 종료!");
                selectedMenu = Console.ReadLine();
                switch (selectedMenu)
                {
                    case "1":
                        while (true)
                        {
                            Console.Clear();
                            selectedMenu = "";
                            foreach (var item in coins)
                            {
                                Print(item.ToString());
                            }
                            Print("1. 코인 사기");
                            Print("2. 코인 팔기");
                            Print("3. 메인 화면");
                            selectedMenu = Console.ReadLine();
                            if (selectedMenu == "1")
                            {
                                break;
                            }
                            else if (selectedMenu == "2")
                            {
                                break;
                            }
                            else if (selectedMenu == "3")
                            {
                                break;
                            }
                            else
                            {
                                Print("올바른 메뉴를 입력해주세요!");
                            }
                            
                        }
                        break;
                    case "2":
                        break;


                }

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

        private static void StartScreen()
        {
            Print("CoinGame!!");
            Print("아무키나 눌러주세요");

            Console.ReadKey(true);
            Console.Clear();

        }

        private static void Print(string log)
        {
            Console.WriteLine(log);
        }
    }
}
