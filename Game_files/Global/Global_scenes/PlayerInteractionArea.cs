using Godot;
using System.Collections.Generic;


public partial class PlayerInteractionArea : Area3D
{

    private List<Node3D> Interactions;

    public override void _Process(double delta)
    {
        base._Process(delta);

        Node3D[] InteractionsArray = Interactions.ToArray();
        if (InteractionsArray.Length != 0)
        {
            GD.Print("WE have on here");
            FindClosestInteraction(InteractionsArray);
        }



    }

    private void FindClosestInteraction(Node3D[] EveryInteraction)
    {
        foreach (Node3D intereaction in EveryInteraction)
        {
            GD.Print(intereaction);
        }
    }


    public void AddInteraction(Node3D Interaction)
    {
        Interactions.Add(Interaction);
    }

    public void RemoveInteraction(Node3D Interaction)
    {
        Interactions.Remove(Interaction);
    }

}
