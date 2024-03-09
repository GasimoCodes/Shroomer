using Godot;
using System;

public partial class PlayerStats : NodeSingleton<PlayerStats>
{


	public ValueContainer Energy = new ValueContainer();
	public ValueContainer Water = new ValueContainer();
	public ValueContainer Humidity = new ValueContainer();



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
	}


	

}


/// <summary>
/// Used to represent stats that can be increased and decreased. 
/// </summary>
public class ValueContainer
{
	private int value = 0;

	/// <summary>
	/// Use this to access the value of the container
	/// </summary>
	public int Value
	{
		get
		{
			return value;
		}
		set
		{
			if (value > MaxValue)
			{
				value = MaxValue;
			}
			this.value = value;
			OnValueChanged?.Invoke(value);
		}
	}

	public int MaxValue = 0;
	public int IncreasePerSecond = 0;

	public Action<int> OnValueChanged;

}

