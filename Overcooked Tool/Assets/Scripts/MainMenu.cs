using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Transform cam;

    public Canvas OrderWindow;
    public Canvas Stations;
    Canvas menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<Canvas>();
        cam.position = new Vector3(0, 0, cam.position.z);
        OrderWindow.enabled = false;
        Stations.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GoToStations()
    {
        cam.position = new Vector3(25, 0, cam.position.z);
        Stations.enabled = true;
        menu.enabled = false;
    }

    public void GoToOrderWindows()
    {
        cam.position = new Vector3(0, 0, cam.position.z);
        OrderWindow.enabled = true;
        menu.enabled = false;
    }

    public void MainMenuButton()
    {
        cam.position = new Vector3(0, 0, cam.position.z);
        menu.enabled = true;
        OrderWindow.enabled = false;
        Stations.enabled = false;
    }
}
