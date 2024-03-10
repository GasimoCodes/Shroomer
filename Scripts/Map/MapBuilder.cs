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

	private bool destroy;


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
		shroomNetwork = ShroomNetwork.Instance;

		// If build mode on
		if (previewSpawner != null)
		{
			// Translate 2D mouse position to world position

			Vector2 global = (camera.GetGlobalMousePosition());

			Vector2I tilePos = tileMap.LocalToMap(tileMap.GetLocalMousePosition());

			Vector2 local = tileMap.MapToLocal(tilePos);
			previewSpawner.Position = local + tileMap.Position /*- new Vector2(0, 110)*/;

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

		// Enter destroy mode
		if (@event is InputEventKey key)
		{
			if (!destroy && key.Pressed && key.GetKeycodeWithModifiers() == Key.X)
			{
				destroy = true;
				DisableBuildMode();
				return;
			}

			if (destroy && key.Pressed && key.GetKeycodeWithModifiers() == Key.X)
			{
				destroy = false;
				return;
			}
		}

		// Destroy mode
		if (destroy && @event is InputEventMouseButton buttonEvent)
		{
			Vector2I tilePos = tileMap.LocalToMap(tileMap.GetLocalMousePosition());

			try
			{
				ShroomBase shroom = shroomNetwork.shrooms[tilePos];

				if (!shroomNetwork.CanBePlaced(tilePos, shroom))
				{
					shroomNetwork.UnregisterShroom(shroom);

					tileMap.SetCell(1, tilePos);
				}
			}
			catch (Exception ignored)
			{
			}
		}
	}
}
