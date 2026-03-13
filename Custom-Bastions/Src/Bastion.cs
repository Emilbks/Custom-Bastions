using DefaultNamespace;

namespace CustomBastion;

public class Bastion
{
    public List<Room> Rooms;
    public String layout;
    public int HirelingAmount;
    public int tileAmount;
    public int playerLevel;
    public PriceCalculator pc;

    public Bastion(int playerLevel, int tileAmount, string TileCostFunction)
    {
        this.playerLevel = playerLevel;
        this.tileAmount = tileAmount;
        pc = new PriceCalculator(TileCostFunction, this);
    }

    public void ChangeFunction(string newfunc)
    {
        pc.ChangeExperssion(newfunc);
    }
    
    
    public void ChangePlayerLevel(int level)
    {
        playerLevel = level;
        pc.ChangeParam("l", playerLevel);
    }
    public void ChangeTileAmount(int amount)
    {
        tileAmount = amount;
        pc.ChangeParam("ta", tileAmount);
    }

    public void GetTilePrice()
    {
        pc.eval();
    }
    
    
}