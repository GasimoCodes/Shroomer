using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// This is the evidence for ALL shrooms in the game. 
/// </summary>
public partial class ShroomNetwork : NodeSingleton<ShroomNetwork>
{
	/// <summary>
	/// List of shrooms on the map
	/// </summary>
	public Dictionary<Vector2,ShroomBase> shrooms = new();

	/// <summary>
	/// Register a shroom to the network. Call this upon placing a new shroom from the MapBuilder
	/// </summary>
	public void RegisterShroom(ShroomBase shroom){

		// Check for neighbours and write them into shroom
		
		// Update neighbours with this shroom
		
		// Add shroom to list

	}

	public void UnregisterShroom(ShroomBase shroom)
	{
        // Remove shroom from list
		shrooms.Remove(shroom.TileMapPosition);
    }


	public void DoTick(){
		// Do tick for all shrooms. This may be collecting resources.
		foreach (ShroomBase shroom in shrooms.Values){
			shroom.DoTick();
		}
	}

}
