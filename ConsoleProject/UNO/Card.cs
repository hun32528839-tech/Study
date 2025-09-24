public enum PlayerType : int
{
    Player,
    Computer,
}
public enum CardColor : int
{
    None = 0,

    Red,
    Yellow,
    Green,
    Blue,   
}

public enum SpecialCardType : int
{
    None = 0,

    Skip, // 각 컬러의 2장씩 총 8장
    Reverse, // 각 컬러의 2장씩 총 8장
    DrawTwo // 각 컬러의 2장씩 총 8장
            // 총 24장
}
public enum WildCardType : int
{
    None = 0,

    Wild, // 무색 총 4장
    WildDrawFour // 무색 총 4장
                 // 총 8장
}


// abstract 와 virtual의 차이
public abstract class Card // 추상 클래스
{
    public CardColor CardColor;
    
   
    public void InitColor(CardColor inCardColor)
    {
        CardColor = inCardColor;
    }   

    public abstract string GetPrintCard(); // 추상 메서드

    public abstract void PlayEffect(Game game);
       
}
