using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMode : MonoBehaviour {

    public GameObject boat;
    public GameObject boatCamera;
    public GameObject player;
    public GameObject playerStartPos;

    bool showText;
    bool isSteering = false;


    void OnTriggerStay(Collider other){
        showText = true;

        // veneeseen - 3 persoona

        if (Input.GetKeyDown(KeyCode.E)){

            boat.GetComponent<Rigidbody>().isKinematic = false;
            boat.GetComponent<vene>().enabled = true;
            boatCamera.SetActive(true);

            player.SetActive(false);

            showText = false;
            isSteering = true;

            Debug.Log("sisään");
            Debug.Log("Steering: " + isSteering);


        }

        // takaisin 1 persoona

        if (Input.GetKeyDown(KeyCode.E) && isSteering ){


            boat.GetComponent<Rigidbody>().isKinematic = true;
            boat.GetComponent<vene>().enabled = false;
            boatCamera.SetActive(false);

            player.SetActive(true);
            player.transform.position = playerStartPos.transform.position;

            Debug.Log("pois");
            Debug.Log("Steering: " + isSteering);
        }


    }



    // teksti 
    void OnGUI(){
        if (showText == true){
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            GUI.Box(new Rect(x - 10, y, 180, 22), "");
            GUI.Label(new Rect(x, y, 1000, 1000), "Paina E ajaaksesi veneellä!");
        }
    }
}
