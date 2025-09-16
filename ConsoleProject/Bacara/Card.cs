public enum CardSymbol : int
{
    None = 0,

    Spade,
    Heart,
    Diamond,
    Clover
}

public class Card
{
    private CardSymbol cardSymbol;
    private int cardNumber;
   
    public CardSymbol GetCardSymbol()
    {
        return cardSymbol;
    }
    public void SetCardSymbol(CardSymbol inCardSymbol)
    {
        cardSymbol = inCardSymbol;
    }

    public int GetCardNumber()
    {
        return cardNumber;
    }
    public void SetCardNumber(int inCardNum)
    {
        cardNumber = inCardNum;
    }

    public void Print()
    {
        Console.WriteLine($"{cardSymbol} {cardNumber}");
    }

}