using Godot;
using System;
using System.Net.Http.Headers;

[GlobalClass]
public partial class ShroomWaterCollector : ShroomBase
{
	[Export]
	public int waterCapacity;

	[Export]
	public int CollectPerTick;

	[Export]
	public int minHumidityToCollect;

	public ShroomWaterCollector()
	{
		waterCapacity = 10;
		minHumidityToCollect = 10;
		WaterCost = 10;
		ShroomName = "Collector";
        MaxHealth = 25;
        Health = MaxHealth;
		icon = GD.Load<Texture2D>("res://Art/Textures/TileSetGround/ground 2.png");
    }


    public override void OnBuild()
    {
        base.OnBuild();
		PlayerStats.Instance.Water.MaxValue += 10;
    }

	public override void OnDestroy()
	{
		base.OnDestroy();
		PlayerStats.Instance.Water.MaxValue -= 10;
	}

    public override void DoTick()
	{
		base.DoTick();
		if(PlayerStats.Instance.Water.Value > 0)
		{
			DoHeal(3);
		}

		if(PlayerStats.Instance.Humidity.Value > minHumidityToCollect)
		{
			PlayerStats.Instance.Water.Value += CollectPerTick;
		}
	}


}
