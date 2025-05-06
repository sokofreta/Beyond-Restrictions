using Godot;
using System;

public partial class FinishArea : Area3D
{
	public void PlayerFinished(Player body){
		if (body == null)return;

		if (Player.CanFinish){
			GetTree().ChangeSceneToFile("res://Game_files/Main_game.tscn");
		}
		else{
			GD.Print("You need the master key");
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
