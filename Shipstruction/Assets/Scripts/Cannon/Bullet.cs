using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionParticle;
    public string target;

    private float _spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        _spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _spawnTime > 3)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.StartsWith(target))
        {
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
