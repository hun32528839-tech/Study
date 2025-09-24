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

                PrintResult((BettingInput)result);
            }
        }

        void PrintResult(BettingInput input)
        {
            int playerTotalNum = 0;
            int bankerTotalNum = 0;
            switch (input)
            {
                case BettingInput.Player:
                    Console.WriteLine("Player에 베팅하셨습니다");
                    break;
                case BettingInput.Banker:
                    Console.WriteLine("Banker에 베팅하셨습니다");
                    break;
                case BettingInput.Draw:
                    Console.WriteLine("Draw에 베팅하셨습니다");
                    break;
            }


            Console.WriteLine();

            playerTotalNum += GetCardPoint(0, "Player");

            Console.WriteLine();

            bankerTotalNum += GetCardPoint(1, "Banker");

            Console.WriteLine();

            playerTotalNum += GetCardPoint(2, "Player");

            Console.WriteLine();

            bankerTotalNum += GetCardPoint(3, "Banker");

            Console.WriteLine();

            TotalNum(ref playerTotalNum, ref bankerTotalNum);

            Console.WriteLine($"PlayerTotalNum : {playerTotalNum} BankerTotalNum : {bankerTotalNum}");
            switch (input)
            {
                case BettingInput.Player:
                    PlayerBetting(playerTotalNum, bankerTotalNum);
                    break;
                case BettingInput.Banker:
                    BankerBetting(playerTotalNum, bankerTotalNum);
                    break;
                case BettingInput.Draw:
                    DrawBetting(playerTotalNum, bankerTotalNum);
                    break;
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
        int GetCardValue(Card card)
        {
            int num = card.GetCardNumber();
            return (num >= 10) ? 0 : num;
        }

        int GetCardPoint(int cardIndex , string owner)
        {
            Console.Write($"{owner}의 카드 ");
            cards[cardIndex].Print();
            return GetCardValue(cards[cardIndex]);
        }

    }
}

// ref - 변수의 참조(주소)를 전달해서, 함수 안에서 바꾸면 실제 변수 값이 바뀜
// ref는 함수 안에서 변수 값을 바꾸고, 그 바뀐 값을 함수 밖에서도 사용하고 싶을 때 필요

// 함수 목적	ref 필요 여부
// 값을 읽기만 함	❌ 필요 없음
// 값을 바꿔서 밖에서도 유지하고 싶음	✅ ref 필요함

// ref와 out의 차이
// ref와 out 모두 값을 참조로 전달
// ref 매개변수는 메서드 호출 전에 반드시 초기화되어야 함
// out - 초기화 안 해도 됨 (단, 메서드 내에서 반드시 값을 할당해야 함)
// out - 호출하는 쪽에서는 x, y를 초기화하지 않아도 됨
// out - ref와 달리 out은 호출 전 초기화하지 않아도 되지만, 메서드 내부에서 값을 할당하지 않으면 컴파일 에러가 남

// 예시)
// void ModifyRef(ref int a)
//{
//    a += 10;
//}

//void ModifyOut(out int b)
//{
//    b = 20;
//}

//int x = 5;
//int y;

//ModifyRef(ref x);  // x는 반드시 초기화 필요
//ModifyOut(out y);  // y는 초기화 불필요

//Console.WriteLine(x); // 출력: 15
//Console.WriteLine(y); // 출력: 20