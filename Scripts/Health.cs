using Godot;
using System;

public class Health : Node2D
{
    [Signal] 
    public delegate void HealthChanged();
    [Export]
    int myHealth;

    

    public void TakeDamage(int damage)
    {
        myHealth -= damage;
        EmitSignal(nameof(HealthChanged), myHealth);
    }

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Label healthLabel = GetNode<Label>("../HealthLabel");
        healthLabel.Text = "Label Ready";
    }

// Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _Process(float delta)
  {
      TakeDamage(1);
      GD.Print(myHealth);
  }
}
