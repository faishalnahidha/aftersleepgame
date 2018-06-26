using UnityEngine;

//=================================================================
//           This PlayerMovement class translate diagonally
//=================================================================

public class PlayerMovement2 : PlayerMovement
{
	Vector3 v3;
	
	/*public void override Awake(){
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	void FixedUpdate(){

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		
		Move (h,v);
		Turning ();
		Animating (h, v);
	}*/
	
	public override void Move (float h, float v){

		v3.Set (h, 0f, v);
		
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {  
			v3 = v3 + (Vector3.forward + Vector3.left + Vector3.left);  
		}  
		if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) {  
			v3 = v3 + (Vector3.back + Vector3.right + Vector3.right);  
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {  
			v3 = v3 + (Vector3.left + Vector3.back + Vector3.back);  
		}    
		else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {    
			v3 = v3 + (Vector3.right + Vector3.forward + Vector3.forward); 
		}  
		
		//transform.Translate(speed * v3.normalized * Time.deltaTime);
		//movement.Set (h, 0f, v);
		//movement = movement.normalized * speed * Time.deltaTime ;

		playerRigidbody.MovePosition (transform.position + (speed * v3.normalized * Time.deltaTime));

	}
	
	/*void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		RaycastHit floorHit;
		
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}
	
	void Animating(float h, float v){
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}*/
}





