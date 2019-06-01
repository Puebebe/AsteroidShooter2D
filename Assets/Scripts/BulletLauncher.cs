using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher
{
    [SerializeField] Bullet bulletPrefab;

    public void Launch(Weapon weapon)
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.Launch(weapon.transform.up);
    }
}
