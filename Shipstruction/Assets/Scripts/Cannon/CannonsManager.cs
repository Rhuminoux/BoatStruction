using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsManager : MonoBehaviour
{
    public float fireSpeed = 3f;
    public int cannonNumb = 4;
    public GameObject bulletPrefab;
    public GameObject smokePrefab;
    private float   _lastShoot = -3f;

    private GameObject _newBullet;
    private void Start()
    {
 
    }

    void Update()
    {
        
    }

    public void Fire(GameObject cannons)
    {
        if (Time.time > _lastShoot + fireSpeed)
        {
            for (int i = 0; i < cannons.transform.childCount && i < cannonNumb; ++i)
            {
                _newBullet = GameObject.Instantiate(bulletPrefab, cannons.transform.GetChild(i).position, cannons.transform.GetChild(i).rotation);
                GameObject.Instantiate(smokePrefab, cannons.transform.GetChild(i).position, cannons.transform.GetChild(i).rotation);
                _newBullet.GetComponent<Rigidbody>().AddForce((cannons.transform.GetChild(i).rotation * Vector3.forward) * 20, ForceMode.Impulse);
            }
            _lastShoot = Time.time;
        }
    }

    public void AddCannon()
    {
        cannonNumb += 1;
    }

}
