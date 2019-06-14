using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public static Camera cam;
    public static Rect view;
    [SerializeField] Transform ship;
    Vector3 offsetPosition;
    float xView, yView;

    void Start()
    {
        cam = GetComponent<Camera>();
        xView = cam.orthographicSize * cam.aspect;
        yView = cam.orthographicSize;
        view = new Rect(-xView, -yView, xView * 2f, yView * 2f);

        offsetPosition = transform.position - ship.position;
    }

    void LateUpdate()
    {
        if (ship != null)
            FollowShip();
        
        view.x = transform.position.x - xView;
        view.y = transform.position.y - yView;
    }

    void FollowShip()
    {
        transform.position = ship.position + offsetPosition;
        transform.rotation = ship.rotation;
    }
}
