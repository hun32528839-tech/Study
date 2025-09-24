public class WildCard : Card
{
    private WildCardType _wType;
    public WildCard(WildCardType inWildCardType)
    {
        _wType = inWildCardType;
    }

    public override string GetPrintCard()
    {
        return $"{_wType}";
    }

    public override void PlayEffect(Game game)
    {
        switch (_wType)
        {
            case WildCardType.Wild:
                Console.WriteLine("Color를 고르십시오.");
                game.ChooseColor();
                break;
            case WildCardType.WildDrawFour:
                Console.WriteLine("Color를 고르고 상대방에게 카드 4장을 줍니다.");
                game.ChooseColor();
                game.DrawCardToOther(4);
                game.SkipNextTurn();
                break;
        }
    }
}