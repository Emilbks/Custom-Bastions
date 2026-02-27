namespace CustomBastion;

public abstract class Room
{
    protected int InitSize;
    protected int BuiltSquares;
    protected int UsedSquares;
    protected int MaxSize;
    protected string Requirements;
    protected int MinLevel;
    protected string HireLings;
    
    protected List<RoomFeature> RoomFeatures;

    protected Room()
    {
        BuiltSquares = InitSize;
        UsedSquares = InitSize;
    }
}