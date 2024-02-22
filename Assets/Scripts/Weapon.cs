using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammo;
    public int maxAmmo = 10;
    public bool isReloading;
    public bool isAutomatic;
    public float fireInterval = 0.1f;
    float fireCooldown;
    public float reloadTime = 2;

    public float bulletsPerShot;
    public float spreadAngle = 5;
    public int clipAmmo;
    public int clipSIze;

    public UnityEvent onRightCLick;
    public UnityEvent onShoot;
    public UnityEvent onReload;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            onRightCLick.Invoke();
        }
        if (!isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        // automatic shooting
        if (isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        if(isReloading) return;
        if (clipAmmo <= 0)
        {
            Reload();
            return;
        }
        if(fireCooldown > 0) return;

        onShoot.Invoke();

        clipAmmo--;
        fireCooldown = fireInterval;
        for (int i = 0; i < bulletsPerShot; i++)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            var offSetX = Random.RandomRange(-spreadAngle, +spreadAngle);
            var offSetY = Random.RandomRange(-spreadAngle, +spreadAngle);
            bullet.transform.eulerAngles += new Vector3(offSetX, offSetY, 0);
        }
    }

    async void Reload()
    {
        if (clipAmmo == clipSIze) return;
        if(isReloading) return;

        isReloading = true;

        onReload.Invoke();

        print ("Reloading...");
        await new WaitForSeconds(reloadTime);
        print("Reloaded!");

        isReloading = false;
        //ammo = maxAmmo;
        var ammoNeeded = Mathf.Min(clipSIze - clipAmmo, 1);
        ammo -= ammoNeeded;
        clipAmmo += ammoNeeded;
    }
}