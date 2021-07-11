using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Cannon_Script : MonoBehaviour {

    public float fireangle = 0f;
    private bool showPopUp = false;
    public float firePower;
    public GameObject TargetPosition;
    // public bool fireReset;
    private bool fireReset;
    public ParticleSystem explosion;
    public ParticleSystem fireexplosion;
    public ParticleSystem fuseparticless;
    public GameObject fusepoint;

    public GameObject CannonBall;
    private Animator animator;
    public AudioSource LoadSound;
    public AudioSource FireSound;
    // public Transform pivotpoint;
    private Transform pivotpoint;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {

    }


    void OnGUI()
    {
        if (showPopUp)
        {
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                   , 300, 180), ShowGUI, "Cannon");

        }
    }
    void ShowGUI(int windowID)
    {

        // You may put a label to show a message to the player
        GUI.Label(new Rect(65, 40, 200, 30), "Press L to Load");
        GUI.Label(new Rect(65, 60, 200, 30), "Press E to Fire");
        GUI.Label(new Rect(65, 80, 200, 30), "Ajust Angle of fire");
        fireangle = GUI.HorizontalSlider(new Rect(65, 100, 200, 30), fireangle, 1, 35);
        GUI.Label(new Rect(65, 120, 200, 30), "Ajust fire power");
        firePower = GUI.HorizontalSlider(new Rect(65, 140, 200, 30), firePower, 1, 50);

        //Rotate cannon
        pivotpoint = transform.Find("CannonPivot");
        pivotpoint.transform.eulerAngles = new Vector3(0, -90, fireangle);

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            showPopUp = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            showPopUp = false;

        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                //animator.Play("load");
                LoadSound.Play();
                fireReset = true;
              
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (fireReset == true)
                {
                    // animator.Play("fire");
                    FireSound.Play();
                    Instantiate(fuseparticless, fusepoint.transform.position, Quaternion.identity);
                    // animator.Play("reload");
                    // LoadSound.Play();
                    ShootCannon();
                    fireReset = false;
                    
                }
            }
        }
    }
    public void ShootCannon()
    {

        GameObject thisCannonBall = Instantiate(CannonBall, TargetPosition.transform.position, TargetPosition.transform.rotation);
        thisCannonBall.GetComponent<Rigidbody>().AddRelativeForce(0, 0, firePower, ForceMode.Impulse);

        Instantiate(fireexplosion, TargetPosition.transform.position, Quaternion.identity);

        

    }
}
