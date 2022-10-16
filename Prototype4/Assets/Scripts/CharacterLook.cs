using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
    }
}