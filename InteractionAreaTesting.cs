using Godot;

public partial class InteractionAreaTesting : Area3D , InteractionInterface
{
    [Export] public bool IsActive = true;
    [Export] public Node3D ParentBody;

    public override void _Ready()
    {    
        
        //ParentBody = GetNode<StaticBody3D>(ParentBodyPath.ToString());

    }

     public void Interact(){
       GD.Print("You are interacting with: " + GetMeta("Shere"));
    }
}
