public static class PlayerFactory
{
    public static Player GetPlayer(PlayerClass inPlayerClass)
    {
        Player player = new Player();
       
        switch (inPlayerClass)
        {
            case PlayerClass.Warrior:
                player.InitPlayer(inPlayerClass, "Warrior", 40, 20);
                break;
            case PlayerClass.Wizard:
                player.InitPlayer(inPlayerClass, "Wizard", 30, 10);
                break;
        }
        return player;
    }
}