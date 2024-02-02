using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialMenuScript : MonoBehaviour
{
    public enum MenuStates { Main, Gaming };
    public MenuStates currentstate;

    //Menu Panel Objects

    //main menu objects
    public GameObject mainMenu;
    public GameObject howToButton;
    public GameObject Box;

    bool firstMenuFrame = true;

    //when script first starts shows the Main
    private void Awake()
    {
        currentstate = MenuStates.Main;
        howToButton.SetActive(false);
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
                if (firstMenuFrame)
                {
                    Box.GetComponent<Animator>().Play("Box");
                    firstMenuFrame = false;
                }
                break;
        }


    }



    // actions on main menu --------------------------------------------------

    //when play button is pressed
    public void OnPlay()
    {
        Debug.Log("You pressed start game!");
        currentstate = MenuStates.Gaming;
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


}
