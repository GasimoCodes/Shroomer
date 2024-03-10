using Godot;

[GlobalClass]
public partial class ShroomGen : ShroomBase
{
	[Export]
	public int PowerGenerationPerTick = 1;



	public ShroomGen()
	{
		WaterCost = 5;
		ShroomName = "MeowShroom :3";
		MaxHealth = 10;
		Health = MaxHealth;
		icon = GD.Load<Texture2D>("res://Art/Textures/TileSetGround/ground 2.png");
	}

	public override void DoTick()
	{
		base.DoTick();

		if (PlayerStats.Instance.Water.Value > 1)
		{
			// Generate power
			PlayerStats.Instance.Energy.Value += PowerGenerationPerTick;
		}
	}


}
