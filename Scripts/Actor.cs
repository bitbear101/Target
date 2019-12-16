using Godot;
using System;
using System.Collections.Generic;

public class Actor : Node
{
    GridMovement movement;
    public IEnumerable<string> PlayTurn()
    {
        yield return Move();
        //yield return Attack();
    }

    public string Move()
    {
        movement.GetMoveDir(0,1);
        return "Done Moving";
    }

    public string Attack()
    {
        return "Done Attacking";
    }

public void ActorInput()
{
    //Get the input from thte player or thte AI depending on the actor
}


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        movement = GetNode<GridMovement>("KenematicBody2D");
    }

      //Just to test hte movement
     public override void _Process(float delta)
     {
      }
}
