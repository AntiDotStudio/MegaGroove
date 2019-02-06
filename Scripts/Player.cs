using Godot;
using System;

public class Player : KinematicBody
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }
	
	[Export] public int Speed = 20;
	[Export] float timeCounter;
	[Export] int mapRadius = 10;
	[Export] bool isRight = false;
    Vector3 velocity = new Vector3();
	private Vector3 tempVector = new Vector3();

    public void GetInput()
    {
        velocity = new Vector3();
        if (Input.IsActionPressed("ui_right")){
            velocity.x -= mapRadius;
			velocity.z += mapRadius;
			isRight = true;
        }else if (Input.IsActionPressed("ui_left")){
            velocity.x -= mapRadius;
			velocity.z += mapRadius;
			isRight = false;
        }else{
			velocity.x = 0;
			velocity.z = 0;
		}
        
		
		
    }

    public override void _PhysicsProcess(float delta)
    {
		timeCounter += delta;
		velocity = new Vector3();
        GetInput();
		velocity.y -= 5;
		tempVector = new Vector3();
        if(isRight == true){
			tempVector = new Vector3(velocity.x*Mathf.Cos(timeCounter), 0, velocity.z*Mathf.Sin(timeCounter));
			MoveAndSlide(tempVector);
		}else{
			tempVector = new Vector3(Mathf.Abs(velocity.x*Mathf.Acos(timeCounter)), 0, Mathf.Abs(velocity.z*Mathf.Asin(timeCounter)));
			MoveAndSlide(tempVector);
		}
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
