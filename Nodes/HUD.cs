using Godot;
using System;

public class HUD : CanvasLayer
{
    Label healthLabel;
    int health;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        healthLabel = GetNode<Label>("HealthLabel");
        GetNode<Node2D>("Health").Connect("HealtChanged", this, nameof(UpdateHealthChanged), health);
    }

    public void UpdateHealthChanged(int _health)
    {
        healthLabel.Text = health.ToString();
    }

}
