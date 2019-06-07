using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float LookSensitivity = 5f;

    private Rigidbody rb;
    public Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camrotation = Vector3.zero;

    Vector3 _Velocity;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        //velocity as 3dvector
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 MoveHori = transform.right * xMove * -1;
        Vector3 MoveVer = transform.forward * zMove * -1;

        Vector3 _Velocity = (MoveHori + MoveVer).normalized * speed;

        Move(_Velocity);

        // calculate rotation as a 3d vector
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 Rotation = new Vector3(0f, yRot, 0) * LookSensitivity;

        // apply rotation
        Rotate(Rotation);

        // calculate camera rotation as a 3d vector
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 CamRotation = new Vector3(xRot, 0f, 0f) * LookSensitivity;

        // apply rotation
        RotateCamera(CamRotation);
    }

    void Move(Vector3 _Velocity)
    {
        velocity = _Velocity;
    }

    void Rotate(Vector3 _Rotate)
    {
        rotation = _Rotate;
    }

    void RotateCamera(Vector3 _CamRotation)
    {
        camrotation = _CamRotation;
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        if (rotation != Vector3.zero)
        {
            rb.MovePosition(rb.position + rotation * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation *Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(camrotation*-1);
        }
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
}
