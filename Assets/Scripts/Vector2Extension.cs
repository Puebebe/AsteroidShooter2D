using UnityEngine;

public static class Vector2Extension
{
    public static Vector2 Rotate(this Vector2 v, Quaternion r)
    {
        return Quaternion.Inverse(r) * v;
    }
}