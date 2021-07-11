using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject boatPrefab;

    private List<GameObject> _boats;
    private List<GameObject> _islands;
    private List<GameObject> _trade;

    private float _boatSpawnTime = 5;
    private float _lastBoatSpawn = 5;

    private Vector3 _spawnPoint;

    private GameObject _newBoat;
    // Start is called before the first frame update
    void Start()
    {
        _boats = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBoat();
    }

    private void CheckBoat()
    {
        foreach (GameObject boat in _boats)
        {
            if (Vector3.Distance(boat.transform.position, player.transform.position) > 110)
            {
                _boats.Remove(boat);
                Destroy(boat);
            }
        }

        if (_boats.Count < 10 && Time.time > _lastBoatSpawn + _boatSpawnTime)
        {
            _spawnPoint = Random.insideUnitCircle.normalized * Random.Range(50, 100);
            _newBoat = Instantiate(boatPrefab, new Vector3(player.transform.position.x + _spawnPoint.x, 0, player.transform.position.z + _spawnPoint.y), Quaternion.identity);
            _newBoat.GetComponent<EnemyBoat>().player = player;
            _boats.Add(_newBoat);
            _lastBoatSpawn = Time.time;
        }
    }
}
