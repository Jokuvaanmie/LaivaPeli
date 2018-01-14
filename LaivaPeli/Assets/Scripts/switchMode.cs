using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMode : MonoBehaviour {


    public GameObject boat;
    public GameObject boatCamera;
    public GameObject player;
    public GameObject playerStartPos;
    public float varmistusAika;
    public KeyCode enterKey;


    private bool showText;
    private bool isSteering;
    private bool isNearHelm;

    void Start(){
        showText = false;
        isSteering = false;
        isNearHelm = false;
    }


    // ______________ Ruorin lähellä ______________\\
    void OnTriggerEnter(Collider other){
        showText = true;
        isNearHelm = true;
        Debug.Log("TriggerEnter_data:     showtext: " + showText + ", isNearHelm: " + isNearHelm + ", isSteering: " + isSteering);
    }

    // ______________ Poistuu ruorin läheltä ______________\\
    void OnTriggerExit(Collider other){
        showText = false;
        isNearHelm = false;
        Debug.Log("TriggerExit_data:     showtext: " + showText + ", isNearHelm: " + isNearHelm + ", isSteering: " + isSteering);
    }




    // _________________________________ Suoritetaan joka frame ________________________________________\\


    void Update()
    {
        startSteering();
        endSteering();
    }

    // _________________________________ siirrytään kolmanteen persoonaan ________________________________________\\
    void startSteering()
    {
        if (isNearHelm == true){
            if (Input.GetKeyDown(enterKey)){
                showText = false;

                StartCoroutine(Waiting()); // varmistus

                boat.GetComponent<Rigidbody>().isKinematic = false;
                boat.GetComponent<vene>().enabled = true;
                boatCamera.SetActive(true);
                player.SetActive(false);

                Debug.Log("startSteering_data:     showtext: " + showText + ", isNearHelm: " + isNearHelm + ", isSteering: " + isSteering);
            }
        }
    }


    // _________________________________ takaisin ensimmäiseen persoonaan ________________________________________\\ 
    void endSteering(){
        if(isSteering == true){
            if (Input.GetKeyDown(enterKey))
            {

             //   boat.GetComponent<Rigidbody>().isKinematic = true;
                boat.GetComponent<vene>().enabled = false;
                boatCamera.SetActive(false);

                player.SetActive(true);
                player.transform.position = playerStartPos.transform.position;

                Debug.Log("endSteering_data:     showtext: " + showText + ", isNearHelm: " + isNearHelm + ", isSteering: " + isSteering);

                isSteering = false;
            }
        }
    }




    // _______________________ varmistetaan että ei päädytä samantien ulos ________________________________________\\ 

        IEnumerator Waiting(){
            yield return new WaitForSeconds(varmistusAika);
            isSteering = true;
    }




    // _________________________________ Tekstin piirto ________________________________________\\ 
    void OnGUI(){
        if (showText == true){
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            GUI.Box(new Rect(x - 10, y, 180, 22), "");
            GUI.Label(new Rect(x, y, 1000, 1000), "Paina E ajaaksesi veneellä!");
        }
    }
}
