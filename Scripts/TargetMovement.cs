using Godot;
using System;

public class TargetMovement : Area2D
{
    private Random _random = new Random();
    private float RandRange(float min, float max)
    {
        return (float)_random.NextDouble() * (max - min) + min;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    /*
        // Choose a random location on Path2D.
        PathFollow2D mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
        mobSpawnLocation.SetOffset(_random.Next());

        // Create a Mob instance and add it to the scene.
        RigidBody2D mobInstance = (RigidBody2D)mob.Instance();
        AddChild(mobInstance);

        // Set the mob's direction perpendicular to the path direction.
        float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;

        // Set the mob's position to a random location.
        mobInstance.Position = mobSpawnLocation.Position;

        // Add some randomness to the direction.
        direction += RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
        mobInstance.Rotation = direction;

        // Choose the velocity.
        mobInstance.SetLinearVelocity(new Vector2(RandRange(150f, 250f), 0).Rotated(direction));

        GetNode("HUD").Connect("StartGame", mobInstance, "OnStartGame");
        */
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
