using UnityEngine;

public class Ship : MonoBehaviour
{
    public void Destroy()
    {
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
