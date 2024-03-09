using Godot;
using System;
using System.Diagnostics;

public partial class CameraDrag : Node2D
{

	bool btnPressed = false;
	Vector2 mouseDelta = new Vector2();


	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			btnPressed = true;
		}
		else if (@event is InputEventMouseButton mouseEvent2 && !mouseEvent2.Pressed)
		{
			btnPressed = false;
		}

		if (@event is InputEventMouseMotion mouseMotion)
		{
			if (btnPressed)
			{
				mouseDelta = mouseMotion.Relative;
				Position -= mouseDelta;
			}
		}
	}



}
