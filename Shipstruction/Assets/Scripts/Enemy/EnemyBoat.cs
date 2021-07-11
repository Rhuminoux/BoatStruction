using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : Enemy
{
    public GameObject shootingPoint;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 12;
        _value = 10;
        _hp = 2;
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 20)
        {
            Fire();
        }
    }

    protected void Fire()
    {
        if (Time.time > _lastShoot + fireSpeed)
        {
            _newBullet = GameObject.Instantiate(bulletPrefab, shootingPoint.transform.position, Quaternion.identity);
            GameObject.Instantiate(smokePrefab, shootingPoint.transform.position, Quaternion.identity);
            _newBullet.GetComponent<Rigidbody>().AddForce((shootingPoint.transform.rotation * Vector3.forward) * 20, ForceMode.Impulse);
            _lastShoot = Time.time;
        }
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        if (Vector3.Distance(this.transform.position, player.transform.position) > 10)
        {
            _rb.MovePosition(_rb.position + (transform.rotation * Vector3.forward) * _speed * Time.fixedDeltaTime);
        }
    }
}
