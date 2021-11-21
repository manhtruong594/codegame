using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] List<GameObject> bullets = new List<GameObject>();
    [SerializeField] GameObject enemyBulletPrefabs;
    [SerializeField] List<GameObject> enemyBullets = new List<GameObject>();

    public GameObject GetBullet()
    {
        foreach(GameObject b in bullets)
        {
            if (b.activeSelf)
                continue;
            return b;
        }

        if (bulletPrefabs == null)
            bulletPrefabs = Resources.Load<GameObject>("Turret/bullet");

        GameObject b2 = Instantiate(bulletPrefabs, this.transform.position, Quaternion.identity);
        bullets.Add(b2);
        return b2;
    }

    public GameObject GetEnemyBullet()
    {
        foreach(GameObject b in enemyBullets)
        {
            if (b.activeSelf)
                continue;
            return b;
        }

        if (enemyBulletPrefabs == null)
            enemyBulletPrefabs = Resources.Load<GameObject>("Turret/bullet_Enemy");

        GameObject b2 = Instantiate((enemyBulletPrefabs), this.transform.position, Quaternion.identity);
        enemyBullets.Add(b2);
        return b2;
    }
}
