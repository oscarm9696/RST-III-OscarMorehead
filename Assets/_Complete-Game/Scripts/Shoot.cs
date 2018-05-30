using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float fireRate;
    public float damage;
    public float fireTime;
    public float enemyHealth;

    public static int ammo = 6;
    public static int minAmmo = -1;
    private static int addAmmo = 1;

    public SpriteRenderer render;
    public Sprite alive;
    public Sprite dead;

    public GameObject impactEffect;
    public AudioSource audio;
    
    public LayerMask doHit;

    public Transform muzzle;
    public Transform bulletTrail;

	// Use this for initialization
	void Awake () {
       /* muzzle = transform.Find("Muzzle");
        if (muzzle == null)
        {
            Debug.LogError("no muzzle found");
        }*/
        if (minAmmo == -1)
            minAmmo = ammo;




    }

    // Update is called once per frame
    void Update() {
        if(ammo >= 6)
        {
            ammo = 6;
        }
        
        if (fireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time > fireTime){
                fireTime = Time.time + 1 / fireRate;
                Fire();
            }
        }
    }
    //function allows for mouse poition on screen for shooting, the fire pos of bullet, a raycast to detect a hit and also manages enemy damage and ammo count

    void Fire()
        {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePos = new Vector2(muzzle.position.x, muzzle.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePos, mousePosition - firePos, 100, doHit);
        //Effect();
        minAmmo--;
        audio.Play();
        Debug.DrawLine(firePos, mousePosition);
        if(hit.collider != null)
        {
            Debug.Log("hit" + hit.collider.name + "and did" + damage + "damage");
        }
        if(hit.collider.CompareTag("Enemy"))
        {
            enemyHealth = enemyHealth - damage;
            if(enemyHealth < 1)
            {
                hit.transform.gameObject.SetActive(false);
                enemyHealth = 25;
            }
            Debug.Log("dead");
        }
        if (hit.collider != null)
        {
           // GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
           // Destroy(impactGO, .5f);
        }
        if(minAmmo < 0)
        {
            audio.Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            minAmmo ++;

            other.gameObject.SetActive(false);
        }
    }

    void Effect()
    {
        //Instantiate(bulletTrail, muzzle.position, muzzle.rotation);
    }
	}

