
using UnityEngine;



public class TargetScpt : MonoBehaviour {
    public GameObject explosionPrefab;
    public AudioSource exsound;

    void OnCollisionEnter(Collision c)
    {
        // show an explosion
       
        Instantiate(explosionPrefab,
                    transform.position,
                    Quaternion.identity);
       
          
        if (c.gameObject.tag == "cannonball")
        {
            exsound.Play();
            Destroy(gameObject);

        }

    }
    
}
