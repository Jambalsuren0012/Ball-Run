using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    private float? lastMousePoint = null;
    //public float speed;
    public float speedController;
    public Coinmanager cm;
    public GameObject gameoverpanel;
    public GameObject levelcompletedpanel;






    private float lastframeposx;
    private float movefactorx;
    public float MoveFactorX => movefactorx;

    public Camera m_MainCam;

    private float speed = 3.0f;
    [SerializeField]
    GameObject character;
    [SerializeField] private float swerveSpeed = 1f;
    [SerializeField] private float maxSwerveAmount = 1.5f;

    void Start()
    {
        speedController = 0.02f;
    }


    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        Cammina();
   

       
            

        

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -4f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);






    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
        if(other.gameObject.tag == "obstacle")
        {

            gameoverpanel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (other.gameObject.tag == "Finish")
        {

            levelcompletedpanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    void Cammina()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastframeposx = Input.mousePosition.x;
            float swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            movefactorx = Input.mousePosition.x - lastframeposx;
            lastframeposx = Input.mousePosition.x;
            float swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            movefactorx = 0f;
            float swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
        }
    }





}

