using Godot;
using System;

public partial class Chapetrs_controler : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GridContainer container = GetNode<GridContainer>("Chapter_con");

		container.GetChild<Button>(0).Pressed += () => { TransferToScene(1); };
		container.GetChild<Button>(1).Pressed += () => { TransferToScene(2); };
		container.GetChild<Button>(2).Pressed += () => { TransferToScene(3); };
		container.GetChild<Button>(3).Pressed += () => { TransferToScene(4); };
		container.GetChild<Button>(4).Pressed += () => { TransferToScene(5); };
		container.GetChild<Button>(5).Pressed += () => { TransferToScene(6); };

		// for (int i = 0;i<container.GetChildCount();i++){
		// 	container.GetChild<Button>(i).Pressed += () => { TransferToScene(i+1); };
		// }
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void TransferToScene(Variant i){
		GetTree().ChangeSceneToFile("res://Organized_files/Main_game.tscn");
		GD.Print ("Chapter_"+ i);
	}
}
