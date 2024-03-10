using System;
using System.Diagnostics;
using Godot;

/// <summary>
/// Call this class to enable build mode.
/// </summary>
public partial class MapBuilder : NodeSingleton<MapBuilder>
{
	[Export]
	public TileMap tileMap;

	ShroomBase buildShroom = null;
	Sprite2D previewSpawner;

	[Export]
	Camera2D camera;

	ShroomNetwork shroomNetwork;


	public override void _Ready()
	{
		base._Ready();
	}

	/// <summary>
	/// This will turn on the Build-mode. 
	/// </summary>
	/// <param name="shroomBase"></param>
	public void EnableBuildMode(ShroomBase shroomBase)
	{
		// Create new Sprite2D for the preview
		previewSpawner = new Sprite2D
		{
			Texture = shroomBase.icon,
			Modulate = new Color(1, 1, 1, 0.5f),
			ZIndex = 1
		};

		buildShroom = (ShroomBase)shroomBase.Duplicate();

		AddChild(previewSpawner);
	}


	public void DisableBuildMode()
	{
		// Remove the preview
		previewSpawner.QueueFree();
		previewSpawner = null;
	}


	public override void _Input(InputEvent @event)
	{
		// If build mode on
		if (previewSpawner != null)
		{
			shroomNetwork = ShroomNetwork.Instance;
			// Translate 2D mouse position to world position


			Vector2 global = (camera.GetGlobalMousePosition());
        	previewSpawner.Position = global;

			Vector2I tilePos = tileMap.LocalToMap(tileMap.GetLocalMousePosition());
			
			if (!shroomNetwork.CanBePlaced(tilePos, buildShroom))
			{
				previewSpawner.Modulate = new Color(0.5f, 0, 0, 0.5f);
			}
			else
			{
				// If can be placed
				previewSpawner.Modulate = new Color(1f, 1f, 1f, 0.5f);

				if (@event is InputEventMouse mouseButton)
				{
					if (mouseButton.ButtonMask == MouseButtonMask.Left)
					{
						buildShroom.TileMapPosition = tilePos;
						tileMap.SetCell(1, tilePos, buildShroom.SpriteSourceIndex, buildShroom.TileSetGraphicsIndex);
						shroomNetwork.RegisterShroom(buildShroom);
						buildShroom.OnBuild();
						PlayerStats.Instance.Water.Value -= buildShroom.WaterCost;
					}
				}


			}



		}


	}
}
