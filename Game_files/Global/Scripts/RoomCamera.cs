using Godot;
using System;

public partial class RoomCamera : Node3D
{
	OmniLight3D CameraLight;
	AnimationPlayer CameraAnimations;
	Timer CameraTimer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CameraLight = GetNode<OmniLight3D>("CameraLight");
		CameraAnimations = GetNode<AnimationPlayer>("Animations");

		// Camera light Configuration
		CameraTimer = GetNode<Timer>("TimeToDetect");
		CameraTimer.Timeout += OnTimeOut; // When signal Timeout is emited call funation OnTimeOut;
		CameraLight.LightEnergy = 0;

	}

    private void OnTimeOut()
    {
		CameraTimer.Stop();
        CameraLight.LightColor = new Color((float)0.545098, 0, 0, 1);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

	public void PlayerEnter(Player body){
		if (body == null){
			return;
		}
		CameraLight.LightColor = new Color(0, 1, 0, 1);
		CameraTimer.Start(3);
	 	CameraAnimations.Play("Detection");
	}

	public void PlayerExits(Player body){
		if (body == null){
			return;
		}
		CameraTimer.Stop();
		CameraAnimations.Play("RESET");
	}
}
