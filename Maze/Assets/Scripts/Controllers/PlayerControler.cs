using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{

	
	public CharacterController characterControler;

	
	public float walkSpeed = 9.0f;
	
	public float jump = 7.0f;
	
	public float actuallyJump = 0f;
	
	public float runSpeed = 7.0f;

	
	public float sensitivityMouse = 3.0f;
	public float MouseUpDown = 0.0f;
	
	public float rangeMouse = 90.0f;

	

	void Start()
	{
		characterControler = GetComponent<CharacterController>();
	}

	
	void Update()
	{
		keyboard();
		mouse();
	}

	
	private void keyboard()
	{
		
		float moveUpDown = Input.GetAxis("Vertical") * walkSpeed;
		
		float moveLeftRight = Input.GetAxis("Horizontal") * walkSpeed;
		

		
		if (characterControler.isGrounded && Input.GetButton("Jump"))
		{
			actuallyJump = jump;
		}
		else if (!characterControler.isGrounded)
		{
			actuallyJump += Physics.gravity.y * Time.deltaTime;
		} 

		Debug.Log(Physics.gravity.y);

		
		if (Input.GetKeyDown("left shift"))
		{
			walkSpeed += runSpeed;
		}
		else if (Input.GetKeyUp("left shift"))
		{
			walkSpeed -= runSpeed;
		}

		
		Vector3 ruch = new Vector3(moveLeftRight, actuallyJump, moveUpDown);
		
		ruch = transform.rotation * ruch;

		characterControler.Move(ruch * Time.deltaTime);
	}


	private void mouse()
	{
		
		float mouseLeftRight = Input.GetAxis("Mouse X") * sensitivityMouse;
		transform.Rotate(0, mouseLeftRight, 0);

		
		MouseUpDown -= Input.GetAxis("Mouse Y") * sensitivityMouse;

		
		MouseUpDown = Mathf.Clamp(MouseUpDown, -rangeMouse, rangeMouse);
		
		Camera.main.transform.localRotation = Quaternion.Euler(MouseUpDown, 0, 0);
	}


}