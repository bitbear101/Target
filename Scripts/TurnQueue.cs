    using Godot;
using System;

public class TurnQueue : Node2D
{
    Node activeActor;
    public void Init()
    {
activeActor = GetChild(0);
    }

public void PlayTurn()
{
    yield return new(activeActor.PlayTurn(), "Done")
    int newIndex = (activeActor.GetIndex() + 1) % GetChildCount();
    activeActor = GetChild(newIndex);
}
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
