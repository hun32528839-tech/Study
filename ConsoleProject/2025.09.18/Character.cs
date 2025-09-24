public class Character
{
    // 외부에서는 읽기만 가능
    // 내부/자식 클래스에서는 쓰기 가능
    protected string _name;
    protected int _hp;
    protected int _atk;

    public void InitCharacter(string inName , int inHp , int inAtk)
    {
        _name = inName;
        _hp = inHp;
        _atk = inAtk;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Hp : {Hp}");
        Console.WriteLine($"Atk : {Atk}");
    }
    
}