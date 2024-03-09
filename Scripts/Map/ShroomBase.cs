using Godot;
using System;
using System.Collections.Generic;



public abstract partial class ShroomBase : Node, IDamageable, IBuildable
{

	public List<ShroomBase> neighbours;
	public int Health;
	public int MaxHealth;



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
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

    public virtual void OnDestroy()
    {
        QueueFree();
    }
}
