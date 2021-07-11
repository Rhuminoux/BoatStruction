using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject smokePrefab;
    
    protected int _hp;

    protected Rigidbody _rb;
    protected int _value;
    protected int _speed;

    protected float fireSpeed = 3f;
    protected float _lastShoot = -3f;

    protected GameObject _newBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void LoseHealth()
    {
        _hp -= 1;
        if (_hp == 0) {
            player.GetComponent<PlayerStat>().money += _value;
            Destroy(this.gameObject);
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Bullet"))
        {
            LoseHealth();
        }
    }
}
