using Godot;
using System;
using System.Collections.Generic;
using System.Threading;


interface InteractionInterface{
		public void Interact(){}
	}

public partial class Player : CharacterBody3D
{

	
	[Export] public float sencitivity = 0.02f;
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;
	Camera3D CharacterCamera;
	CustomSignals _Signals;
	public static bool CanFinish;

	Label InteractionLabel;

	public static List<Node3D> InventoryItems = new();
	private List<InteractionArea> Interactions = new();

	public override void _Ready()
	{

		base._Ready();
		CanFinish = false;
		Area3D InteractionGateway = GetNode<Area3D>("interaction_area");
		CharacterCamera = GetNode<Camera3D>("SpringArm3D/Camera3D");
		InteractionLabel = GetNode<Label>("../InteractionLabel");
		_Signals = GetNode<CustomSignals>("/root/CustomSignals");

		_Signals.AddToInvetory += NewItem;
		Input.MouseMode = Input.MouseModeEnum.Captured;
		InteractionLabel.Visible=false;

	}

    private void NewItem(Node3D item)
    {
		if (item.Name == "Master_Key") CanFinish=true;
		GD.Print(item.Name);
      	InventoryItems.Add(item);
    }

    public override void _Input(InputEvent @event)
	{
		if ( @event is InputEventMouseMotion motions){
			//RotateX(-motions.Relative.Y);
			RotateY(-motions.Relative.X * sencitivity);		
		}


	}
	
	public override void _PhysicsProcess(double delta){
		Vector3 velocity = Velocity;		
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _Process(double delta){
		InteractionArea[] InteractionsArray = Interactions.ToArray();
		InteractionArea Closest;
		
        if (InteractionsArray.Length != 0) // In case of no interaction avaiable just let-it-be. Better optimazation.
        {
            Closest = FindClosestInteraction(InteractionsArray);
			InteractionLabel.Text = Closest.ParentBody.Name;
			InteractionLabel.Visible=true;
			if (Input.IsActionJustPressed("interact")){
				Closest.Interact();
			}
        }
		else{
			InteractionLabel.Text = null;
			InteractionLabel.Visible=false;
		}
		
	}

	private InteractionArea FindClosestInteraction(InteractionArea[] InteractableObjects){
		InteractionArea NearestInteraction = InteractableObjects[0];
		Vector3 NearestInteractionDistaceFromPlayer = InteractableObjects[0].GlobalPosition - GlobalPosition;
        foreach (InteractionArea Interaction in InteractableObjects)
        {
			if (Interaction.GlobalPosition.DistanceTo(GlobalPosition) < NearestInteractionDistaceFromPlayer.DistanceTo(GlobalPosition)){
				NearestInteraction = Interaction;
				NearestInteractionDistaceFromPlayer = GlobalPosition - Interaction.GlobalPosition;
			}
        }
		// Update the label to say at which item player is interacting.
		// EXAMPLE: [E] to interact with {Slider, door, button etc....}
		return NearestInteraction;
    }

    public void AddInteraction(InteractionArea Interaction)
    {
		//if (!Interaction.IsActive) return;
        Interactions.Add(Interaction);
    }

    public void RemoveInteraction(InteractionArea Interaction)
    {
		//if (!Interaction.IsActive) return;
        Interactions.Remove(Interaction);
    }

}
