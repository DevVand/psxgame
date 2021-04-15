using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform capsule;
    public Transform cameraholder;
    private float fov = 80;

    public float mouse_sensibility = 80;
    public float mouse_friction = .95f;
    float xRotation = 0;

    public float main_fov = 60;
    public float run_fov = 80;
    public float zoom_fov = 30;

    Vector2 mouse = new Vector2(0, 0);

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
        mouse += new Vector2(Input.GetAxis("Mouse X") * mouse_sensibility * Time.deltaTime, -Input.GetAxis("Mouse Y") * mouse_sensibility * Time.deltaTime);
        
        xRotation += mouse.y;

        xRotation = Mathf.Clamp(xRotation, -90, 90);
        //transform.eulerAngles = new Vector3(xRotation, capsule.eulerAngles.y, 0);

        mouse *= mouse_friction;

        if (Input.GetMouseButton(1))
        {
            fov = Mathf.Lerp(fov, zoom_fov, 0.05f);

        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            fov = Mathf.Lerp(fov, run_fov, 0.05f);
        }
        else
        {

            fov = Mathf.Lerp(fov, main_fov, 0.05f);
        }

        Camera.main.fieldOfView = fov;
    }
    private void FixedUpdate()
    {
        capsule.Rotate(capsule.transform.up * mouse.x);

        cameraholder.eulerAngles = new Vector3(xRotation, capsule.eulerAngles.y, 0);
    }

}