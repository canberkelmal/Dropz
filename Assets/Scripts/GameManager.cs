using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float camFallowSens = 1;
    public float camZ = -10f;
    public GameObject Balls, cam;
    public bool unlockPin = false;
    float tempCamZ;
    float avY=0;

    
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        Balls = GameObject.Find("Balls");
        
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
            ClickDedector();

        CamController();
        InputController();
        
    }

    private void ClickDedector()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if(hit.transform != null && hit.transform.gameObject.CompareTag("Pin"))
            hit.transform.parent.GetComponent<PinSc>().trig();

        else if(hit.transform != null)
            Debug.Log("Clicked to " + hit.transform.name);

        else
            Debug.Log("Missclick!");
        
    }

    private void CamController()
    {
        avY = 0;
        for(int i=0; i<Balls.transform.childCount;i++)
        {
            avY += Balls.transform.GetChild(i).position.y;
        }
        avY = avY/Balls.transform.childCount;

        tempCamZ = Mathf.Lerp(cam.transform.position.y, avY, camFallowSens*Time.deltaTime);
        cam.transform.position = new Vector3(0, tempCamZ, camZ);
    }

    void InputController()
    {
        //Reloads the current scene when pressed "R" on keyboard
        if(Input.GetKeyDown(KeyCode.R))
            reloadCurrentScene();    
    }

    public void reloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
