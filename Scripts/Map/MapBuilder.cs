using System.Diagnostics;
using Godot;

/// <summary>
/// Call this class to enable build mode.
/// </summary>
public partial class MapBuilder : Node
{

	public TileSet tileSet;

	ShroomBase buildShroom = null;
	Sprite2D previewSpawner;

	[Export]
	Camera2D camera;


	public override void _Ready()
	{
		EnableBuildMode(new ShroomGen());
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
			Modulate = new Color(1, 1, 1, 0.5f)
		};

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
			// Translate 2D mouse position to world position			


			if (@event is InputEventMouseMotion mouseMotion)
			{
				Vector2 mousePos = mouseMotion.Position;
				Vector2 cameraPos = camera.Position;

				previewSpawner.Position = mousePos + cameraPos - GetViewport().GetVisibleRect().Size / 2;
			}
		}


	}
}
