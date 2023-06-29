using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    Touch touch;
    private float? lastMousePoint = null;
    public float speed;
    public float speedController;
    public Coinmanager cm;
    private CharacterController controller;
    public GameObject gameoverpanel;

    void Start()
    {
        speedController = 0.01f;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePoint = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastMousePoint = null;
        }
        if (lastMousePoint != null)
        {
            float difference = Input.mousePosition.x - lastMousePoint.Value;
            transform.position = new Vector3(transform.position.x + (difference / 188) * Time.deltaTime, transform.position.y, transform.position.z);
            lastMousePoint = Input.mousePosition.x;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -4f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        controller.center = controller.center;
        if (Input.GetAxis("Mouse X") < 0)
        {
            //Code for action on mouse moving left
            print("Mouse moved left");
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            //Code for action on mouse moving right
            print("Mouse moved right");
        }




    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            // Here you can do all sorts of cool stuff with the collected coin.
            // Like rotate it, activate particles, play audio, or just destroy it.

            // Destroys collected coin.
            Destroy(other.gameObject);
            cm.coinCount++;
        }
        if(other.gameObject.tag == "obstacle")
        {
            gameoverpanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    //
 



}

