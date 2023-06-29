using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coincollection : MonoBehaviour

{
    // Start is called before the first frame update
    private int Coin = 0;



    public TextMeshProUGUI coinText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            Coin++;
            coinText.text = "Coin: " + Coin.ToString();
            //Debug.Log(Coin);

            // Here you can do all sorts of cool stuff with the collected coin.
            // Like rotate it, activate particles, play audio, or just destroy it.

            // Destroys collected coin.
            Destroy(other.gameObject);
        }
    }





}
