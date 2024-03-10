using Godot;
using System;
using System.Collections.Generic;


/// <summary>
/// Base class for all shrooms
/// </summary>
public abstract partial class ShroomBase : Resource, IDamageable, IBuildable
{


	[Export]
	public int Health;

	[Export]
	public int MaxHealth;

	[Export]
	public int WaterCost;

	[Export]
	public int WaterCostPerTick = 1;

	[Export]
	public string ShroomName;

	[Export]
	public string ShroomDescription;

	/// <summary>
	/// Resource ID of icon preview
	/// </summary>
	[Export]
	public Texture2D icon;

	[Export]
	public Vector2I TileSetGraphicsIndex;

	[Export]
	public int SpriteSourceIndex = 0;


	/// <summary>
	/// Reference to location in tilemap for the instance
	/// </summary>
	public Vector2I TileMapPosition;

	/// <summary>
	/// Caching neighbours for performance?
	/// </summary>
	public List<ShroomBase> neighbours;


	public ShroomBase()
	{
	}

	public virtual void DoDamage(int damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			OnDestroy();
		}
	}

	public virtual void DoHeal(int heal)
	{
		Health += heal;
		if (Health > MaxHealth)
		{
			Health = MaxHealth;
		}
	}


	public virtual void OnBuild()
	{
	}

	/// <summary>
	/// Passive action of the shroom
	/// </summary>
	public virtual void DoTick()
	{
		if (PlayerStats.Instance.Water.Value > WaterCostPerTick)
		{
			DoHeal(1);
			PlayerStats.Instance.Water.Value -= WaterCostPerTick;
		}
	}

	public virtual void OnDestroy()
	{
	}
}
