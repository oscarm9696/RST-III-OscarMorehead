using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float shakeTime;
    public float shakeAmmount;
    public float zoomIn = 1.28f;

    public Vector2 velocity;
    public float timeX;
    public float timeY;

    public GameObject player;

	// Use this for initialization
	void Start () {
        GetComponent<Camera>().orthographicSize = zoomIn;
	}
    private void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, timeX);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, timeY);

        transform.position = new Vector3(posx,posy,transform.position.z);
    }

    // Update is called once per frame
    void Update () {
		if (shakeTime >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmmount;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
            shakeTime -= Time.deltaTime;
        }

      

       /* if (Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<Camera>().orthographicSize = zoomIn;
        }*/
    }

    public void Shake(float shakePower, float shakeDur)
    {
        shakeTime = shakeDur;
        shakeAmmount = shakePower;
    }
}
