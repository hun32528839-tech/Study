public static class MonsterFactory
{
    public static Monster GetMonster(MonsterType inMonsterType)
    {
        Monster monster = new Monster();

        switch(inMonsterType)
        {
            case MonsterType.Goblin:
                monster.InitMonster(inMonsterType, "Goblin", 30, 10);
                break;
            case MonsterType.Skeleton:
                monster.InitMonster(inMonsterType, "Skeleton", 40, 20);
                break;
            case MonsterType.Orc:
                monster.InitMonster(inMonsterType, "Orc", 50, 30);
                break;
        }

        return monster;
    }
}