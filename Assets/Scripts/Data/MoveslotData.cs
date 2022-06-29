public class MoveslotData
{
    #region Public Fields

    public MoveKey moveKey;
    public int usesLeft;

    #endregion Public Fields

    #region Public Constructors

    public MoveslotData(MoveKey moveKey)
    {
        this.moveKey = moveKey;
        this.usesLeft = HelperFunctions.MoveDataFromMoveKey(moveKey).maxUses;
    }

    #endregion Public Constructors
}