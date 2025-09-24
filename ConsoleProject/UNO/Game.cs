using System.Diagnostics;
using System.Drawing;
using System.Reflection;
// typeof - "타입 정보"가 필요한 작업을 할 때
// is는 객체가 어떤 타입인지 검사할 때 사용하는 C#의 키워드
// if (deck[i] is WildCard wildCard) // deck[i]에 wildcard 가 나오면 카드타입이 wildcard 타입이라서 true
public class Game
{
    List<Card> deck = new List<Card>();
    
    Random random = new Random();

    List<Card> playerCards = new List<Card>();
    List<Card> computerCards = new List<Card>();

    public void InitCardDeck()
    {
        for (int i = 0; i <= 4; i++)
        {
            if (i == 0)
            {
                deck.Add(new NumberCard(CardColor.Red, i));
                deck.Add(new NumberCard(CardColor.Yellow, i));
                deck.Add(new NumberCard(CardColor.Green, i));
                deck.Add(new NumberCard(CardColor.Blue, i));
            }

            for (int j = 1; j <= 9; j++)
            {
                if (i == 1)
                {
                    deck.Add(new NumberCard(CardColor.Red, j));
                    deck.Add(new NumberCard(CardColor.Red, j));
                }
                else if (i == 2)
                {
                    deck.Add(new NumberCard(CardColor.Yellow, j));
                    deck.Add(new NumberCard(CardColor.Yellow, j));
                }
                else if (i == 3)
                {
                    deck.Add(new NumberCard(CardColor.Green, j));
                    deck.Add(new NumberCard(CardColor.Green, j));
                }

                else if (i == 4)
                {
                    deck.Add(new NumberCard(CardColor.Blue, j));
                    deck.Add(new NumberCard(CardColor.Blue, j));
                }
            }               
        }

        for (int i = 0; i <= 3; i++)
        {
            if (i == 0)
            {
                deck.Add(new SpecialCard(CardColor.Red, SpecialCardType.Skip));
                deck.Add(new SpecialCard(CardColor.Red, SpecialCardType.Skip));
                deck.Add(new SpecialCard(CardColor.Red, SpecialCardType.Reverse));
                deck.Add(new SpecialCard(CardColor.Red, SpecialCardType.Reverse));
                deck.Add(new SpecialCard(CardColor.Red, SpecialCardType.DrawTwo));
                deck.Add(new SpecialCard(CardColor.Red, SpecialCardType.DrawTwo));
            }
            else if (i == 1)
            {
                deck.Add(new SpecialCard(CardColor.Yellow, SpecialCardType.Skip));
                deck.Add(new SpecialCard(CardColor.Yellow, SpecialCardType.Skip));
                deck.Add(new SpecialCard(CardColor.Yellow, SpecialCardType.Reverse));
                deck.Add(new SpecialCard(CardColor.Yellow, SpecialCardType.Reverse));
                deck.Add(new SpecialCard(CardColor.Yellow, SpecialCardType.DrawTwo));
                deck.Add(new SpecialCard(CardColor.Yellow, SpecialCardType.DrawTwo));
            }
            else if (i == 2)
            {
                deck.Add(new SpecialCard(CardColor.Green, SpecialCardType.Skip));
                deck.Add(new SpecialCard(CardColor.Green, SpecialCardType.Skip));
                deck.Add(new SpecialCard(CardColor.Green, SpecialCardType.Reverse));
                deck.Add(new SpecialCard(CardColor.Green, SpecialCardType.Reverse));
                deck.Add(new SpecialCard(CardColor.Green, SpecialCardType.DrawTwo));
                deck.Add(new SpecialCard(CardColor.Green, SpecialCardType.DrawTwo));
            }
            else if (i == 3)
            {
                deck.Add(new SpecialCard(CardColor.Blue, SpecialCardType.Skip));
                deck.Add(new SpecialCard(CardColor.Blue, SpecialCardType.Skip));
                deck.Add(new SpecialCard(CardColor.Blue, SpecialCardType.Reverse));
                deck.Add(new SpecialCard(CardColor.Blue, SpecialCardType.Reverse));
                deck.Add(new SpecialCard(CardColor.Blue, SpecialCardType.DrawTwo));
                deck.Add(new SpecialCard(CardColor.Blue, SpecialCardType.DrawTwo));
            }
        }

      
        deck.Add(new WildCard(WildCardType.Wild));
        deck.Add(new WildCard(WildCardType.Wild));
        deck.Add(new WildCard(WildCardType.Wild));
        deck.Add(new WildCard(WildCardType.Wild));

        deck.Add(new WildCard(WildCardType.WildDrawFour));
        deck.Add(new WildCard(WildCardType.WildDrawFour));
        deck.Add(new WildCard(WildCardType.WildDrawFour));
        deck.Add(new WildCard(WildCardType.WildDrawFour));          
    }    

