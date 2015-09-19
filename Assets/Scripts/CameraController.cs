using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
    public GameObject playerGameObject;

    public float cameraXOffset;

	// Update is called once per frame
	void LateUpdate () 
    {
        transform.position = new Vector3(playerGameObject.transform.position.x - cameraXOffset, 0.0f, transform.position.z);
	}
}
