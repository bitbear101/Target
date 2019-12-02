using Godot;
using System;

public class BodyLayout : Node2D
{
    int head = 100, chest = 100, leftArm = 100, rightArm = 100, torso = 100, leftLeg = 100, rightLeg = 100;
    public enum BodyParts
    {
        Head = 0,
        Chest,
        LeftArm,
        RightArm,
        Torso,
        LeftLeg,
        RightLeg
    };

    void _ready()
    {
        Timer timer = new Timer();
        timer.Connect("timeout", this, "testDamage");
        AddChild(timer);
        timer.SetWaitTime(.5f);
        timer.Start();
    }

    public void SetBodyPartHealth(BodyParts part, float health)
    {
        //Get the sprite for the body part that the color will be changed
        Sprite tempBodyPart = null;
        switch (part)
        {
            case BodyParts.Chest:
                tempBodyPart = GetNode<Sprite>("Chest");
                break;
            case BodyParts.Head:
                tempBodyPart = GetNode<Sprite>("Head");
                break;
            case BodyParts.LeftArm:
                tempBodyPart = GetNode<Sprite>("LeftArm");
                break;
            case BodyParts.LeftLeg:
                tempBodyPart = GetNode<Sprite>("LeftLeg");
                break;
            case BodyParts.RightArm:
                tempBodyPart = GetNode<Sprite>("RightArm");
                break;
            case BodyParts.RightLeg:
                tempBodyPart = GetNode<Sprite>("RightLeg");
                break;
            case BodyParts.Torso:
                tempBodyPart = GetNode<Sprite>("Torso");
                break;
        }
        //Check that the sprite is not empty - error checking
        if (tempBodyPart == null) return;
        //Set the new red hue of the sprite according to the health
        tempBodyPart.SetSelfModulate(new Color(1, health / 100, health / 100));
    }

    public void testDamage()
    {
        head -= 3;
        chest -= 6;
        leftArm -= 9;
        rightArm -= 6;
        torso -= 3;
        leftLeg -= 3;
        rightLeg -= 9;

        SetBodyPartHealth(BodyParts.Head, head);
        SetBodyPartHealth(BodyParts.Chest, chest);
        SetBodyPartHealth(BodyParts.LeftArm, leftArm);
        SetBodyPartHealth(BodyParts.RightArm, rightArm);
        SetBodyPartHealth(BodyParts.Torso, torso);
        SetBodyPartHealth(BodyParts.LeftLeg, leftLeg);
        SetBodyPartHealth(BodyParts.RightLeg, rightLeg);
    }

}
