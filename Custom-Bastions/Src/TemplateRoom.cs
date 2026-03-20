using CustomBastion;
using static CustomBastion.Shortcuts;

namespace CustomBastions;

public class TemplateRoom : Room
{
    public TemplateRoom(string name, string shorthand, string description, int initSize, int maxSize, int buildCost, 
        int timeToBuild, int expandCost, string requirements, int minLevel, string hireLings, string perks, 
        ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black) : 
        base(name, shorthand, description, initSize, maxSize, buildCost, timeToBuild, expandCost, requirements, 
            minLevel, hireLings, perks, textColor, backgroundColor)
    {
    }

    public override void Print()
    {
        throw new NotImplementedException();
    }
    public void CreateFeature()
    {
        Console.WriteLine("Enter the name of the feature you want to create:");
        string featureName = ReadInput();
        Console.WriteLine("Enter a shorthand for the feature:");
        string featureshorthand = ReadInput();
        Console.WriteLine("Enter a description for the feature:");
        string featuredescription = ReadInput();
        Console.WriteLine("Enter the effects of the feature:");
        string effects = ReadInput();
        Console.WriteLine("Enter the perks of the feature:");
        string perks = ReadInput();
        Console.WriteLine("Enter the square cost of the feature:");
        int squareCost = ReadInt();
        Console.WriteLine("Enter the gp cost of the feature:");
        int gpCost = ReadInt();
        Console.WriteLine("Enter the turns to build of the feature:");
        int turnsToBuild = ReadInt();
        Console.WriteLine("Enter the requirements of the feature:");
        string requirements = ReadInput();
        Console.WriteLine("Enter the min level of the feature:");
        int minLevel = ReadInt();
        Console.WriteLine("Enter the hirelings added of the feature:");
        int hirelingsAdded = ReadInt();

        RoomFeature feature = new TempalteRoomFeature(this,featureName, featureshorthand, featuredescription, effects, perks, squareCost, gpCost, turnsToBuild, requirements, minLevel, hirelingsAdded);
        RoomFeatures.Add(feature);

    }

    public void EditRoom()
    {
        while (true)
        {
            Console.WriteLine("\nAt room editor for: "+name+", enter a command (type 'help' for a list of commands):");
            switch (ReadInput().ToLower().Trim())
            {
                case "exit" or "close" or "quit" or "c" or "q" or "x":
                    SaveRoom();
                    return;
                case "exit without saving" or "close without saving" or "quit without saving" or "c!" or "q!" or "x!":
                    return;
                case "save" or "s":
                    SaveRoom();
                    return;
                case "edit name":
                    Console.WriteLine("Enter a new name for the room:");
                    name = ReadInput();
                    break;
                case "edit shorthand":
                    Console.WriteLine("Enter a new shorthand for the room:");
                    shorthand = ReadInput();
                    break;
                case "edit description":
                    Console.WriteLine("Enter a new description for the room:");
                    description = ReadInput();
                    break;
                case "edit init size":
                    Console.WriteLine("Enter a new initial size for the room:");
                    InitSize = ReadInt();
                    break;
                case "edit max size":
                    Console.WriteLine("Enter a new maximum size for the room:");
                    MaxSize = ReadInt();
                    break;
                case "edit build cost":
                    Console.WriteLine("Enter a new build cost for the room:");
                    buildCost = ReadInt();
                    break;
                case "edit time to build":
                    Console.WriteLine("Enter a new time to build for the room:");
                    timeToBuild = ReadInt();
                    break;
                case "edit expand cost":
                    Console.WriteLine("Enter a new expand cost for the room:");
                    expandCost = ReadInt();
                    break;
                case "edit requirements":
                    Console.WriteLine("Enter a new requirements for the room:");
                    Requirements = ReadInput();
                    break;
                case "edit min level":
                    Console.WriteLine("Enter a new minimum level for the room:");
                    MinLevel = ReadInt();
                    break;
                case "edit hirelings":
                    Console.WriteLine("Enter a new hirelings for the room:");
                    HireLings = ReadInput();
                    break;
                case "edit perks":
                    Console.WriteLine("Enter a new perks for the room:");
                    perks = ReadInput();
                    break;
                case "edit features":
                    if (RoomFeatures.Count != 0)
                    {
                        Console.WriteLine("Room features:");
                        for (int i = 0; i < RoomFeatures.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {RoomFeatures[i].GetName()}");
                        }
                        Console.WriteLine("Enter the number of the feature you want to edit:");
                        int featureNumber = ReadInt() - 1;
                        if (featureNumber >= 0 && featureNumber < RoomFeatures.Count)
                        {
                            RoomFeatures[featureNumber].EditFeature();
                        }
                        else
                        {
                            Console.WriteLine("Invalid feature number.");
                        }
                    }else { Console.WriteLine("There are no features to edit."); }
                    break;
                case "create feature":
                    CreateFeature();
                    break;
                case "help" or "h":
                default:
                    HelpRoomEditor();
                    break;
            }
        }
    }
    
    public void HelpRoomEditor()
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine("'exit' or 'close' or 'quit' or 'c' or 'q' or 'x' - Exit the room editor and save changes.");
        Console.WriteLine("'exit without saving' or 'close without saving' or 'quit without saving' or 'c!' or 'q!' or 'x!' - Exit the room editor without saving changes.");
        Console.WriteLine("'save' or 's' - Save changes to the room.");
        Console.WriteLine("'edit name' - Edit the name of the room.");
        Console.WriteLine("'edit shorthand' - Edit the shorthand of the room.");
        Console.WriteLine("'edit description' - Edit the description of the room.");
        Console.WriteLine("'edit init size' - Edit the initial size of the room.");
        Console.WriteLine("'edit max size' - Edit the maximum size of the room.");
        Console.WriteLine("'edit build cost' - Edit the build cost of the room.");
        Console.WriteLine("'edit time to build' - Edit the time to build of the room.");
        Console.WriteLine("'edit expand cost' - Edit the expand cost of the room.");
        Console.WriteLine("'edit requirements' - Edit the requirements of the room.");
        Console.WriteLine("'edit min level' - Edit the minimum level of the room.");
        Console.WriteLine("'edit hirelings' - Edit the hirelings of the room.");
        Console.WriteLine("'edit perks' - Edit the perks of the room.");
        Console.WriteLine("'edit features' - Edit the features of the room.");
    }
}