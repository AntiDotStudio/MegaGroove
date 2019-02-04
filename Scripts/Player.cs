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
	
	public _physics_Process(float delta){
		direction = Vector3(0, 0, 0);
		if (@event is InputEventKey eventKey){
        	if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Left){
            	direction.x -= 1;
			}
			else if(eventKey.Pressed && eventKey.Scancode == (int)KeyList.Right){
				direction.x += 1;
			}
			else if(eventKey.Pressed && eventKey.Scancode == (int)KeyList.Up){
				direction.z -= 1;
			}
			else if(eventKey.Pressed && eventKey.Scancode == (int)KeyList.Down){
				direction.z += 1;
			}
		}
		
		move_and_slide(direction, Vector3(0, 1, 0));
	}

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
