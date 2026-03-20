namespace CustomBastion;

public abstract class RoomFeature : IPrintable, IPrintableInline
{
    protected Room room;
    
    protected string name;
    protected string shorthand;
    protected string description;
    protected string effects;
    protected string perks;
    
    //Cost for feature
    protected int squareCost;
    protected int GPCost;
    protected int turnsToBuild;
    protected string requirements;
    protected int minLevel;
    protected int hirelingsAdded;
    private ConsoleColor textColor;
    private ConsoleColor backgroundColor;

    public RoomFeature()
    {
        room = new NoRoom();
        name = "";
        shorthand = "";
        description = "";
        effects = "";
        perks = "";
        textColor = ConsoleColor.White;
        backgroundColor = ConsoleColor.Black;
        squareCost = 0;
        GPCost = 0;
        turnsToBuild = 1;
        requirements = "None";
        minLevel = 5;
        hirelingsAdded = 0;
    }

    public abstract void Print();

    public void PrintInline()
    {
        ConsoleColor oldTextColor = Console.ForegroundColor;
        ConsoleColor oldBackgroundColor = Console.BackgroundColor;

        Console.ForegroundColor = textColor;
        Console.BackgroundColor = backgroundColor;
        Console.Write(shorthand);

        Console.ForegroundColor = oldTextColor;
        Console.BackgroundColor = oldBackgroundColor;
    }
}