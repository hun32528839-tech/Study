public class SpecialCard : Card
{
    private SpecialCardType _sType;

    public SpecialCard(CardColor inCardColor , SpecialCardType inSpecialCardType)
    {
        InitColor(inCardColor);

        _sType = inSpecialCardType;
    }

    public override string GetPrintCard()
    {
        return $"{CardColor} {_sType}";
    }

    public override void PlayEffect(Game game)
    {
        switch (_sType)
        {
            case SpecialCardType.Skip:
                Console.WriteLine("턴을 넘깁니다.");
                game.SkipNextTurn();
                break;
            case SpecialCardType.Reverse:
                Console.WriteLine("턴 방향을 바꿉니다.");
                game.ReverseTurnOrder();
                break;
            case SpecialCardType.DrawTwo:
                Console.WriteLine("상대방에게 카드 2장을 줍니다.");
                game.DrawCardToOther(2);
                break;
        }

    }
}