using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance ;
    public string playerChoice;
    public List<RawImage> rawImages = new List<RawImage>();
    public List<GameObject> playerGameObject = new List<GameObject>();

    private int getCurrentScene;

    public void Update()
    {
       getCurrentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void Start()
    {
        if( Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

        StartCoroutine(LoadPlayerSelection());
    }

    IEnumerator LoadPlayerSelection()
    {
        yield return new  WaitForSeconds(0.1f);
        if(playerChoice == "normal Human")
        {
            Instantiate(playerGameObject[0]);
        }else if(playerChoice == "Child")
        {
            Instantiate(playerGameObject[1]);
        }
        else
        {
            Instantiate(playerGameObject[2]);
        }
    }

    public void SelectedNormalHuman()
    {
        playerChoice = "normal Human";
        rawImages[0].gameObject.SetActive(true);
        rawImages[1].gameObject.SetActive(false);
        rawImages[2].gameObject.SetActive(false);
    }
    public void SelectedChild()
    {
        playerChoice = "Child";
        rawImages[0].gameObject.SetActive(false);
        rawImages[1].gameObject.SetActive(true);
        rawImages[2].gameObject.SetActive(false);
    }
    public void SelectedAthelete()
    {
        playerChoice = "Athelete";
        rawImages[0].gameObject.SetActive(false);
        rawImages[1].gameObject.SetActive(false);
        rawImages[2].gameObject.SetActive(true);
    }


}
