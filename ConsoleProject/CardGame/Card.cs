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
    private Symbol cardSymbol;
    private int cardNumber;

    public Symbol GetSymbol()
    {
        return cardSymbol;
    }
    public void SetSymbol(Symbol symbol)
    {
        cardSymbol = symbol;
    }

    public int GetCardNumber()
    {
        return cardNumber;
    }

    public void SetCardNumber(int cardNum)
    {
        cardNumber = cardNum;
    }

    public void Print()
    {
        Console.WriteLine($" {cardSymbol} {cardNumber}");
    }
}

