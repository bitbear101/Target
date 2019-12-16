using Godot;
using System;
using System.Collections.Generic;

public class TurnQueue : Node2D
{
    Actor activeActor;

    public void ActorQueue()
    {
        foreach (string actions in activeActor.PlayTurn())
        {
            GD.Print(actions);
        }
        activeActor.PlayTurn();
        int newIndex = (activeActor.GetIndex() + 1) % GetChildCount();
        activeActor = GetChild<Actor>(newIndex);
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        activeActor = GetChild<Actor>(0);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ActorQueue();
    }
}