using System.Linq.Expressions;
using CustomBastion;

namespace DefaultNamespace;
using NCalc;

public class PriceCalculator
{
    public Expression ex;
    private Bastion _bastion;
    public PriceCalculator(string input, Bastion bastion)
    {
        ex = new Expression(input);
        _bastion = bastion;
        ex.Parameters["l"] = _bastion.playerLevel;
        ex.Parameters["ta"] = _bastion.tileAmount;
    }

    public void ChangeExperssion(string newEx)
    {
        ex = new Expression(newEx);
        ex.Parameters["l"] = _bastion.playerLevel;
        ex.Parameters["ta"] = _bastion.tileAmount;
    }

    public void eval()
    {
        try
        {
            Console.WriteLine(ex.Evaluate());
        }
        catch 
        {
            Console.WriteLine("eval failed something wrong with function");
        }
    }


    public void ChangeParam(string name, int value)
    {
        ex.Parameters[name] = value;
    }
}