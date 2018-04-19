﻿// This code is taken from https://forum.unity.com/threads/looking-with-the-mouse.109250/

using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset its transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    public bool lockCameraWithMouse = false;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    private Camera attachedCamera;

    float rotationY = 0F;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Spherecast
            Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
            RaycastHit hitInfo;
            Physics.SphereCast(ray, 2f, out hitInfo);
            if (hitInfo.collider != null)   // we got a hit
            {
                Debug.Log("User clicked on " + hitInfo.collider.gameObject.name);
                GameObject go = hitInfo.collider.gameObject;
                if (go.tag == "Lore")
                {
                    Dialogue.getInstance().Display(go.GetComponent<Lore>().lore);
                }
            }
        }


        // don't let the player move the camera if the cursor is visible
        if (Cursor.visible)
            return;

        if (lockCameraWithMouse && Input.GetKey(KeyCode.Mouse1))   //only move the camera if the right mouse button is being held. 
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                attachedCamera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                transform.localEulerAngles = new Vector3(0, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                attachedCamera.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                attachedCamera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            }
        }
        else if(!lockCameraWithMouse)
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                attachedCamera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                transform.localEulerAngles = new Vector3(0, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                attachedCamera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            }
        }
    }

    void Start()
    {
        //if(!networkView.isMine)
        //enabled = false;

        // Make the rigid body not change rotation
        //if (rigidbody)
        //rigidbody.freezeRotation = true;
        attachedCamera = GetComponentInChildren<Camera>();
        HideCursor();
    }

    // locks and hides the cursor
    void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ToggleCursor()
    {
        if (Cursor.visible)
            HideCursor();
        else
            ShowCursor();
    }
}
