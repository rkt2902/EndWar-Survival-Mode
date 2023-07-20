using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour
{
    public GameManager gameManager;

    public int index;

    public GameObject aliceBackgroundImage;
    public GameObject ahzBackgroundImage;
    public GameObject geroBackgroundImage;
    public GameObject mystBackgroundImage;
    public GameObject dodgerBackgroundImage;
    public GameObject tortugaBackgroundImage;


    //BACKGROUND CHANGER
    public void BackgroundManager()
    {
        if (index == 0 && aliceBackgroundImage != null) //ALICE BACKGROUND
        {
            aliceBackgroundImage.SetActive(true);

            ahzBackgroundImage.SetActive(false);
            geroBackgroundImage.SetActive(false);
            mystBackgroundImage.SetActive(false);  
            dodgerBackgroundImage.SetActive(false);
            tortugaBackgroundImage.SetActive(false);
        }

        if (index == 1 && ahzBackgroundImage != null) //AHZ BACKGROUND
        {
            ahzBackgroundImage.SetActive(true);

            aliceBackgroundImage.SetActive(false);
            geroBackgroundImage.SetActive(false);
            mystBackgroundImage.SetActive(false); 
            dodgerBackgroundImage.SetActive(false); 
            tortugaBackgroundImage.SetActive(false);
        }

        if (index == 2 && geroBackgroundImage != null) //GERO BACKGROUND
        {
            geroBackgroundImage.SetActive(true);

            aliceBackgroundImage.SetActive(false);
            ahzBackgroundImage.SetActive(false);
            mystBackgroundImage.SetActive(false);
            dodgerBackgroundImage.SetActive(false);
            tortugaBackgroundImage.SetActive(false);
        }

        if (index == 3 && mystBackgroundImage != null) //MYST BACKGROUND
        {
            mystBackgroundImage.SetActive(true);

            aliceBackgroundImage.SetActive(false);
            ahzBackgroundImage.SetActive(false);
            dodgerBackgroundImage.SetActive(false);
            geroBackgroundImage.SetActive(false);
            tortugaBackgroundImage.SetActive(false);
        }

        if (index == 4 && dodgerBackgroundImage != null) //DODGER BACKGROUND
        {
            dodgerBackgroundImage.SetActive(true);

            aliceBackgroundImage.SetActive(false);
            ahzBackgroundImage.SetActive(false);
            geroBackgroundImage.SetActive(false);
            mystBackgroundImage.SetActive(false);
            tortugaBackgroundImage.SetActive(false);
        }

        if (index == 5 && tortugaBackgroundImage != null) //TORTUGA BACKGROUND
        {
            tortugaBackgroundImage.SetActive(true);

            aliceBackgroundImage.SetActive(false);
            ahzBackgroundImage.SetActive(false);
            geroBackgroundImage.SetActive(false);
            mystBackgroundImage.SetActive(false);
            dodgerBackgroundImage.SetActive(false);
        }
    }

    //NEXT AND PREVIOUS BUTTONS
    public void Nextbtn()
    {
        if (index < 5)
        {
            index++;
        }

        BackgroundManager();
    }

    public void Previousbtn()
    {
        if (index > 0)
        {
            index--;
        }

        BackgroundManager();
    }

    //MAP BUTTONS
    public void Alicebtn()
    {
        index = 0;
        BackgroundManager();
    }

    public void AHZbtn()
    {
        index = 1;
        BackgroundManager();
    }

    public void Gerobtn()
    {
        index = 2;
        BackgroundManager();
    }

    public void Mystbtn()
    {
        index = 3;
        BackgroundManager();
    }

    public void Dodgerbtn()
    {
        index = 4;
        BackgroundManager();
    }

    public void Tortugabtn()
    {
        index = 5;
        BackgroundManager();
    }

    //CONFIRM CHARACTER BUTTON
    public void Confirmbtn()
    {
        gameManager.currentCharacterIndex = index;
        gameManager.GoMarket();
    }
}
