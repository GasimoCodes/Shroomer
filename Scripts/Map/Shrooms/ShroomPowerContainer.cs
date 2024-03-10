using Godot;

[GlobalClass]
public partial class ShroomPowerContainer : ShroomBase
{
	[Export]
	public int PowerCapacity = 10;


	public ShroomPowerContainer()
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
	}

	public override void OnBuild()
	{
		base.OnBuild();
		PlayerStats.Instance.Energy.MaxValue += PowerCapacity;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		PlayerStats.Instance.Energy.MaxValue -= PowerCapacity;
	}


}
