using Godot;
using System;
using System.Net.Http.Headers;

public partial class ShroomGen : ShroomBase
{
    public override Texture2D icon => GD.Load<Texture2D>("res://Art/Textures/TileSetGround/ground 2.png");


	public override void _Ready()
	{
		base._Ready();
		MaxHealth = 100;
		Health = MaxHealth;
	}

	public override void DoTick()
	{
		base.DoTick();
		if(PlayerStats.Instance.Water.Value > 0)
		{
			DoHeal(1);
		}
		
		// Generate power
		PlayerStats.Instance.Energy.Value += 1;
	}


}
