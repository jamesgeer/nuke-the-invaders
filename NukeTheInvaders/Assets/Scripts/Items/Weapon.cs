using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public GameObject rocketObj; //link to the rocket prefab
    public TextMeshProUGUI currentAmmoText; //link to the rocket prefab
    public TextMeshProUGUI maxAmmoText; //link to the rocket prefab
    public int noRocket = 10; //number of rockets possessed
    public int maxAmmo = 24;
    public AudioClip shootSound; //rocket launch sound
    public float maxSpeed= 60;//max rocket speed
    public float rocketAcceleration = 1;

    private void Start()
    {
        // currentAmmoText.text = noRocket.ToString();
        // maxAmmoText.text = "/ " + maxAmmo.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        //if left control (fire1) pressed, and we still have at least 1 cell
        if (Input.GetButtonDown("Fire1") && noRocket > 0)
        {
            noRocket--; //reduce the number of rockets
            currentAmmoText.text = noRocket.ToString();
            //play shooting sound
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            
            //instantiate the rocket as game object (also make it point forward)
            GameObject rocket = Instantiate(rocketObj, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f)) as GameObject;
            //ask physics engine to ignore collison between power cell and our FPSController
            
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), rocket.GetComponent<Collider>(), true);
        }
    }
}
