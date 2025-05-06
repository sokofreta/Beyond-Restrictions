using Godot;
using System;

public partial class Chapter1 : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Connect(Button.SignalName.Pressed,Callable.From(ChangeScene));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ChangeScene(){
		GD.Print("Chapter_1!!!!");
	}
}
