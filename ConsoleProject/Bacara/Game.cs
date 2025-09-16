public enum BettingInput : int
{
    None = 0,

    Player,
    Banker,
    Draw
}

public class Game
{
    Card[] cards = new Card[52];
    Random random = new Random();

    public void Init()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i] = new Card();

            cards[i].SetCardSymbol((CardSymbol)(i / 13) + 1);
            cards[i].SetCardNumber((i % 13) + 1);
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < 100; i++)
        {
            int firstRandomCard = random.Next(cards.Length);
            int secondRandomCard = random.Next(cards.Length);

            Card temp = cards[firstRandomCard];
            cards[firstRandomCard] = cards[secondRandomCard];
            cards[secondRandomCard] = temp;
        }
    }

   

    public void Play()
    {
        int playerTotalNum = 0;
        int bankerTotalNum = 0;

        while (true)
        {           
            playerTotalNum = 0;
            bankerTotalNum = 0;

            Console.WriteLine("Baccarat Game Start");
            Console.WriteLine();
            Console.WriteLine("누가 승리할지 베팅을 시작하십시오");
            Console.WriteLine();
            Console.WriteLine("1.Player 2.Banker 3.Draw");

            string Input = Console.ReadLine();

            if (int.TryParse(Input , out int result) == false)
            {
                while (true)
                {
                    Console.WriteLine("잘못된 입력입니다");
                    Console.WriteLine("다시 입력하세요");

                    Input = Console.ReadLine();

                    if (int.TryParse(Input, out result))
                    {
                        if (result == 1 || result == 2 || result == 3)
                        {
                            break;
                        }
                    }
                }              
            }

            if (int.TryParse(Input , out result))
            {
                if (result != 1 && result != 2 && result != 3)
                {
                    while (true)
                    {
                        Console.WriteLine("잘못된 입력입니다");
                        Console.WriteLine("다시 입력하세요");

                        Input = Console.ReadLine();

                        if (int.TryParse(Input, out result))
                        {
                            if (result == 1 || result == 2 || result == 3)
                            {
                                break;
                            }
                        }
                    }
                }

                if (result == (int)BettingInput.Player)
                {
                    Console.WriteLine("Player에게 베팅하셨습니다");
                    Console.WriteLine();

                  
                    Console.Write("Player의 첫번째 카드 : ");
                    
                    cards[0].Print();

                    if (cards[0].GetCardNumber() >= 10 && cards[0].GetCardNumber() <= 13)
                    {
                        playerTotalNum += 0;
                    }
                    else
                    {
                        playerTotalNum += cards[0].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Banker의 첫번째 카드 : ");
                    cards[1].Print();

                    if (cards[1].GetCardNumber() >= 10 && cards[1].GetCardNumber() <= 13)
                    {
                        bankerTotalNum += 0;
                    }
                    else
                    {
                        bankerTotalNum += cards[1].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Player의 두번째 카드 : ");
                    cards[2].Print();

                    if (cards[2].GetCardNumber() >= 10 && cards[2].GetCardNumber() <= 13)
                    {
                        playerTotalNum += 0;
                    }
                    else
                    {
                        playerTotalNum += cards[2].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Banker의 두번째 카드 : ");
                    cards[3].Print();

                    if (cards[3].GetCardNumber() >= 10 && cards[3].GetCardNumber() <= 13)
                    {
                        bankerTotalNum += 0;
                    }
                    else
                    {
                        bankerTotalNum += cards[3].GetCardNumber();
                    }

                    Console.WriteLine();

                    TotalNum(ref playerTotalNum, ref bankerTotalNum);

                    Console.WriteLine($"PlayerTotalNum : {playerTotalNum} BankerTotalNum : {bankerTotalNum}");

                    PlayerBetting(playerTotalNum, bankerTotalNum);
                    break;                                      
                }                   
               
                else if (result == (int)BettingInput.Banker)
                {
                    Console.WriteLine("Banker에게 베팅하셨습니다");
                    Console.WriteLine();

                    Console.Write("Player의 첫번째 카드 : ");
                    cards[0].Print();
                    if (cards[0].GetCardNumber() >= 10 && cards[0].GetCardNumber() <= 13)
                    {
                        playerTotalNum += 0;
                    }
                    else
                    {
                        playerTotalNum += cards[0].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Banker의 첫번째 카드 : ");
                    cards[1].Print();

                    if (cards[1].GetCardNumber() >= 10 && cards[1].GetCardNumber() <= 13)
                    {
                        bankerTotalNum += 0;
                    }
                    else
                    {
                        bankerTotalNum += cards[1].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Player의 두번째 카드 : ");
                    cards[2].Print();

                    if (cards[2].GetCardNumber() >= 10 && cards[2].GetCardNumber() <= 13)
                    {
                        playerTotalNum += 0;
                    }
                    else
                    {
                        playerTotalNum += cards[2].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Banker의 두번째 카드 : ");
                    cards[3].Print();

                    if (cards[3].GetCardNumber() >= 10 && cards[3].GetCardNumber() <= 13)
                    {
                        bankerTotalNum += 0;
                    }
                    else
                    {
                        bankerTotalNum += cards[3].GetCardNumber();
                    }

                    Console.WriteLine();

                    TotalNum(ref playerTotalNum, ref bankerTotalNum);

                    Console.WriteLine($"PlayerTotalNum : {playerTotalNum} BankerTotalNum : {bankerTotalNum}");

                    BankerBetting(playerTotalNum, bankerTotalNum);
                    break;
                    
                }
            
                else if (result == (int)BettingInput.Draw)
                {
                    Console.WriteLine("Draw에 베팅하셨습니다");
                    Console.WriteLine();

                    Console.Write("Player의 첫번째 카드 : ");
                    cards[0].Print();
                    if (cards[0].GetCardNumber() >= 10 && cards[0].GetCardNumber() <= 13)
                    {
                        playerTotalNum += 0;
                    }
                    else
                    {
                        playerTotalNum += cards[0].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Banker의 첫번째 카드 : ");
                    cards[1].Print();

                    if (cards[1].GetCardNumber() >= 10 && cards[1].GetCardNumber() <= 13)
                    {
                        bankerTotalNum += 0;
                    }
                    else
                    {
                        bankerTotalNum += cards[1].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Player의 두번째 카드 : ");
                    cards[2].Print();

                    if (cards[2].GetCardNumber() >= 10 && cards[2].GetCardNumber() <= 13)
                    {
                        playerTotalNum += 0;
                    }
                    else
                    {
                        playerTotalNum += cards[2].GetCardNumber();
                    }

                    Console.WriteLine();
                    Console.Write("Banker의 두번째 카드 : ");
                    cards[3].Print();

                    if (cards[3].GetCardNumber() >= 10 && cards[3].GetCardNumber() <= 13)
                    {
                        bankerTotalNum += 0;
                    }
                    else
                    {
                        bankerTotalNum += cards[3].GetCardNumber();
                    }

                    Console.WriteLine();

                    TotalNum(ref playerTotalNum, ref bankerTotalNum);
                
                    Console.WriteLine($"PlayerTotalNum : {playerTotalNum} BankerTotalNum : {bankerTotalNum}");

                    DrawBetting(playerTotalNum, bankerTotalNum);
                    break;
                }               
            }
        }


        void TotalNum(ref int playerTotalNum, ref int bankerTotalNum)
        {
            if (playerTotalNum == 10)
            {
                playerTotalNum = 0;
            }
            if (playerTotalNum > 10)
            {
                playerTotalNum -= 10;
            }
            if (bankerTotalNum == 10)
            {
                bankerTotalNum = 0;
            }
            if (bankerTotalNum > 10)
            {
                bankerTotalNum -= 10;
            }
        }

        void PlayerBetting(int playerTotalNum, int bankerTotalNum)
        {
            int p = Math.Abs(playerTotalNum - 9);
            int b = Math.Abs(bankerTotalNum - 9);

            if (playerTotalNum == bankerTotalNum)
            {
                Console.WriteLine("무승부");
                Console.WriteLine("베팅에 실패하셨습니다");
            }
            else if (playerTotalNum == 9 && bankerTotalNum < 9)
            {
                Console.WriteLine("Player 승");
                Console.WriteLine("베팅에 성공하셨습니다");
            }
            else if (bankerTotalNum == 9 && playerTotalNum < 9)
            {
                Console.WriteLine("Banker 승");
                Console.WriteLine("베팅에 실패하셨습니다");
            }
            else if (p < b)
            {
                Console.WriteLine("Player 승");
                Console.WriteLine("베팅에 성공하셨습니다");
            }
            else if (b < p)
            {
                Console.WriteLine("Banker 승");
                Console.WriteLine("베팅에 실패하셨습니다");
            }
        }

        void BankerBetting(int playerTotalNum , int bankerTotalNum)
        {
            int p = Math.Abs(playerTotalNum - 9);
            int b = Math.Abs(bankerTotalNum - 9);

            if (playerTotalNum == bankerTotalNum)
            {
                Console.WriteLine("무승부");
                Console.WriteLine("베팅에 실패하셨습니다");                
            }
            else if (playerTotalNum == 9 && bankerTotalNum < 9)
            {
                Console.WriteLine("Player 승");
                Console.WriteLine("베팅에 실패하셨습니다");                
            }
            else if (bankerTotalNum == 9 && playerTotalNum < 9)
            {
                Console.WriteLine("Banker 승");
                Console.WriteLine("베팅에 성공하셨습니다");               
            }
            else if (p < b)
            {
                Console.WriteLine("Player 승");
                Console.WriteLine("베팅에 실패하셨습니다");                
            }
            else if (b < p)
            {
                Console.WriteLine("Banker 승");
                Console.WriteLine("베팅에 성공하셨습니다");              
            }
        }

        void DrawBetting(int playerTotalNum, int bankerTotalNum)
        {            
            int p = Math.Abs(playerTotalNum - 9);
            int b = Math.Abs(bankerTotalNum - 9);

            if (playerTotalNum == bankerTotalNum)
            {
                Console.WriteLine("무승부");
                Console.WriteLine("베팅에 성공하셨습니다");
                
            }
            else if (playerTotalNum == 9 && bankerTotalNum < 9)
            {
                Console.WriteLine("Player 승");
                Console.WriteLine("베팅에 실패하셨습니다");
               
            }
            else if (bankerTotalNum == 9 && playerTotalNum < 9)
            {
                Console.WriteLine("Banker 승");
                Console.WriteLine("베팅에 실패하셨습니다");
                
            }
            else if (p < b)
            {
                Console.WriteLine("Player 승");
                Console.WriteLine("베팅에 실패하셨습니다");
                
            }
            else if (b < p)
            {
                Console.WriteLine("Banker 승");
                Console.WriteLine("베팅에 실패하셨습니다");
                
            }
        }

        void CardValue(Card card)
        {
            int num = card.GetCardNumber();
            num = num >= 10 ? 0 : num;
        }
    }   
}

// ref - 변수의 참조(주소)를 전달해서, 함수 안에서 바꾸면 실제 변수 값이 바뀜
// ref는 함수 안에서 변수 값을 바꾸고, 그 바뀐 값을 함수 밖에서도 사용하고 싶을 때 필요

// 함수 목적	ref 필요 여부
// 값을 읽기만 함	❌ 필요 없음
// 값을 바꿔서 밖에서도 유지하고 싶음	✅ ref 필요함