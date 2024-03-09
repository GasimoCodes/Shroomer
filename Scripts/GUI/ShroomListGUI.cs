using Godot;
using System;
using System.Runtime.InteropServices;

public partial class ShroomListGUI : Node
{
	[Export]
	public Control Container;
	public ShroomBase[] Shrooms;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Ready()
	{
		// Populate shrooms list, someone watch some UI tutorial on how to populate a grid with items


		// Hide container
		Container.Visible = false;
	}

	
	


}
