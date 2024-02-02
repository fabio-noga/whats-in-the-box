using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public enum MenuStates { Main, Gaming};
    public MenuStates currentstate;

    //Menu Panel Objects

    //main menu objects
    public GameObject mainMenu;
    public GameObject howToButton;

    //gaming menu objects
    public GameObject gamingMenu;
    public GameObject questionMarkButton;
    public GameObject umbrellaButton;
    public GameObject listButton;
    public GameObject HomeButton;
    public GameObject Cube;
    public GameObject Box;
    bool list;
    public Image blackBackground;
    bool firstMenuFrame = true;

    //when script first starts shows the Main
    private void Awake()
    {
        currentstate = MenuStates.Main;
        howToButton.SetActive(false);
        list = false;
        listButton.SetActive(false);
        Box.GetComponent<Animator>().Play("Box");
        firstMenuFrame = false;

    }

    private void Update()
    {
        //checks current menu state
        switch (currentstate)
        {
            case MenuStates.Main:
                //sett actives for main menu

                mainMenu.SetActive(true);
                gamingMenu.SetActive(false);
                if (firstMenuFrame)
                {
                    Box.GetComponent<Animator>().Play("Box");
                    firstMenuFrame = false;
                }
                break;

            case MenuStates.Gaming:

                mainMenu.SetActive(false);
                gamingMenu.SetActive(true);
                //use this the other times
                /*
                Color c = blackBackground.color;
                c.a = 0.0f;
                blackBackground.color = c;
                */
                break;
        }


    }



    // actions on main menu --------------------------------------------------

    //when play button is pressed
    public void OnPlay()
    {
        Debug.Log("You pressed start game!");
        currentstate = MenuStates.Gaming;
        questionMarkButton.SetActive(false);
        howToButton.SetActive(false);
        //blackBackground.canvasRenderer.SetAlpha(0.0f);
    }

    // when how to play button is pressed
    public void OnHowToPlay()
    {
        Debug.Log("You pressed how to play!");

        //change menu states
        howToButton.SetActive(true);
    }

    public void OnHowToPlayButton()
    {

        //turn off button
        howToButton.SetActive(false);
    }


    // actions on gaming menu --------------------------------------------------
    public void OnBackToMenu()
    {
        Debug.Log("You pressed back to menu!");

        //change menu state
        currentstate = MenuStates.Main;
        firstMenuFrame = true;

    }
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
