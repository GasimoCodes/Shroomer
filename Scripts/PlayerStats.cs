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

		// Populate default values
		Energy.MaxValue = 100;
		Energy.Value = 25;

		Water.MaxValue = 100;
		Water.Value = 25;

		Humidity.MaxValue = 100;
		Humidity.Value = 25;
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
	[Export]
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

	[Export]
	public int MaxValue = 0;
	public int IncreasePerSecond = 0;

	public Action<int> OnValueChanged;

	public ValueContainer(int value = 0, int maxValue = 0, int increasePerSecond = 0)
	{
		Value = value;
		MaxValue = maxValue;
		IncreasePerSecond = increasePerSecond;
	}

}

