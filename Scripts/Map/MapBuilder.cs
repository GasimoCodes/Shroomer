using Godot;
public partial class MapBuilder : Node
{
	public ShroomBase baseShroom;
	public TileSet tileSet;

	ShroomBase buildShroom = null;


    public override void _Ready()
    {
        EnableBuildMode(new ShroomGen());
    }


    public void EnableBuildMode(ShroomBase shroomModel)
	{
		buildShroom = shroomModel.Duplicate() as ShroomBase;
	}


	public void DisableBuildMode()
	{
		buildShroom = null;
	}


	public void InputEvent(Node viewport, InputEvent @event, int shapeIdx)
	{

		// If build mode on
		if (buildShroom != null)
		{
			// Translate 2D mouse position to world position			
			
			Vector2 mousePos = Vector2.Zero;

			if (@event is InputEventMouseMotion mouseMotion)
			{
				mousePos = mouseMotion.GlobalPosition;
			}
			
			// Render preview of the shroom, snapping to the tileset.
			buildShroom.Position = mousePos;

		}


	}
}
