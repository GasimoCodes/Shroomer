using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public partial class ShroomListGUI : Node
{

	/// <summary>
	/// Container for the UI grid. AKA the parent which contains the panel and all.
	/// </summary>
	[Export]
	public Control Container;

	/// <summary>
	/// List of shroom templates. 
	/// </summary>
	[Export]
	public ShroomBase[] Shrooms;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Ready()
	{
		// Hide container
		Container.Visible = false;
	}

	/// <summary>
	/// This is called when the player clicks on a button to show the grid. 
	/// </summary>
	public void ShowAndUpdateContainer()
	{
		// Remove any previous buttons (since we are going to populate the list again)
		
		foreach (Node child in Container.GetChildren())
    {
		// Remove previous buttons
        child.QueueFree(); 
    }


		// Populate shrooms list, someone watch some UI tutorial on how to populate a grid with items

		foreach (ShroomBase shroom in Shrooms)
		{
		// Get the water cost from shroom (you show it on the button)
			int waterCost = shroom.WaterCost;

		 // Create a new button for each shroom
        Button btn = new Button();
		btn.Text = shroom.ShroomName + $" (Water: {waterCost})";
		// Add button to the container
        Container.AddChild(btn); 
		
			if (waterCost > PlayerStats.Instance.Water.Value)
			{
				btn.Disabled = true;
			}

			

			// Register OnClick event
			// (aka btn.OnClick => {MapBuilder.EnableBuildMode(shroom)})
			btn.Pressed+=()=>{
				// call the builder
			};
		}


		// Show container
		Container.Visible = true;

	}





}
