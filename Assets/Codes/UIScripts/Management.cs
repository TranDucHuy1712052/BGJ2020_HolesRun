using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public GameObject GameplayScene, InstructionsScene, EndgameScene, MenuScene;


    //MenuScene
    public void ClickOnPlay()
    {
        MenuScene.SetActive(false);
        GameplayScene.SetActive(true);
    }

    public void ClickOnInstructions()
    {
        MenuScene.SetActive(false);
        InstructionsScene.SetActive(true);
    }

    //InstructionsScene

    public void ClickOnDone()
    {
        InstructionsScene.SetActive(false);
        MenuScene.SetActive(true);
    }

    //EndgameScene

    public void TryAgain()
    {
        EndgameScene.SetActive(false);
        GameplayScene.SetActive(true);
    }

    public void Exit()
    {
        EndgameScene.SetActive(false);
        MenuScene.SetActive(true);
    }
}
