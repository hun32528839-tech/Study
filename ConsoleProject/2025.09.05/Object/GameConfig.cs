public class GameConfig
{
    Random random = new Random();

    public int PlayerRunawayChance()
    {
        int runawayChance = random.Next(1, 11);
        return runawayChance;
    }

    public static readonly int hpPotionMinValue = 10;
    public static readonly int hpPotionMaxValue = 30;
}
