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
			energyLabel.Text = "Energy: " + value + "/" + PlayerStats.Instance.Energy.MaxValue;
		};

		PlayerStats.Instance.Water.OnValueChanged += (value) =>
		{
			WaterLabel.Text = "Water: " + value + "/" + PlayerStats.Instance.Water.MaxValue;

			// Make the label red if water is low relative to maxValue
			if (value < PlayerStats.Instance.Water.MaxValue / 4)
			{
				WaterLabel.Modulate = new Color(1, 0, 0);
			}
			else
			{
				WaterLabel.Modulate = new Color(1, 1, 1);
			}

		};

		PlayerStats.Instance.Humidity.OnValueChanged += (value) =>
		{
			HumidityLabel.Text = "Humidity: " + value + "/" + PlayerStats.Instance.Humidity.MaxValue;
			HumidityBar.Value = value;
		};


		// Update vars ez
		PlayerStats.Instance.Energy.Value = PlayerStats.Instance.Energy.Value;
		PlayerStats.Instance.Water.Value = PlayerStats.Instance.Water.Value;
		PlayerStats.Instance.Humidity.Value = PlayerStats.Instance.Humidity.Value;



	}

}
