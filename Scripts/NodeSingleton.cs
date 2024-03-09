using Godot;
using System;
using System.Net;

public partial class NodeSingleton<T> : Node where T : NodeSingleton<T>
{

	protected static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
			}
			return instance;
		}
	}

	
	
	public override void _Ready()
	{
		instance = (T)this;
	}

}
