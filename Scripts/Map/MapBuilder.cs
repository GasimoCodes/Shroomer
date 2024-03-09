using Godot;
public partial class MapBuilder : Node
{
	
	public TileSet tileSet;

	ShroomBase buildShroom = null;
	Sprite2D previewSpawner;


    public override void _Ready()
    {
        EnableBuildMode(new ShroomGen());
    }


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
		buildShroom = null;
		previewSpawner.QueueFree();
	}


	public void InputEvent(Node viewport, InputEvent @event, int shapeIdx)
	{

		// If build mode on
		if (previewSpawner != null)
		{
			// Translate 2D mouse position to world position			
			
			

			if (@event is InputEventMouseMotion mouseMotion)
			{
				Vector2 mousePos = mouseMotion.GlobalPosition;
				previewSpawner.Position = mousePos;
			}
			
			

		}


	}
}
