using Godot;
using System;

public class Movement : KinematicBody2D
{
    [Export]
    int maxSpeed = 400;
    int acceleration = 2000;

    Vector2 motion = Vector2.Zero;

    private Vector2 GetAxis()
    {
        Vector2 axis = Vector2.Zero;
        axis.x = Convert.ToInt16(Input.IsActionPressed("right")) - Convert.ToInt16(Input.IsActionPressed("left"));
        axis.y = Convert.ToInt16(Input.IsActionPressed("down")) - Convert.ToInt16(Input.IsActionPressed("up"));
        return axis.Normalized();
    }

    private void ApplyFriction(float amount)
    {
        if (motion.Length() > amount)
        {
            motion -= motion.Normalized() * amount;
        }
        else
        {
            motion = Vector2.Zero;
        }
    }

    private void ApplyMovement(Vector2 acell)
    {
        motion += acell;
        motion = motion.Clamped(maxSpeed);
    }
    public override void _PhysicsProcess(float delta)
    {
        Vector2 axis = GetAxis();
        if (axis == Vector2.Zero)
        {
            ApplyFriction(acceleration * delta);
        }
        else
        {
            ApplyMovement(axis * acceleration * delta);
            motion = MoveAndSlide(motion);
        }
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
