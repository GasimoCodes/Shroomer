using Godot;
using System;

public partial class ShroomListGUI : CanvasLayer
{
	[Export]
	public Control Container;


	[Export]
	public ShroomBase[] Shrooms;

	public override void _Ready()
	{
		Visible = false;
	}

	public void ShowAndUpdateContainer()
	{
		// Clear existing buttons
		foreach (Node child in Container.GetChildren())
		{
			child.QueueFree(); 
		}

		foreach (ShroomBase shroom in Shrooms)
		{
			// Create a new TextureButton for each shroom
			TextureButton btn = new TextureButton();
			btn.TextureNormal = shroom.icon;

			// Add tooltip with shroom name and water cost
			Control tooltip = new Control();
			Label tooltipLabel = new Label();
			tooltipLabel.Text = $"{shroom.ShroomName}\nWater Cost: {shroom.WaterCost}";
			tooltipLabel.AutosizeEnum = Label.AutosizeEnum.Expand;
			tooltip.AddChild(tooltipLabel);
			btn.AddChild(tooltip);

			// Create a VBoxContainer to hold button and description
			VBoxContainer buttonContainer = new VBoxContainer();
			buttonContainer.AddChild(btn);

			// Create a label for the description
			Label descriptionLabel = new();
			String description = "Example Description: Please add description to the ShroomBase. Thank youuu <3";
			descriptionLabel.Text = description; 
			descriptionLabel.Visible = false; // Initially hide description
			buttonContainer.AddChild(descriptionLabel);

			// Add buttonContainer to the main container
			Container.AddChild(buttonContainer);

			// Event handler to show/hide description on mouse enter/exit
			btn.MouseEntered += () => { descriptionLabel.Visible = true; tooltip.Visible = true;};
			btn.MouseExited += () => { descriptionLabel.Visible = false; tooltip.Visible = false;};

			// Check if player has enough water and disable button if not
			if (shroom.WaterCost > PlayerStats.Instance.Water.Value)
			{
				btn.Disabled = true;
			}

			// Register OnClick event
			btn.Pressed += () =>
			{

				MapBuilder.Instance.EnableBuildMode(shroom);
				Visible = false;
			};
		}

		// Show container
		Visible = true;
	}
}
