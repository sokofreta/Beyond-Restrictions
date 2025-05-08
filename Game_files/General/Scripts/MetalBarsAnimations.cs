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
		if (GetNodeOrNull<InteractionArea>("MetalDoorInteractionArea") != null){
			InteractionArea = GetNodeOrNull<InteractionArea>("MetalDoorInteractionArea");
			HasInteraction = true;
			IsInteractable = true;
			IsLocked = true;
			IsUnlocked = false;
			AfterReady = true;
			CanUnlock = false;
		}
	}

	public void Interaction(){
		if(!IsInteractable)
		{
			return;
		}

		if(Player.InventoryItems.Count > 0){
			Player.InventoryItems.ForEach(item => {
					if(item.Name == "masterKey"){
						CanUnlock = true;
					}
			});

		}
		else return;

		if(IsLocked && CanUnlock){
			IsLocked = false;
			CanUnlock = false;
			MetalDoorAnimations.Play("UnlockDoorWithSlider");
			return;
		}

		if (IsUnlocked){
			IsInteractable = false;
			MetalDoorAnimations.Play("Open_metal_door");
		}
		
		
	}

	public void FinishedAnimations(StringName animation){
		if (animation.Equals("UnlockDoorWithSlider")){
			IsUnlocked = true;
		}
	}
}
