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
                new CoinInfo("1", "도장코인", 100.0f, 0.0f),
                new CoinInfo("2", "미로코인", 150.0f, 0.0f),
                new CoinInfo("3", "러플코인", 300.0f, 0.0f),
                new CoinInfo("4", "실라코인", 1000.0f, 0.0f)
            };

            // 게임이 반복되는 부분
            // 이제 메뉴가 들어간다.
            bool isContinue = true; // 메인 화면을 반복하려는 변수
            string selectedMenu;    // 메뉴들의 선택을 받는 변수
            int indexNumber;    // 인덱서를 저장할 변수
            // 메인 메뉴
            while (isContinue)
            {
                Console.Clear();
                Print("사용할 메뉴를 선택해주세요!");
                Print("1. 코인시장확인");
                Print("2. 다음날로 넘어가기");
                Print("3. 게임 종료!");
                // 메뉴 번호 선택을 받음
                selectedMenu = Console.ReadLine();
                // 세부메뉴
                switch (selectedMenu)
                {
                    // 코인 시장 메뉴
                    case "1":
                        while (true)
                        {
                            // 코인 정보와 플레이어의 정보가 출력된다.
                            Console.Clear();
                            selectedMenu = "";

                            // 코인 정보
                            foreach (var item in coins)
                            {
                                Print(item.ToString());
                            }
                            Print("\n");
                            // 플레이어 정보
                            Print(player.ToString());
                            Print("\n");

                            // 만약 코인을 가지고 있다면 출력
                            if (player.playerCoins != null)
                            {
                                for (int i = 0; i < player.playerCoins.Count; i++)
                                {
                                    Print($"보유한 코인 : {player.playerCoins[i].playerCoinInfo.CoinName} X {player.playerCoins[i].CoinCount} ");
                                }
                                //foreach (Inventory item in player.playerCoins)
                                //{
                                //    Print($"보유한 코인 : {item.playerCoinInfo.CoinName} X {item.CoinCount} ");
                                //}
                            }
                            Print("\n");

                            // 메뉴 정보
                            Print("5. 코인 팔기");
                            Print("6. 메인 화면");
                            Console.Write("사고싶은 코인의 번호 선택 혹은 메뉴를 선택해주세요! :");
                            selectedMenu = Console.ReadLine();

                            // 메뉴 선택 시 기능
                            // 
                            // 2. 플레이어의 코인 정보를 보여주고 팔 수 있도록하는 메뉴
                            // 코인의 종류를 고르면 코인을 얼마나 팔 것인지 선택하게 한다.
                            // 3. 메인화면으로 돌아가는 메뉴
                            
                            if (selectedMenu == "1" || selectedMenu == "2" || selectedMenu == "3" || selectedMenu == "4")
                            {
                                indexNumber = int.Parse(selectedMenu) - 1;
                                selectedMenu = "";

                                Console.Write("구입할 코인의 갯수를 입력해주세요 : ");
                                selectedMenu = Console.ReadLine();
                                // 플레이어가 고른 코인의 정보를 넣어준다.
                                //selectedCoin.playerCoinInfo = coins[indexNumber];
                                //selectedCoin.CoinCount = int.Parse(selectedMenu);

                                player.playerCoins.Add(new Inventory(coins[indexNumber], int.Parse(selectedMenu)));

                                selectedMenu = "";
                                //player.playerCoins.Add()
                                // 인벤토리 클래스를 하나 만들어서 코인정보와 코인 수를 저장할 수 있도록함
                                // 그걸 플레이어 클래스에 적용하여 플레이어의 인벤토리를 생성
                                break;
                            }
                            // 코인팔기 기능
                            else if (selectedMenu == "5")
                            {
                                break;
                            }
                            else if (selectedMenu == "6")
                            {
                                break;
                            }
                            else
                            {
                                Print("올바른 메뉴를 입력해주세요!");
                                Print("아무키나 누르면 코인시장으로 다시 돌아갑니다.");
                                Console.ReadKey(true);
                            }
                            
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        isContinue = false;
                        break;
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
