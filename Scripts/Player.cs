using Godot;
using System;

public class Player : KinematicBody
{
	public int speed = 200;
	public Vector3 direction = new Vector3();
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }
	
	private float runSpeed = 350;
    private float jumpSpeed = -1000;
    private float gravity = 2500;

    private Vector3 velocity = new Vector3();

    private void getInput()
    {
        velocity.x = 0;

        var right = Input.IsActionPressed("ui_right");
        var left = Input.IsActionPressed("ui_left");
        var jump = Input.IsActionPressed("ui_select");

        if (IsOnFloor() && jump)
            velocity.y = jumpSpeed;
        if (right)
            velocity.x += runSpeed;
        if (left)
            velocity.x -= runSpeed;
    }

    public override void _PhysicsProcess(float delta)
    {
        velocity.y += gravity * delta;
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
