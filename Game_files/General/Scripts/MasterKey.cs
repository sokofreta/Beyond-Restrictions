using Godot;
using System;

public partial class MasterKey : Node3D
{
	CustomSignals _Signals;
	MeshInstance3D VisibleKey;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_Signals = GetNode<CustomSignals>("/root/CustomSignals");
		VisibleKey = GetNode<MeshInstance3D>("MasterKey");
		Name = "Master_Key";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Interaction(){
		_Signals.EmitSignal(nameof(CustomSignals.AddToInvetory), this);
		VisibleKey.QueueFree();

		//QueueFree(); // Remove current object from the the runtime.
	}
	
}
