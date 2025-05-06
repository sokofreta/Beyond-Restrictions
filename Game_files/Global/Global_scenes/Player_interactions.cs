using Godot;
using System;

public partial class Player_interactions : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact")){

		}
	}

	public void _on_body_entered(Node3D body){
		if(body is Player){
			GD.Print("Player inside area");
		}
	}
}
