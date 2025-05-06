using Godot;
using System;

public partial class CustomSignals : Node
{
	// Called when the node enters the scene tree for the first time.
	[Signal]
	public delegate void AddToInvetoryEventHandler(Node3D item);
}
