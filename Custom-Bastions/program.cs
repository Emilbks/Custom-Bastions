using System.Text.Json;
using static CustomBastion.Shortcuts;

namespace CustomBastion;

public class Program
{
    static Bastion currentBastion = new Bastion();
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            string path = FixBastionPath(args[0]);

            if (File.Exists(path)) LoadSavedBastion(path);
            else if (args[0].ToLower() == "new") Console.WriteLine("Starting with a new bastion.");
            else LoadPreviousSave();
        }
        else LoadPreviousSave();

        Menu();
    }

    /// <summary>
    /// Displays a menu to the user and waits for input. The menu will continue to be displayed until the user enters "exit", "close", "quit", "c", "q", or "x". The user can also enter "help" or "h" to see a list of available commands.
    /// </summary>
    public static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\nAt main menu, enter a command (type 'help' for a list of commands):");
            switch (ReadInput().ToLower().Trim())
            {
                case "exit" or "close" or "quit" or "c" or "q" or "x":
                    SaveBastion();
                    return;
                case "exit without saving" or "close without saving" or "quit without saving" or "c!" or "q!" or "x!":
                    return;
                case "view" or "view bastion" or "vb":
                    ViewBastion();
                    break;
                case "display" or "display bastion" or "db":
                    DisplayBastion();
                    break;
                case "view saved" or "view saved bastions" or "vsb":
                    ViewSavedBastions();
                    break;
                case "save" or "s":
                    SaveBastion();
                    break;
                case "load" or "l":
                    LoadSavedBastion("null", true);
                    break;
                case "clear" or "cls":
                    Console.Clear();
                    break;
                case "help" or "h" or "?" or "!":
                default:
                    Help();
                    break;
                
            }
        }
    }

    public static void Help()
    {
        Console.WriteLine("help|h|?|! - shows this message.");
        Console.WriteLine("exit|close|quit|c|q|x - exits the program and saves all changes.");
        Console.WriteLine("exit without saving|close without saving|quit without saving|c!|q!|x! - exits the program without saving changes.");
        Console.WriteLine("view|view bastion|vb - views the information of the current bastion.");
        Console.WriteLine("display|display bastion|db - displays the layout of the current bastion.");
        Console.WriteLine("view saved|view saved bastions|vsb - views all saved bastions.");
        Console.WriteLine("save|s - saves the current bastion.");
        Console.WriteLine("load|l - loads a saved bastion.");
        Console.WriteLine("clear|cls - clears the console.");
    }

    public static void ViewBastion()
    {
        Console.WriteLine("Current bastion: " + currentBastion.name);
    }


    /// <summary>
    /// Displays the bastions in data/bastions/ folder and removes the .json extension.
    /// </summary>
    public static void ViewSavedBastions()
    {
        if (!Directory.Exists("data/bastions"))
        {
            Console.WriteLine("No saved bastions found.");
            return;
        }

        string[] files = Directory.GetFiles("data/bastions/", "*.json");
        if (files.Length == 0)
        {
            Console.WriteLine("No saved bastions found.");
            return;
        }

        Console.WriteLine("Saved bastions:");
        foreach (string file in files)
        {
            Console.WriteLine("- " + Path.GetFileNameWithoutExtension(file));
        }
    }

    /// <summary>
    /// Saves the current bastion to a file in the data/bastions/ folder.
    /// </summary>
    public static void SaveBastion() { currentBastion.SaveBastion(); }
    public static void LoadSavedBastion(string path, bool userInterface = false)
    {
        if (userInterface)
        {
            Console.WriteLine("Enter the name of the bastion you want to load, write 'c' to exit:");
            do
            {
                string input = ReadInput();
                if (input.ToLower() == "c") break;
                
                string filename = string.Join("_", input.Trim().Split());
                if (filename.Length == 0) filename = "Unnamed Bastion";

                filename = "data/bastions/" + filename + ".json";

                if (File.Exists(filename))
                {
                    LoadSavedBastion(filename);
                    break;
                }
                else Console.WriteLine("File not found, try again or write 'c' to exit:");
            } while (true);
            return;
        }

        path = FixBastionPath(path);

        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            currentBastion = JsonSerializer.Deserialize<Bastion>(jsonString) ?? new Bastion();
        }
    }
    public static void LoadPreviousSave()
    {
        if (File.Exists("data/PreviousBastionPath.txt"))
        {
            string path = File.ReadAllText("data/PreviousBastionPath.txt");
            if (File.Exists(path))
            {
                LoadSavedBastion(path);
            }
            else
            {
                Console.WriteLine("Previous save file not found, starting with a new bastion.");
                currentBastion = new Bastion();
            }
        }
        else
        {
            currentBastion = new Bastion();
        }
    }

    public static void DisplayBastion()
    {
        Console.WriteLine($"Type what floor do you want to see (1-{currentBastion.layout.GetLength(0)})?");
        int f = ReadInt();
        if (0 > f || f > currentBastion.layout.GetLength(0))
        {
            System.Console.WriteLine("Invalid input, going back to main menu.");
            return;
        }
        currentBastion.DisplayBastionFloor(f - 1);
    }

}