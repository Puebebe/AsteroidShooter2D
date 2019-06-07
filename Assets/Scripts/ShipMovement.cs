using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] float rotationSpeed;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float forward = Mathf.Clamp01(Input.GetAxis("Vertical")) * Time.deltaTime * forwardSpeed;
        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        
        rb.velocity += (Vector2)transform.up * forward;
        transform.Rotate(new Vector3(0, 0, rotation));
    }
}
