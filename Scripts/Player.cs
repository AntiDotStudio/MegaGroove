using Godot;
using System;

public class Player : KinematicBody
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

	Vector3 toCenter = new Vector3();

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
		toCenter = new Vector3(0, 0, 0);
        
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
		if(timeCounter >= 1){
			timeCounter = 0;
		}
		velocity = new Vector3();
        GetInput();
		velocity.y -= 5;
		tempVector = new Vector3();
		//MoveAndSlide(new Vector3(10*Mathf.Cos(-(2 * 3.14f * timeCounter)), 0, 10*Mathf.Sin(2 * 3.14f * timeCounter)));
		GD.Print((velocity.x*Mathf.Acos(-1)));
		GD.Print(this.Translation);
		//GD.Print(Mathf.Cos(10));
        if(isRight == true){
			tempVector = new Vector3(velocity.x*Mathf.Cos(timeCounter), 0, velocity.z*Mathf.Sin(timeCounter));
			MoveAndSlide(tempVector.Normalized());
		}else{
			tempVector = new Vector3(velocity.x*Mathf.Cos(timeCounter), 0, velocity.z*(-Mathf.Sin(timeCounter)));
			MoveAndSlide(tempVector.Normalized());
		}
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
