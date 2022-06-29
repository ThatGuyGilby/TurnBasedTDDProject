public class MoveslotData
{
    public MoveKey moveKey;
    public int usesLeft;

    public MoveslotData(MoveKey moveKey)
    {
        this.moveKey = moveKey;
        this.usesLeft = HelperFunctions.MoveDataFromMoveKey(moveKey).maxUses;
    }
}
