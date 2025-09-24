public enum Symbol : int
{
    None = 0,

    Spade,
    Heart,
    Diamond,
    Clover
}
public class Card
{
    private Symbol symbol;
    private int cardNumber;

    public Symbol GetSymbol()
    {
        return symbol;
    }
    public void SetSymbol(Symbol insymbol)
    {
        symbol = insymbol;
    }

    public int GetCardNumber()
    {
        return cardNumber;
    }
    public void SetCardNumber(int inCardNumber)
    {
        cardNumber = inCardNumber;
    }

    public void Print()
    {
        Console.WriteLine($"{symbol} {cardNumber}");
    }
}
