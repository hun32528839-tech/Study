
public class NumberCard : Card
{  
    private int _number;

    public NumberCard(CardColor inCardColor , int inNumber) // 생성자 사용 따로 객체 생성하지 않고 바로 생성하면서 초기화
    {
        InitColor(inCardColor);

        _number = inNumber;
    }

    public override string GetPrintCard()
    {
        return $"{CardColor} {_number}";
    }

    public override void PlayEffect(Game game)
    {
        game.NextTurn();
    }
}
