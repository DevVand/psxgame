using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public float looksmooth = 8;
    public bool looking = false;
    public Transform lookTo;
    public bool foving = false;
    public float to_fov;
    Vector2 mouse = new Vector2(0, 0);

    public bool active = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (looking)
        {
            GameObject empty = new GameObject();
            Transform to = empty.transform;
            to.position = cameraholder.position;
            to.LookAt(lookTo);

            GameObject empty2 = new GameObject();
            Transform position = empty2.transform;
            position.position = cameraholder.position;
            position.rotation = cameraholder.rotation;

            position.rotation = Quaternion.Lerp(position.rotation, to.rotation, Time.deltaTime * looksmooth);
            capsule.eulerAngles = new Vector3(capsule.eulerAngles.x, position.eulerAngles.y, capsule.eulerAngles.z);
            cameraholder.eulerAngles = new Vector3(position.eulerAngles.x, cameraholder.eulerAngles.y, cameraholder.eulerAngles.z);
            mouse = Vector2.zero;
            xRotation = position.eulerAngles.x;
            Destroy(empty);
            Destroy(empty2);
        }
        Camera.main.fieldOfView = fov;
        //transform.eulerAngles = new Vector3(xRotation, capsule.eulerAngles.y, 0);
    }
    private void FixedUpdate()
    {
        
        if (!looking && active)
        {
            mouse += new Vector2(Input.GetAxis("Mouse X") * mouse_sensibility * Time.deltaTime, -Input.GetAxis("Mouse Y") * mouse_sensibility * Time.deltaTime);

            xRotation += mouse.y;

            xRotation = Mathf.Clamp(xRotation, -90, 90);

            capsule.Rotate(capsule.transform.up * mouse.x);
            cameraholder.eulerAngles = new Vector3(xRotation, capsule.eulerAngles.y, 0);

            mouse *= mouse_friction;
        }

        if (foving) {
            fov = Mathf.Lerp(fov, to_fov, 0.05f);
        }
        else if (Input.GetMouseButton(1))
        {
            fov = Mathf.Lerp(fov, zoom_fov, 0.05f);
        }
        else if (Input.GetButton("Run"))
        {
            fov = Mathf.Lerp(fov, run_fov, 0.05f);
        }
        else
        {
            fov = Mathf.Lerp(fov, main_fov, 0.05f);
        }
    }

    public void disableMovement() {
        active = false;
    }
    public void enableMovement()
    {
        active = true;
    }
    public void changeSensibility(float to) {
        mouse_sensibility = to * 20;
    }

    public void fovTo(float to) {
        to_fov = to;
        foving = true;
    }

    public void noFovTo()
    {
        foving = false;
    }
    public void lookAt(Transform to) {
        looking = true;
        lookTo = to;
    }
    public void noLookAt()
    {
        looking = false;
    }


}