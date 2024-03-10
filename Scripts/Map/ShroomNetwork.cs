using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// This is the evidence for ALL shrooms in the game. 
/// </summary>
public partial class ShroomNetwork : NodeSingleton<ShroomNetwork>
{
	Timer timer;
    public override void _Ready()
    {
        base._Ready();

		// Invoke repeat on the Tick() method
		timer = new Timer();
		AddChild(timer);
		timer.Timeout += DoTick;
		timer.OneShot = false; 
		timer.Start();
		timer.Autostart = true;
		
    }

    /// <summary>
    /// List of shrooms on the map
    /// </summary>
    public Dictionary<Vector2I,ShroomBase> shrooms = new();

	/// <summary>
	/// Register a shroom to the network. Call this upon placing a new shroom from the MapBuilder
	/// </summary>
	public void RegisterShroom(ShroomBase shroom){

		// Check for neighbours and write them into shroom
		
		// Update neighbours with this shroom
		
		// Add shroom to list
		shrooms.Add(shroom.TileMapPosition, shroom);

	}

	/// <summary>
	/// Check if a shroom can be placed at a given position. Returns true if it can be placed.
	/// </summary>
	/// <param name="position"></param>
	/// <param name="shroom"></param>
	/// <returns></returns>
	public bool CanBePlaced(Vector2I position, ShroomBase shroom)
	{
		bool canBePlaced = true;

		// Check if position is empty
		canBePlaced &= !shrooms.ContainsKey(position);

		// Check if water level is enough
		canBePlaced &=  (PlayerStats.Instance.Water.Value >= shroom.WaterCost); 

		return canBePlaced;

		// TO-DO: Check if position is neighbour to another shroom!
	}


	public void UnregisterShroom(ShroomBase shroom)
	{
        // Remove shroom from list
		shrooms.Remove(shroom.TileMapPosition);
		shroom.OnDestroy();
    }


	public void DoTick(){
		// Do tick for all shrooms. This may be collecting resources.
		foreach (ShroomBase shroom in shrooms.Values){
			shroom.DoTick();
		}

		if(PlayerStats.instance.Water.Value < 10)
		{
			PlayerStats.instance.Water.Value += 1;
		}
		
	}

}
