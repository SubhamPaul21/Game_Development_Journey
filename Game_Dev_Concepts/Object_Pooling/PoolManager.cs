using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject bulletContainer;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int bulletCapacity = 5;
    private static PoolManager _instance;
    public static PoolManager Instance{ get {return _instance;}}
    private List<GameObject> _bulletPool;

    private void Awake() 
    {
        //Initialize pool manager singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);   
    }

    private void Start() 
    {
        _bulletPool = GenerateBullets();  
    }

    // Pre-instantiate a list of bullets using the bullet prefab
    List<GameObject> GenerateBullets()
    {
        List<GameObject> bullets = new List<GameObject>();
        for(int i=0; i < bulletCapacity; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, Quaternion.identity) as GameObject;
            bullet.transform.parent = bulletContainer.transform;
            bullet.SetActive(false);
            bullets.Add(bullet);
        }

        return bullets;
    }

    // Provide bullets on request
    public GameObject RequestBullet()
    {
        print("Requested bullet");
        foreach(GameObject bullet in _bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, Quaternion.identity) as GameObject;
        newBullet.transform.parent = bulletContainer.transform;
        _bulletPool.Add(newBullet);
        return newBullet;
    }

}
