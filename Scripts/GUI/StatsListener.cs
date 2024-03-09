using Godot;
using System;

/// <summary>
/// HUD listener for player stats
/// </summary>
public partial class StatsListener : Node
{
	[Export]
	public Label energyLabel;
	[Export]
	public Label WaterLabel;
	[Export]
	public Label HumidityLabel;
	[Export]
	public ProgressBar HumidityBar;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		PlayerStats.Instance.Energy.OnValueChanged += (value) =>
		{
			energyLabel.Text = "Energy: " + value;
		};

		PlayerStats.Instance.Water.OnValueChanged += (value) =>
		{
			WaterLabel.Text = "Water: " + value;
		};

		PlayerStats.Instance.Humidity.OnValueChanged += (value) =>
		{
			HumidityLabel.Text = "Humidity: " + value;
			HumidityBar.Value = value;
		};


		// Update vars ez
		PlayerStats.Instance.Energy.Value = PlayerStats.Instance.Energy.Value;
		PlayerStats.Instance.Water.Value = PlayerStats.Instance.Water.Value;
		PlayerStats.Instance.Humidity.Value = PlayerStats.Instance.Humidity.Value;



	}

}
