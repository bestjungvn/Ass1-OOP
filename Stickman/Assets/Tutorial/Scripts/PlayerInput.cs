using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour {

    private PlayerMovement c_movement;  //Reference to PlayerMovement script
    private bool isJumping;             //To determine if the player is jumping
	Animator anim;
	int punchHash = Animator.StringToHash("punch");
	int kickHash = Animator.StringToHash("kick");
	
	void Awake()
    {
        //References
        c_movement = GetComponent<PlayerMovement>();
		anim = GetComponent<Animator> ();
	}
	
	void Update ()
    {
        //If he is not jumping...
		if (!isJumping) {
			//See if button is pressed...
			isJumping = CrossPlatformInputManager.GetButtonDown ("Vertical");
		}
		if (Input.GetKeyDown(KeyCode.Q)) {
			anim.SetTrigger (punchHash);
		}
		if (Input.GetKeyDown(KeyCode.W)) {
			anim.SetTrigger (kickHash);
		}
	}

    private void FixedUpdate()
    {
        //Get horizontal axis
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        //Call movement function in PlayerMovement
        c_movement.Move(h, isJumping);
        //Reset
        isJumping = false;
    }
}
