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
            // 기본 금액을 1만원으로 결정
            Player player = new Player(100000);

            // 코인에 들어가야할 정보
            // 코인의 이름
            // 코인의 가격
            // 코인의 배율(코인의 값이 높아질지 낮아질지 결정해주는 요소)
            // 처음의 배율은 0으로 정해준다. 나중에 랜덤으로 지정해줄 예정

            List<CoinInfo> coins = new List<CoinInfo> {
                new CoinInfo("1", "미더리움", 1000.0f, 0.0f),
                new CoinInfo("2", "미러코인", 1500.0f, 0.0f),
                new CoinInfo("3", "러플코인", 3000.0f, 0.0f),
                new CoinInfo("4", "실라코인", 1200.0f, 0.0f)
            };

            // 게임이 반복되는 부분
            // 이제 메뉴가 들어간다.
            bool isContinue = true; // 메인 화면을 반복하려는 변수
            string selectedMenu;    // 메뉴들의 선택을 받는 변수
            int indexNumber;    // 사용자가 선택한 번호 인덱스를 저장할 변수
            int Count;
            // 메인 메뉴
            while (isContinue)
            {
                Console.Clear();
                Print("-----------------------------------------------");
                Print("1. 코인시장확인");
                Print("2. 다음날로 넘어가기 (코인의 값이 변합니다)");
                Print("3. 게임 종료!");
                Console.Write("번호를 선택해주세요 : ");
                
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
                            float totalMoney = 0;
                            // 만약 코인을 가지고 있다면 출력
                            if (player.isPlayerCoin)
                            {
                                for (int i = 0; i < player.playerCoins.Count; i++)
                                {
                                    Print($"\n보유한 코인 : {player.playerCoins[i].playerCoinInfo.CoinName} X {player.playerCoins[i].InventoryCoinCount} ");
                                    totalMoney += player.playerCoins[i].playerCoinInfo.CoinPrice * player.playerCoins[i].InventoryCoinCount;
                                }
                                totalMoney += player.playerMoney;
                            }
                            else
                            {
                                totalMoney = player.playerMoney;
                                Print("\n아직 보유한 코인이 없습니다!");
                            }

                            Print($"\n플레이어의 총 재산: {totalMoney}");
                            Print("\n");

                            // 메뉴 정보
                            Print("5. 코인 팔기");
                            Print("6. 메인 화면");
                            Console.Write("사고싶은 코인의 번호 선택 혹은 메뉴를 선택해주세요! :");
                            selectedMenu = Console.ReadLine();

                            
                            
                            if (selectedMenu == "1" || selectedMenu == "2" || selectedMenu == "3" || selectedMenu == "4")
                            {
                                indexNumber = int.Parse(selectedMenu) - 1;
                                selectedMenu = "";

                                Console.Write("\n구입할 코인의 갯수를 입력해주세요 : ");
                                selectedMenu = Console.ReadLine();
                                Count = int.Parse(selectedMenu);
                                // 플레이어가 고른 코인의 정보를 넣어준다.
                                float price = coins[indexNumber].CoinPrice * Count;
                                // 만약 플레이어머니 > (해당 코인 * 수량) 라면 코인을 산다.
                                Print($"\n{coins[indexNumber].CoinName} X {Count}의 가격은 {price}입니다.\n");
                                Console.Write("구입하시겠습니까? 구입하려면 y키를 눌러주세요 : ");
                                selectedMenu = Console.ReadLine();
                                if(selectedMenu.ToLower() == "y")
                                {
                                    if (player.playerMoney >= price)
                                    {
                                        player.playerMoney -= price;
                                        player.playerCoins.Add(new Inventory(coins[indexNumber], Count));
                                        player.isPlayerCoin = true;
                                        Print("\n구입되었습니다!");
                                        Print("\n아무키나 눌러주세요!");
                                        Console.ReadKey(true);
                                    }
                                    else
                                    {
                                        Print("소지금이 부족하여 코인을 구입할 수 없습니다!");
                                        Print("아무키나 눌러주세요!");
                                        Console.ReadKey(true);
                                    }
                                }

                                selectedMenu = "";
                                //player.playerCoins.Add()
                                // 인벤토리 클래스를 하나 만들어서 코인정보와 코인 수를 저장할 수 있도록함
                                // 그걸 플레이어 클래스에 적용하여 플레이어의 인벤토리를 생성
                            }
                            // 코인팔기 기능
                            else if (selectedMenu == "5")
                            {
                                Console.Clear();
                                if (player.playerCoins != null)
                                {
                                    // 보유한 코인의 정보를 보여줌
                                    for (int i = 0; i < player.playerCoins.Count; i++)
                                    {
                                        Print($"보유한 코인 {i+1} : {player.playerCoins[i].playerCoinInfo.CoinName} X {player.playerCoins[i].InventoryCoinCount} ");
                                    }

                                    Console.Write("판매할 코인의 번호를 입력해주세요 : ");
                                    selectedMenu = Console.ReadLine();
                                    indexNumber = int.Parse(selectedMenu) -1;
                                    Console.Write("판매할 수를 입력해주세요 : ");
                                    selectedMenu = Console.ReadLine();
                                    Count = int.Parse(selectedMenu);

                                    //코인을 얼마나 팔것인지
                                    // 선택한 코인의 카운트 수를 플레이어가 입력한 수만큼 감소하고 해당 코인이 수량이 0개가 되면 삭제를 시켜준다.
                                    if(Count > 0 && player.playerCoins[indexNumber].InventoryCoinCount >= Count)
                                    {
                                        // 판매한 금액만큼 플레이어의 머니에 추가한다.
                                        player.playerMoney += player.playerCoins[indexNumber].playerCoinInfo.CoinPrice * Count;
                                        player.playerCoins[indexNumber].InventoryCoinCount -= Count;
                                        // 플레이어의 코인 갯수가 0이되면 해당 코인을 삭제해준다.
                                        if(player.playerCoins[indexNumber].InventoryCoinCount <= 0)
                                        {
                                            player.playerCoins.RemoveAt(indexNumber);
                                            for (int i = 0; i < player.playerCoins.Count; i++)
                                            {
                                                player.playerCoins[i].playerCoinInfo.CoinNumber = (i + 1).ToString();
                                            }
                                        }
                                    }
                                    if (player.playerCoins.Count == 0)
                                    {
                                        player.isPlayerCoin = false;
                                    }
                                }
                                //else
                                //{
                                //    Print("가지고 있는 코인이 없습니다!");
                                //    Print("아무키나 눌러주세요!");
                                //    Console.ReadKey(true);
                                //    break;
                                //}
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
                        // 코인 배율을 랜덤으로 변경해준다.
                        foreach (var item in coins)
                        {
                            
                            float a;
                            int b = new Random().Next(1, 11);
                            int c = new Random().Next(0, 2);
                            a = b / 10.0f;
                            if (b <= 3)
                            {
                                if(c == 0)
                                {
                                    
                                    item.CoinPrice += item.CoinPrice * a;
                                }
                                else if(c == 1)
                                {
                                    
                                    item.CoinPrice -= item.CoinPrice * a;
                                }
                            }
                            else if(b == 7 || b==8) // 70~80로 크게 떨어지는 확률은 20퍼
                            {
                                if (c == 0)
                                {

                                    item.CoinPrice += item.CoinPrice * a;
                                }
                                else if (c == 1)
                                {

                                    item.CoinPrice -= item.CoinPrice * a;
                                }
                            }
                            else
                            {
                                item.CoinPrice += 100;
                            }
                            
                        }
                        
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
