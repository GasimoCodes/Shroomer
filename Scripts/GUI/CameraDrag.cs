using Godot;
using System;
using System.Diagnostics;

/// <summary>
/// Dragging the camera around
/// </summary>
public partial class CameraDrag : Camera2D
{

	bool btnPressed = false;
	Vector2 mouseDelta = new Vector2();

	int maxZoom = 2;
	int minZoom = 0;

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

		// Check zoom middle mouse
		if (@event is InputEventMouseButton mouseWheel)
		{
			if (mouseWheel.ButtonIndex == MouseButton.WheelUp)
			{
				if (Zoom.X < maxZoom)
				{
					Zoom += new Vector2(0.2f, 0.2f);
				}
			}
			else if (mouseWheel.ButtonIndex == MouseButton.WheelDown)
			{
				if (Zoom.X > minZoom)
				{
					Zoom -= new Vector2(0.2f, 0.2f);
				}
			}
		}


	}



}
