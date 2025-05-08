using Godot;
using System;

public partial class RoomCamera : Node3D
{
	OmniLight3D CameraLight;
	AnimationPlayer CameraAnimations;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CameraLight = GetNode<OmniLight3D>("CameraLight");
		CameraAnimations = GetNode<AnimationPlayer>("Animations");
		CameraLight.LightEnergy = 0;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void PlayerEnter(Player body){
		if (body == null){
			return;
		}

	 	CameraAnimations.Play("Detection");
	}

	public void PlayerExits(Player body){
		if (body == null){
			return;
		}

		CameraAnimations.Play("RESET");
	}
}