    public void Shuffle()
    {
        for (int i = 0; i < 50; i++)
        {
            int firstCard = random.Next(deck.Count);
            int secondCard = random.Next(deck.Count);

            Card temp = deck[firstCard];
            deck[firstCard] = deck[secondCard];
            deck[secondCard] = temp;
        }
        //for (int i = 0; i < deck.Count; i++)
        //{
        //    Console.WriteLine(deck[i].GetPrintCard());
        //}
    }
    PlayerType currentTurn = PlayerType.Player;
    int turnDirection = 1;
    public void Play()
    {
        Console.WriteLine("UNO Start");

        for (int i = 0; i < 7; i++)
        {
            playerCards.Add(deck[0]);

            deck.RemoveAt(0);
        }

        for (int i = 0; i < 7; i++)
        {
            computerCards.Add(deck[0]);
            deck.RemoveAt(0);
        }

        
        Console.WriteLine($"시작 카드 : {deck[0].GetPrintCard()}");

        if (deck[0] is SpecialCard specialCard)
        {
            deck[0].PlayEffect(this); // this는 현재 클래스 인스턴스 자신을 의미. 나 자신 Game 클래스
        }
        
        else if (deck[0] is WildCard wildCard)
        {
            deck[0].PlayEffect(this);
        }

        while (true)
        {
            Console.WriteLine($"현재 플레이 할 플레이어는 {currentTurn} 입니다.");
            
            for (int i = 0; i < playerCards.Count; i++)
            {
                
                if (playerCards[i].CardColor == deck[0].CardColor || playerCards[i].) // 숫자카드를 비교해야 해서 숫자를 가져와야 하는데...
            }
        }
        
    }

    // SpecialCard or WildCard 들이 알아서 기능 역할을 하게끔 설계
   
    public void NextTurn()
    {
        int next = ((int)currentTurn + turnDirection + 2) % 2; // 2는 플레이어 수
        currentTurn = (PlayerType)next;
    }
    public void SkipNextTurn()
    {
        NextTurn();
        NextTurn();
    }
    public void ReverseTurnOrder()
    {
        turnDirection = -turnDirection; // - 부호 = 변수나 숫자의 부호를 반전시키는 역할도 함

    }
    public void DrawCardToOther(int count)
    {
        PlayerType otherPlayer = (PlayerType)(1 - (int)currentTurn);

        for (int i = 0; i < count; i++)
        {
            if (deck.Count > 0)
            {
                if (otherPlayer == PlayerType.Player)
                {
                    playerCards.Add(deck[0]);
                }
                else
                {
                    computerCards.Add(deck[0]);
                }
                deck.RemoveAt(0);
            }
        }
    }

    public CardColor ChooseColor()
    {
        Console.WriteLine("1. Red 2. Yellow 3. Green 4. Blue");

        int input = int.Parse(Console.ReadLine());

        return (CardColor)input;
    }   
}





