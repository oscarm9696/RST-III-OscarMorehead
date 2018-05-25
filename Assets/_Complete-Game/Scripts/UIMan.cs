using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : MonoBehaviour {

    public Transform gun;

    public Transform bullet1;
    public Transform bullet2;
    public Transform bullet3;
    public Transform bullet4;
    public Transform bullet5;
    public Transform bullet6;
   

    public static int currentAmmo;


    // Use this for initialization
    void Start () {
		//Shoot.ammo
	}
	
	// Update is called once per frame
	void Update () {
        currentAmmo = Shoot.minAmmo;

        if (currentAmmo > 0)
        {
            bullet1.GetComponent<Image>().enabled = true;
        }
        else
        {
            bullet1.GetComponent<Image>().enabled = false;
        }
        if(currentAmmo > 1)
        {
            bullet2.GetComponent<Image>().enabled = true;
        }
        else
        {
            bullet2.GetComponent<Image>().enabled = false;
        }
        if(currentAmmo > 2)
        {
            bullet3.GetComponent<Image>().enabled = true;
        }
        else
        {
            bullet3.GetComponent<Image>().enabled = false;
        }
        if(currentAmmo > 3)
        {
            bullet4.GetComponent<Image>().enabled = true;
        }
        else
        {
            bullet4.GetComponent<Image>().enabled = false;
        }
        if(currentAmmo > 4)
        {
            bullet5.GetComponent<Image>().enabled = true;
        }
        else
        {
            bullet5.GetComponent<Image>().enabled = false;
        }
        if(currentAmmo > 5)
        {
            bullet6.GetComponent<Image>().enabled = true;
        }
        else
        {
            bullet6.GetComponent<Image>().enabled = false;
        }
     
    }
}
