using UnityEngine;

public class Weapon : MonoBehaviour
{
    ILauncher launcher;
    float fireRefreshRate = 0.5f;
    float nextFireTime;

    void Awake()
    {
        launcher = GetComponent<ILauncher>();
    }

    void Update()
    {
        if (CanFire())
            FireWeapon();
    }

    bool CanFire()
    {
        return Time.time >= nextFireTime;
    }

    void FireWeapon()
    {
        nextFireTime += fireRefreshRate;
        launcher.Launch();
    }
}