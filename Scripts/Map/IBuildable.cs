using Godot;
using System;

public interface IBuildable
{
	/// <summary>
	/// When shroom is built
	/// </summary>
	abstract public void OnBuild();

	/// <summary>
	/// When shroom is destroyed
	/// </summary>
	abstract public void OnDestroy();

}
