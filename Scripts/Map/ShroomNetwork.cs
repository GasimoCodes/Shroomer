using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// This is the evidence for ALL shrooms in the game. 
/// </summary>
public partial class ShroomNetwork : Node
{
	public List<ShroomBase> shrooms;

	/// <summary>
	/// Register a shroom to the network. Call this upon placing a new shroom.
	/// </summary>
	public void RegisterShroom(ShroomBase shroom){

		// Check for neighbours and write them into shroom
		
		// Update neighbours with this shroom
		
		// Add shroom to list
		
	}


	public void DoTick(){
		// Do tick for all shrooms. This may be collecting resources.
		foreach (ShroomBase shroom in shrooms){
			shroom.DoTick();
		}
	}

}
