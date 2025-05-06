using Godot;
using Godot.Collections;
using System;

public partial class MainGameControl : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Dictionary Ports = new();

		Ports.Add("PlayerPort", new Node());
		Ports.Add("CCTV", new Node());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
