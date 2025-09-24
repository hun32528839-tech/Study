using System;
using System.Text.Json.Nodes;

Card[] cards1 = new Card[52]; // 카드1 배열 52장 인스턴스 생성
Card[] cards2 = new Card[52]; // 카드2 배열 52장 인스턴스 생성
Random random = new Random();

for (int i = 0; i < cards1.Length; i++) // 카드1 초기화 
{
    cards1[i] = new Card();
    cards1[i].SetSymbol((Symbol)(i / 13) + 1); // 카드의 문양을 enum으로 만들어서 13장씩 계산
   
    if (i % 13 + 1 >= 10)
    {
        cards1[i].SetCardNumber(10);
    }
    else
    {
        cards1[i].SetCardNumber((i % 13) + 1); // 카드의 숫자를 계산
    }
}

for(int i = 0; i < cards2.Length; i++) // 카드2 초기화
{
    cards2[i] = new Card();
    cards2[i].SetSymbol((Symbol)(i / 13) + 1);

    if (i % 13 + 1 >= 10)
    {
        cards2[i].SetCardNumber(10);
    }
    else
    {
        cards2[i].SetCardNumber((i % 13) + 1);
    }
}

for (int i = 0; i < 100; i++) // 카드를 무작위로 100번 섞어서 사용
{
    int firstRandomCard = random.Next(cards1.Length);
    int secondRandomCard = random.Next(cards1.Length);

    Card temp = cards1[firstRandomCard];
    cards1[firstRandomCard] = cards1[secondRandomCard];
    cards1[secondRandomCard] = temp;
}

for (int i = 0; i < 100; i++)
{
    int firstRandomCard = random.Next(cards2.Length);
    int secondRandomCard = random.Next(cards2.Length);

    Card temp = cards2[firstRandomCard];
    cards2[firstRandomCard] = cards2[secondRandomCard];
    cards2[secondRandomCard] = temp;
}

int dealerIndex = 0;
int playerIndex = 0;
int dealerTotalNum = 0;
int playerTotalNum = 0;



