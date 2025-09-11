public enum RockPaperScissors : int // 숫자 1,2,3이 아닌 이름이 있는 값(enum)을 사용함으로써 명확성과 가독성을 높히기 위해서 사용
{
    None = 0,

    Scissors,
    Rock,
    Paper
}

public class RPS
{
    private RockPaperScissors rockPaperScissors;
    Random random = new Random();

    public void Play()
    {
        Console.WriteLine("가위 , 바위 , 보 중에 무엇을 내시겠습니까?");
        string playerStr = Console.ReadLine();
        rockPaperScissors = (RockPaperScissors)random.Next(1, 4); // enum으로 형변환하여 랜덤값을 넣어준다
        
        if(playerStr.Equals("가위") || playerStr.Equals("바위") || playerStr.Equals("보"))
        {
            Console.WriteLine($"Player : {playerStr} Computer : {rockPaperScissors}");
        }
               
        if(playerStr.Equals("가위"))
        {
            if(rockPaperScissors.Equals(RockPaperScissors.Scissors))
            {
                Console.WriteLine("무승부");
            }
            else if(rockPaperScissors.Equals(RockPaperScissors.Rock))
            {
                Console.WriteLine("컴퓨터 승");
            }
            else
            {
                Console.WriteLine("플레이어 승");
            }
        }
        else if(playerStr.Equals("바위"))
        {
            if(rockPaperScissors.Equals(RockPaperScissors.Scissors))
            {
                Console.WriteLine("플레이어 승");
            }
            else if(rockPaperScissors.Equals(RockPaperScissors.Rock))
            {
                Console.WriteLine("무승부");
            }
            else
            {
                Console.WriteLine("컴퓨터 승");
            }
        }
        else if(playerStr.Equals("보"))
        {
            if(rockPaperScissors.Equals(RockPaperScissors.Scissors))
            {
                Console.WriteLine("컴퓨터 승");
            }
            else if(rockPaperScissors.Equals(RockPaperScissors.Rock))
            {
                Console.WriteLine("플레이어 승");
            }
            else
            {
                Console.WriteLine("무승부");
            }
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }     
    }
}