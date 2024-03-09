using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Data for context menu when right clicking on any object.
/// </summary>
public interface IPopupMenu
{
	public abstract Dictionary<string, string> Stats { get; }
	public abstract KeyValuePair<string, Action> OnClick { get; }
}
