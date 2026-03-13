using CustomBastion;
using DefaultNamespace;

namespace Custom_Bastions;

public class program
{
    /// <summary>
    /// this file need to be here so the .csproj file does not throw an error
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("enter player level");
        int level = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter current amount of tiles");
        int tileAmount = Convert.ToInt32(Console.ReadLine()); 
        Console.WriteLine("enter tile calc function to use amount of tile write [ta] and to use player level write [l]");
        string func = Console.ReadLine();
        if (func != null)
        {
            Bastion bs = new Bastion(level, tileAmount, func);
            while (true)
            {
                Console.WriteLine("funcs now available exit, func, param level [value],param tile [value], eval");
                string input = Console.ReadLine();
                if (input == null || input == "exit")
                {
                    break;
                }else if (input.Contains("func"))
                {
                    Console.WriteLine("input new function");
                    func = Console.ReadLine();
                    if (func != null)
                    {
                        bs.ChangeFunction(func);
                    }
                }else if (input.Contains("param level"))
                {
                    string[] inputs = input.Split(" ");
                    bs.ChangePlayerLevel(Convert.ToInt32(inputs[2]));
                    
                }else if (input.Contains("param tile"))
                {
                    string[] inputs = input.Split(" ");
                    bs.ChangeTileAmount(Convert.ToInt32(inputs[2]));
                    
                }else if (input.Contains("eval"))
                {
                    bs.GetTilePrice();
                }
            }
        }
    }
}