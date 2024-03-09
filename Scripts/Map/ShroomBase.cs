using Godot;
using System;
using System.Collections.Generic;


/// <summary>
/// Base class for all shrooms
/// </summary>
public abstract partial class ShroomBase : Node2D, IDamageable, IBuildable
{
	/// <summary>
	/// Caching neighbours for performance
	/// </summary>
	public List<ShroomBase> neighbours;
	public int Health;
	public int MaxHealth;
	
	/// <summary>
	/// Resource ID of icon preview
	/// </summary>
	public abstract Texture2D icon{ get; }
	
	/// <summary>
	/// Reference to location in tilemap
	/// </summary>
	public Vector2 TileMapPosition;

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
        QueueFree();
    }
}
