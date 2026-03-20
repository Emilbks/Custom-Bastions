namespace CustomBastion;

public abstract class RoomFeature : IPrintable, IPrintableInline
{
    public Room room { get; protected set; }
    
    public string name { get; protected set; }
    public string shorthand { get; protected set; }
    public string description { get; protected set; }
    public string effects { get; protected set; }
    public string perks { get; protected set; }
    
    //Cost for feature
    public int squareCost { get; protected set; }
    public int GPCost { get; protected set; }
    public int turnsToBuild { get; protected set; }
    public string requirements { get; protected set; }
    public int minLevel { get; protected set; }
    public int hirelingsAdded { get; protected set; }
    public ConsoleColor textColor { get; protected set; }
    public ConsoleColor backgroundColor { get; protected set; }

    public RoomFeature()
    {
        room = new NoRoom();
        name = "";
        shorthand = "";
        description = "";
        effects = "";
        perks = "";
        textColor = room.textColor;
        backgroundColor = room.backgroundColor;
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