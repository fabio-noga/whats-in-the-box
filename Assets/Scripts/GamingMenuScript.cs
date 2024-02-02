using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GamingMenuScript : MonoBehaviour
{


    //Menu Panel Objects

    //gaming menu objects
    public GameObject gamingMenu;
    public GameObject questionMarkButton;
    public GameObject umbrellaButton;
    public GameObject listButton;
    public GameObject HomeButton;
    public GameObject Cube;

    private GameObject placesArray;

    bool list;
    public Image blackBackground;

    //when script first starts shows the Main

    private void Start()
    {
        placesArray = GameObject.Find("placesArray");

        int level = SceneManager.GetActiveScene().buildIndex;


        switch (level)
        {
            case 1:
                Cube.transform.GetChild(1).GetComponent<Text>().text = "Overworld";
                break;
            case 2:
                Cube.transform.GetChild(1).GetComponent<Text>().text = "The West";
                placesArray.GetComponent<UICounter>().placesArray[1] = true;
                break;
            case 3:
                Cube.transform.GetChild(1).GetComponent<Text>().text = "Training Camp";
                placesArray.GetComponent<UICounter>().placesArray[3] = true;
                break;
            case 4:
                Cube.transform.GetChild(1).GetComponent<Text>().text = "Temple";
                placesArray.GetComponent<UICounter>().placesArray[2] = true;
                break;
            case 5:
                Cube.transform.GetChild(1).GetComponent<Text>().text = "City";
                placesArray.GetComponent<UICounter>().placesArray[4] = true;
                break;
            case 6:
                Cube.transform.GetChild(1).GetComponent<Text>().text = "Stadium";
                placesArray.GetComponent<UICounter>().placesArray[5] = true;
                break;
            case 7:
                Cube.transform.GetChild(1).GetComponent<Text>().text = "Beach";
                placesArray.GetComponent<UICounter>().placesArray[0] = true;
                break;
        }
    }

    private void Awake()
    {
        list = false;
        gamingMenu.SetActive(true);
        questionMarkButton.SetActive(false);
        listButton.SetActive(false);

    }


    // actions on gaming menu --------------------------------------------------

    public void OnQuestionMark()
    {
        Debug.Log("You pressed ? !");

        //turn off all other buttons
        questionMarkButton.SetActive(false);
        questionMarkButton.SetActive(false);
        umbrellaButton.SetActive(false);
        HomeButton.SetActive(false);
        Cube.SetActive(false);
        questionMarkButton.SetActive(true);

        if (list)
        {
            listButton.SetActive(false);
        }

        Debug.Log("fading!");
        //fadeIn(blackBackground);


    }
    public void OnQuestionMarkMenu()
    {
        Debug.Log("You pressed ? !");

        //turn off all other buttons
        questionMarkButton.SetActive(true);
        questionMarkButton.SetActive(true);
        umbrellaButton.SetActive(true);
        HomeButton.SetActive(true);
        Cube.SetActive(true);
        questionMarkButton.SetActive(false);

        if (list)
        {
            listButton.SetActive(true);
        }

        //fadeOut(blackBackground);

    }

    public void OnUmbrellatButton()
    {

        float x = umbrellaButton.transform.localPosition.x;
        float z = umbrellaButton.transform.localPosition.z;
        if (!list)
        {
            Debug.Log("You pressed the umbrella button");
            listButton.SetActive(true);

            var placesArrayArray = placesArray.GetComponent<UICounter>().placesArray;
            if (placesArrayArray[0])
            {
                GameObject.Find("WorldsButton (1)").transform.Find("Text").GetComponent<Text>().text = "Beach";
                GameObject.Find("WorldsButton (1)").GetComponent<Button>().interactable = true;
            }
            if (placesArrayArray[1])
            {
                GameObject.Find("WorldsButton (2)").transform.Find("Text").GetComponent<Text>().text = "The West";
                GameObject.Find("WorldsButton (2)").GetComponent<Button>().interactable = true;
            }
            if (placesArrayArray[2])
            {
                GameObject.Find("WorldsButton (3)").transform.Find("Text").GetComponent<Text>().text = "Temple";
                GameObject.Find("WorldsButton (3)").GetComponent<Button>().interactable = true;
            }
            if (placesArrayArray[3])
            {
                GameObject.Find("WorldsButton (4)").transform.Find("Text").GetComponent<Text>().text = "Training Camp";
                GameObject.Find("WorldsButton (4)").GetComponent<Button>().interactable = true;
            }
            if (placesArrayArray[4])
            {
                GameObject.Find("WorldsButton (5)").transform.Find("Text").GetComponent<Text>().text = "City";
                GameObject.Find("WorldsButton (5)").GetComponent<Button>().interactable = true;
            }
            if (placesArrayArray[5])
            {
                GameObject.Find("WorldsButton (6)").transform.Find("Text").GetComponent<Text>().text = "Stadium";
                GameObject.Find("WorldsButton (6)").GetComponent<Button>().interactable = true;
            }

            //umbrellaButton.transform.localPosition = new Vector3(x, -260, z);
            listButton.GetComponent<Animator>().Play("ListUp");
            umbrellaButton.GetComponent<Animator>().Play("UmbrellaUp");
            Debug.Log("listup command");
            list = true;
        }

        else
        {
            Debug.Log("You pressed the umbrella button");
            //umbrellaButton.transform.localPosition = new Vector3(x, -600, z);
            listButton.GetComponent<Animator>().Play("ListDown");
            umbrellaButton.GetComponent<Animator>().Play("UmbrellaDown");
            Debug.Log("listdown command");
            //listButton.SetActive(false);
            list = false;

        }

    }

    void fadeIn(Image image)
    {
        image.CrossFadeAlpha(0.8f, 2, true);
        StartCoroutine(Waiter(image, 0.8f));

    }

    IEnumerator Waiter(Image image, float x)
    {
        yield return new WaitForSeconds(2);
        Debug.Log("2 seg dps");
        blackBackground.canvasRenderer.SetAlpha(x);
        Debug.Log("faded");
    }

    void fadeOut(Image image)
    {
        image.CrossFadeAlpha(0.0f, 2, true);
        StartCoroutine(Waiter(image, 0.0f));

    }



}
