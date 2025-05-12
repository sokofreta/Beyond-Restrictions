using Godot;
using System;

public partial class MetalBarsAnimations : Node3D
{
	InteractionArea InteractionArea;
	AnimationPlayer MetalDoorAnimations;
	bool HasInteraction;
	bool IsInteractable;
	bool CanUnlock;
	bool IsLocked;
	bool IsUnlocked;
	bool AfterReady = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MetalDoorAnimations = GetNode<AnimationPlayer>("Animations");
		Name = "Locked Metal Door";

		Variant TypeOfDoor = GetMeta("TypeOfDoor");
		if (GetNodeOrNull<InteractionArea>("MetalDoorInteractionArea") != null){
			InteractionArea = GetNodeOrNull<InteractionArea>("MetalDoorInteractionArea");
			HasInteraction = true;
			IsInteractable = true;
			AfterReady = true;
			CanUnlock = false;
			IsLocked = true;
			CanUnlock = false;
			
			if((int)TypeOfDoor == 0){
				CanUnlock = true;
			}
			GD.Print(IsLocked && CanUnlock);
		}
	}

	public void Interaction(){
		if(!IsInteractable)
		{
			return;
		}

		if(Player.InventoryItems.Count > 0){
			Player.InventoryItems.ForEach(item => {
					if(item.Name == "MasterKey"){
						CanUnlock = true;
					}
			});

		}

		if(IsLocked && CanUnlock){
			IsLocked = false;
			CanUnlock = false;
			MetalDoorAnimations.Play("UnlockDoorWithSlider");
			return;
		}

		if (IsUnlocked){
			IsInteractable = false;
			MetalDoorAnimations.Play("Open_metal_door");
			Name = " ";
		}
		
		
	}

	public void FinishedAnimations(StringName animation){
		if (animation.Equals("UnlockDoorWithSlider")){
			IsUnlocked = true;
			Name = "Unlocked Metal Door";
		}
	}
}
