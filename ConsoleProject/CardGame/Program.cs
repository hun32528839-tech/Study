Card[] cards = new Card[52]; // Card 클래스의 52개의 인스턴스를 저장할 수 있는 배열 생성
Random random = new Random();

for (int i = 0; i < cards.Length; i++)
{
    cards[i] = new Card(); // cards[i]는 다 null이기 때문에 52개의 인스턴스를 초기화 해줌

    cards[i].SetCardNumber((i % 13) + 1);
    cards[i].SetSymbol((Symbol)(i / 13) + 1); // enum Symbol로 형변환해서 스페이드 13장 , 하트 ,13장 , 다이아몬드 13장 , 클로버 13장 생성
    
}

for (int i = 0; i < 100; i++)
{
    int firstRandomCard = random.Next(cards.Length);
    int secondRandomCard = random.Next(cards.Length);

    // Card 클래스 안에 있는 인스턴스들을 섞어줌
    Card temp = cards[firstRandomCard];
    cards[firstRandomCard] = cards[secondRandomCard];
    cards[secondRandomCard] = temp;
}

for (int i = 0; i < cards.Length - 2; i += 3) // 카드의 인덱스 초과 오류 때문에, cards.Length - 2 를 사용
{
    int minCard = cards[i].GetCardNumber() < cards[i + 1].GetCardNumber() ? cards[i].GetCardNumber() : cards[i + 1].GetCardNumber(); // 두 개의 카드 중 작은 카드를 가져오기 위해서
    int maxCard = cards[i].GetCardNumber() > cards[i + 1].GetCardNumber() ? cards[i].GetCardNumber() : cards[i + 1].GetCardNumber(); // 두 개의 카드 중 큰 카드를 가져오기 위해서

    int value = maxCard - minCard;
    
    Console.WriteLine("카드를 공개합니다.");
    Console.WriteLine();

    if (cards[i].GetCardNumber() <= cards[i + 1].GetCardNumber())
    {

        Console.Write("첫번째 카드");
        cards[i].Print();

        Console.WriteLine($"첫번째 카드 : {cards[i].GetSymbol()} {cards[i].GetCardNumber()}");
        Console.WriteLine($"두번째 카드 : {cards[i + 1].GetSymbol()} {cards[i + 1].GetCardNumber()}");
    }
    else
    {
        Console.WriteLine($"첫번째 카드 : {cards[i + 1].GetSymbol()} {cards[i + 1].GetCardNumber()}");
        Console.WriteLine($"두번째 카드 : {cards[i].GetSymbol()} {cards[i].GetCardNumber()}");
    }
      
    if (value == 0 || value == 1)
    {
        Console.WriteLine("다시 시작");
        Console.WriteLine();
        continue;
    }
  
    Console.WriteLine($"세번째 카드 : ???");
    Console.WriteLine();

    Console.WriteLine("1.베팅 2.포기");

    string playerNum = Console.ReadLine();

    if (int.TryParse(playerNum, out int result) == false) // 문자열로 잘못 입력 받았을 때
    {
        while (true)
        {
            Console.WriteLine("잘못된 입력입니다.");
            Console.WriteLine("다시 입력하세요.");
            Console.WriteLine();
            Console.WriteLine("1.베팅 2.포기");

            playerNum = Console.ReadLine();

            if (playerNum == "1" || playerNum == "2")
            {
                break;
            }
        }
    }

    if (int.TryParse(playerNum , out result))
    {
        if (result != 1 && result != 2)
        {
            while (true)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine("다시 입력하세요.");
                Console.WriteLine();
                Console.WriteLine("1.베팅 2.포기");

                playerNum = Console.ReadLine();

                if(int.TryParse(playerNum, out result))
                {
                    if(result == 1 || result == 2)
                    {
                        break;
                    }
                }                
            }
        }

        if (result == 1)
        {
            Console.WriteLine("베팅하셨습니다.");
            Console.WriteLine();
            Console.WriteLine("세번째 카드를 공개합니다.");
            Console.WriteLine($"세번째 카드 : {cards[i + 2].GetSymbol()} {cards[i + 2].GetCardNumber()}");
            Console.WriteLine();

            if (cards[i + 2].GetCardNumber() > minCard && cards[i + 2].GetCardNumber() < maxCard) // 그래야 세번째 카드에 사이에 있는 값인지를 조건으로 찾을수 있음
            {
                Console.WriteLine("베팅 성공");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("베팅 실패");
                Console.WriteLine();
            }
        }
        else if (result == 2)
        {
            Console.WriteLine("포기하셨습니다.");
            Console.WriteLine();
            Console.WriteLine("세번째 카드를 공개합니다.");
            Console.WriteLine($"세번째 카드 : {cards[i + 2].GetSymbol()} {cards[i + 2].GetCardNumber()}");
            Console.WriteLine();
            continue;
        }
    
    }    
}

