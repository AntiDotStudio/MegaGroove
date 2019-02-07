using Godot;
using System;
using System.Numerics;
using System.Numerics.Complex;

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
	float dotCalculationAcos;
	[Export] public Vector3 mapCenter = new Vector3(0, 0, 0);
	private Vector3 tempVector = new Vector3();

    public void GetInput()
    {
        velocity = new Vector3();
        if (Input.IsActionPressed("ui_right")){
            velocity.x += 10;
			velocity.z += 10;
			isRight = true;
        }else if (Input.IsActionPressed("ui_left")){
            velocity.x -= 10;
			velocity.z -= 10;
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
		//MoveAndSlide(new Vector3(10*Mathf.Cos(-(2 * 3.14f * timeCounter)), 0, 10*Mathf.Sin(2 * 3.14f * timeCounter)));
		//GD.Print(Mathf.Deg2Rad(timeCounter));
		//GD.Print(Mathf.Abs(Mathf.Cos(timeCounter)));
		//Complex valueComplex = new Complex(1, 1);
		//GD.Print(this.Translation);
		Complex c = Complex.Sqrt(-1);
		c = Mathf.Sqrt(c);
		GD.Print(-c*Mathf.Log(timeCounter + c*Mathf.Pow((1 - Mathf.Pow(timeCounter, 2)), 1/2)));
		Vector3 distanceToCenter = mapCenter - this.Translation;
		distanceToCenter = distanceToCenter.Normalized();
        if(isRight == true){
			tempVector = new Vector3(velocity.x*Mathf.Cos(distanceToCenter.x), 0, velocity.z*Mathf.Sin(distanceToCenter.z));
			MoveAndSlide(tempVector);
		}else{
			tempVector = new Vector3(velocity.x*(-1/(Mathf.Sqrt(1-Mathf.Pow(distanceToCenter.x, 2)))), 0, velocity.z*(-1/(Mathf.Sqrt(1-Mathf.Pow(distanceToCenter.z, 2)))));
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
