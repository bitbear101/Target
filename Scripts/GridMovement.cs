using Godot;
using System;

public class GridMovement : KinematicBody2D
{
    [Export]
    int speed = 150;
    int tileSize = 32;
    RayCast2D ray;
    Vector2 lastPosition = new Vector2();
    Vector2 targetPosition = new Vector2();
    Vector2 moveDir = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Get the raycast2d node from the main node
        ray = GetNode<RayCast2D>("../RayCast2D");
        //Set the current position to snap to a multiple of the tile size
        Position = Position.Snapped(new Vector2(tileSize, tileSize));
        //Set the initial value of the lastPosition to the current position
        lastPosition = Position;
        //Set the initial targe position to the current position so as not to move 
        targetPosition = Position;
    }

    public override void _Process(float delta)
    {
        //If we detect a collision we snap the player back to his previous position and reset teh target position as well
        if (ray.IsColliding())
        {
            Position = lastPosition;
            targetPosition = lastPosition;
        }
        else
        {
            GD.Print("Before Position = " + Position);
            //Move the position towards the move drection
            Position += moveDir * speed * delta;
GD.Print("After Position = " + Position);

            if (Position.DistanceTo(lastPosition) >= tileSize - speed * delta)
            {
                Position = targetPosition;
            }
        }
        //If we are not in position
        if (Position == targetPosition)
        {
            Move();
            lastPosition = Position;
            targetPosition += moveDir * tileSize;
        }
    }
    public void GetMoveDir(int xMove, int yMove)
    {
        moveDir.x = xMove;
        moveDir.y = yMove;
        //moveDir.x = Convert.ToInt16(Input.IsActionPressed("right")) - Convert.ToInt16(Input.IsActionPressed("left"));
        //moveDir.y = Convert.ToInt16(Input.IsActionPressed("down")) - Convert.ToInt16(Input.IsActionPressed("up"));
    }
    private void Move()
    {
        //Check if the player is trying to move diagonaly then we set the movement to zero as it is not allowed
        if (moveDir.x != 0 && moveDir.y != 0) moveDir = Vector2.Zero;
        //If the player is moving cast the ray towards the move direction but only as far as half the tile size
        if (moveDir != Vector2.Zero) ray.CastTo = moveDir * tileSize / 2;
    }

}
