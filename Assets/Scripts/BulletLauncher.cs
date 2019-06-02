using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher
{
    [SerializeField] Bullet bulletPrefab;

    public void Launch()
    {
        Quaternion rotation = transform.rotation;
        Vector2 spawnPoint = transform.position + transform.up * bulletPrefab.transform.position.y;
        Vector2 baseVelocity = GetComponent<Rigidbody2D>().velocity;

        Bullet bullet = Instantiate(bulletPrefab, spawnPoint, rotation);
        bullet.Launch(baseVelocity);
    }
}
