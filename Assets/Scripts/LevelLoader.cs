using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update

    public void ChangeScene(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    public void BackToMain()
    {
        //Destroy(GameObject.Find("AR"));
        StartCoroutine(LoadLevel(1));
        
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(1);
    }

    public void RandomScene()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex;
        while(nextLevel == SceneManager.GetActiveScene().buildIndex)
        {
            nextLevel = Random.Range(2, SceneManager.sceneCountInBuildSettings);
        }
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

}
