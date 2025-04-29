using Godot;
using System.Collections.Generic;


interface InteractionInterface{
		public void Interact(){}
	}

public partial class Player : CharacterBody3D
{

	
	[Export] public float sencitivity = 0.02f;
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;
	Camera3D CharacterCamera;
	private List<InteractionAreaTesting> Interactions = new();

	public override void _Ready()
	{

		base._Ready();
		Area3D InteractionGateway = GetNode<Area3D>("interaction_area");
		CharacterCamera = GetNode<Camera3D>("SpringArm3D/Camera3D");
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}
	
	public override void _Input(InputEvent @event)
	{
		if ( @event is InputEventMouseMotion motions){
			//RotateX(-motions.Relative.Y);
			RotateY(-motions.Relative.X * sencitivity);	

			// CharacterCamera.RotateY(-motions.Relative.X * sencitivity);			
			// CharacterCamera.RotateX(-motions.Relative.Y * sencitivity);			
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

		if (Input.IsActionJustPressed("interact")){
			InteractionAreaTesting[] InteractionsArray = Interactions.ToArray();
        	if (InteractionsArray.Length != 0) // In case of no interaction avaiable just let-it-be. Better optimazation.
        	{
            	FindClosestInteraction(InteractionsArray).Interact();
        	} 
			//InteractionAreaTesting.Interaction();
			// Area3D InteractableObject = FindClosestInteraction(Interactions.ToArray());
			// InteractableObject.Interaction();
		}
	}

	private InteractionAreaTesting FindClosestInteraction(InteractionAreaTesting[] InteractableObjects){
		InteractionAreaTesting NearestInteraction = InteractableObjects[0];
		Vector3 NearestInteractionDistaceFromPlayer = InteractableObjects[0].GlobalPosition - GlobalPosition;
        foreach (InteractionAreaTesting Interaction in InteractableObjects)
        {
			GD.Print(Interaction.Name + "  Distace To Player: " + Interaction.GlobalPosition.DistanceTo(GlobalPosition));
			GD.Print(Interaction.GlobalPosition.DistanceTo(GlobalPosition) < NearestInteractionDistaceFromPlayer.DistanceTo(GlobalPosition));
			if (Interaction.GlobalPosition.DistanceTo(GlobalPosition) < NearestInteractionDistaceFromPlayer.DistanceTo(GlobalPosition)){
				NearestInteraction = Interaction;
				NearestInteractionDistaceFromPlayer = GlobalPosition - Interaction.GlobalPosition;
			}
        }

		return NearestInteraction;
    }

    public void AddInteraction(InteractionAreaTesting Interaction)
    {
		//if (!Interaction.IsActive) return;
        Interactions.Add(Interaction);
    }

    public void RemoveInteraction(InteractionAreaTesting Interaction)
    {
		//if (!Interaction.IsActive) return;
        Interactions.Remove(Interaction);
    }

}
