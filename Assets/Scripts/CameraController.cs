using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform ship;
    Vector3 offsetPosition;

    void Start()
    {
        offsetPosition = transform.position - ship.position;
    }
    
    void LateUpdate()
    {
        if (ship != null)
            FollowShip();
    }

    void FollowShip()
    {
        transform.position = ship.position + offsetPosition;
        transform.rotation = ship.rotation;
    }
}
