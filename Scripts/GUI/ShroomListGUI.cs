using Godot;
using System;

public partial class ShroomListGUI : CanvasLayer
{
	[Export]
	public Control Container;

	[Export]
	public PackedScene buttonTemplate;

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

			// Instantiate the scene button
			var Scene = GD.Load<PackedScene>(buttonTemplate.ResourcePath);
			Node sceneInstance = Scene.Instantiate();
			Container.AddChild(sceneInstance);

			// Get TextureRect
			TextureRect rect = (TextureRect) sceneInstance.GetNode("HBoxContainer/TextureRect");
			rect.Texture = shroom.icon;

			// Get LabelName
			Label labelName = (Label) sceneInstance.GetNode("HBoxContainer/VBoxContainer/Name");
			labelName.Text = shroom.ShroomName;

			Label labelDescription = (Label) sceneInstance.GetNode("HBoxContainer/VBoxContainer/Description");
			labelDescription.Text = shroom.ShroomDescription;

			Label labelCost = (Label) sceneInstance.GetNode("HBoxContainer/VBoxContainer/Cost");
			labelCost.Text = "Water Cost: " + shroom.WaterCost;

			Button btn = (Button) sceneInstance.GetNode(".");



			// Event handler to show/hide description on mouse enter/exit
			/*
			btn.MouseEntered += () => { descriptionLabel.Visible = true; tooltip.Visible = true;};
			btn.MouseExited += () => { descriptionLabel.Visible = false; tooltip.Visible = false;};
			*/

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
