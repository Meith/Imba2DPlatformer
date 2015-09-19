using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float playerSpeed;

    private Rigidbody playerRigidBody;

	void Start () 
    {
        playerRigidBody = GetComponent<Rigidbody>();	
	}
	
	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Add jump here later.
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        playerRigidBody.AddForce(movement * playerSpeed);
    }
}
