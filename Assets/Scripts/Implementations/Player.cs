public class Player
{
    private PlayerData playerData;

    public Player(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    public string Name => playerData.name;
}