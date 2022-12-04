using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    //public GameObject rocketObj; //link to the rocket prefab
    // public TextMeshProUGUI currentAmmoText; //link to the rocket prefab
    // public TextMeshProUGUI maxAmmoText; //link to the rocket prefab
    // public int noRocket = 10; //number of rockets possessed
    // public AudioClip shootSound; 

    private Ammo _ammo;
    
    // amount of ammo
    [SerializeField] private int ammoQuantity = 0;
    
    // rocket launch sound
    [SerializeField] public AudioClip shootSound;

    private void Start()
    {
        _ammo = GetComponent<Ammo>();
        // currentAmmoText.text = noRocket.ToString();
        // maxAmmoText.text = "/ " + maxAmmo.ToString();
    }

    public void LoadAmmo(int amount)
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("BANG");
        }
        // //if left control (fire1) pressed, and we still have at least 1 cell
        // if (Input.GetButtonDown("Fire1") && ammoQuantity > 0)
        // {
        //     // decrement ammo count
        //     ammoQuantity--; 
        //
        //     // play shooting sound
        //     AudioSource.PlayClipAtPoint(shootSound, transform.position);
        //     
        //     // instantiate the rocket as game object (also make it point forward)
        //     GameObject rocket = Instantiate(rocketObj, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        //     
        //     // ask physics engine to ignore collison between power cell and our FPSController
        //     Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), rocket.GetComponent<Collider>(), true);
        // }
    }
}
