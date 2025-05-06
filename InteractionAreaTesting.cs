using Godot;

public partial class InteractionAreaTesting : Area3D ,InteractionInterface
{
    [Export] public bool IsActive = true;
    [Export] public Node3D ParentBody;

    public override void _Ready()
    {    
        base._Ready();
        //ParentBody = GetNode<GodotObject>(ParentBody.get);

    }

     public void Interact(){
        //GD.Print("You are interacting with: " + ParentBody.Name);
        ParentBody.Call("Interaction");

    }
}
