using Godot;
using System;

public class HUD : CanvasLayer
{
    Label healthLabel;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        healthLabel = GetNode<Label>("HealthLabel");
        GetNode<Node2D>("Health").Connect("HealthChanged", this, nameof(UpdateHealthChanged));
    }

    public void UpdateHealthChanged(int health)
    {
        healthLabel.Text = health.ToString();
    }

}