// 딜러의 인덱스를 처리하는 구간
while (dealerIndex + 4 < cards1.Length) // 게임 한판에 들어가는 카드의 최소 갯수가 4장이기 때문에 index + 4로 작성
{
    dealerTotalNum = 0;
    playerTotalNum = 0;

    Console.WriteLine("BlackJack Start.");
    Console.WriteLine();

    cards1[dealerIndex].Print();

    if (cards1[dealerIndex].GetCardNumber() == 1)
    {
        dealerTotalNum += 11;
    }
    else
    {
        dealerTotalNum += cards1[dealerIndex].GetCardNumber();
    }
    dealerIndex++;
    Console.WriteLine($"Dealer Card : ???");
    Console.WriteLine();


    // 플레이어의 인덱스를 처리
    cards2[playerIndex].Print();

    if (cards2[playerIndex].GetCardNumber() == 1)
    {
        playerTotalNum += 11;
    }
    else
    {
        playerTotalNum += cards2[playerIndex].GetCardNumber();
    }
    playerIndex++;
    cards2[playerIndex].Print();

    if (cards2[playerIndex].GetCardNumber() == 1)
    {
        playerTotalNum += 11;
    }
    else
    {
        playerTotalNum += cards2[playerIndex].GetCardNumber();
    }
    playerIndex++;
    if (cards2[playerIndex - 2].GetCardNumber() == 1 && cards2[playerIndex - 1].GetCardNumber() == 1)
    {
        playerTotalNum -= 10;
    }
    Console.WriteLine();
    
    while (true)
    {
        Console.WriteLine("1. Add Card 2. Stop");

        string playerNum = Console.ReadLine();

        if (int.TryParse(playerNum, out int result) == false)
        {
            while (true)
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine();
                Console.WriteLine("Again Input");

                Console.WriteLine("1. Add Card 2. Stop");

                playerNum = Console.ReadLine();

                if (playerNum == "1" || playerNum == "2")
                {
                    break;
                }
            }
        }

        if (int.TryParse(playerNum, out result))
        {
            if (result != 1 && result != 2)
            {
                while (true)
                {
                    Console.WriteLine("Wrong Input");
                    Console.WriteLine();
                    Console.WriteLine("Again Input");

                    Console.WriteLine("1. Add Card 2. Stop");

                    playerNum = Console.ReadLine();

                    if (int.TryParse(playerNum, out result))
                    {
                        if (result == 1 || result == 2)
                        {
                            break;
                        }
                    }
                }
            }

            if (result == 1)
            {
                Console.WriteLine("Add Card");
                cards2[playerIndex].Print();
                playerTotalNum += cards2[playerIndex].GetCardNumber();
                if (cards2[playerIndex - 2].GetCardNumber() == 1 || cards2[playerIndex - 1].GetCardNumber() == 1 && playerTotalNum > 21)
                {
                    playerTotalNum -= 10;
                }
                playerIndex++;
                Console.WriteLine();
                Console.WriteLine($"playerTotalNum : {playerTotalNum}");
                Console.WriteLine();
            }
            else if (result == 2)
            {
                Console.WriteLine("Stop");

                Console.WriteLine();
                Console.WriteLine("Dealer Turn");

                cards1[dealerIndex].Print();

                if (cards1[dealerIndex - 1].GetCardNumber() != 1 && cards1[dealerIndex].GetCardNumber() == 1)
                {
                    dealerTotalNum += 11;
                }
                else
                {
                    dealerTotalNum += cards1[dealerIndex].GetCardNumber();
                }
                dealerIndex++;
                Console.WriteLine();
                Console.WriteLine($"Player TotalNumber Card : {playerTotalNum} Dealer TotalNumber Card : {dealerTotalNum}");
                Console.WriteLine();

                while (dealerTotalNum <= 17)
                {
                    Console.Write("Dealer Add Card ");
                    cards1[dealerIndex].Print();
                    dealerTotalNum += cards1[dealerIndex].GetCardNumber();
                    if (cards1[dealerIndex - 2].GetCardNumber() == 1 || cards1[dealerIndex - 1].GetCardNumber() == 1 || cards2[dealerIndex].GetCardNumber() == 1 && dealerTotalNum > 21)
                    {
                        dealerTotalNum -= 10;
                        break;
                    }
                    dealerIndex++;
                    Console.WriteLine();                   
                }

                Console.WriteLine($"Player TotalNumber Card : {playerTotalNum} Dealer TotalNumber Card : {dealerTotalNum}");

                if (playerTotalNum == dealerTotalNum || playerTotalNum > 21 && dealerTotalNum > 21)
                {
                    Console.WriteLine("Draw");
                    Console.WriteLine();
                }
                else if (playerTotalNum < 21 && dealerTotalNum > 21)
                {
                    Console.WriteLine("Player Win");
                    Console.WriteLine();
                }
                else if (playerTotalNum > 21 && dealerTotalNum < 21)
                {
                    Console.WriteLine("Dealer Win");
                    Console.WriteLine();
                }
                else if (playerTotalNum < 21 && dealerTotalNum == 21)
                {
                    Console.WriteLine("Wow!!! Black Jack!!!!!!!!!!!!");
                    Console.WriteLine("Dealer Win");
                    Console.WriteLine();
                }
                else if (playerTotalNum == 21 && dealerTotalNum < 21)
                {
                    Console.WriteLine("Wow!!! Black Jack!!!!!!!!!!!!");
                    Console.WriteLine("Player Win");
                    Console.WriteLine();
                }
                else if (playerTotalNum > 21 && dealerTotalNum == 21)
                {
                    Console.WriteLine("Wow!!! Black Jack!!!!!!!!!!!!");
                    Console.WriteLine("Dealer Win");
                    Console.WriteLine();
                }
                else if (playerTotalNum == 21 && dealerTotalNum > 21)
                {
                    Console.WriteLine("Wow!!! Black Jack!!!!!!!!!!!!");
                    Console.WriteLine("Player Win");
                    Console.WriteLine();
                }
                else if (playerTotalNum < 21 && dealerTotalNum < 21)
                {
                    int p = Math.Abs(playerTotalNum - 21);
                    int d = Math.Abs(dealerTotalNum - 21);

                    if (p < d)
                    {
                        Console.WriteLine("Player Win");
                        Console.WriteLine();
                    }
                    else if (d < p)
                    {
                        Console.WriteLine("Dealer Win");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Draw");
                        Console.WriteLine();
                    }
                }
                break;

            }
        }
    }
}
    

  




// A(에이스) 1 또는 11로 사용 가능
// 10, J, Q, K	전부 10으로 취급
// 10 , 23, 36, 49 (11)