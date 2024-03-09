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
   
	/// <summary>
	/// Resource ID of icon preview
	/// </summary>
	[Export]
	public Texture2D icon;
	
	/// <summary>
	/// Reference to location in tilemap
	/// </summary>
	public Vector2 TileMapPosition;

    /// <summary>
    /// Caching neighbours for performance
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
	public virtual void DoTick(){
		
	}

    public virtual void OnDestroy()
    {
    }
}
