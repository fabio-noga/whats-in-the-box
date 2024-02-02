using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class boxScript : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject objectToReplace;
    public GameObject objectToDelete;
    public Animator transition;

    private Text debugger;
    private bool flag = true;

    void Start()
    {
        placementIndicator = GameObject.Find("AR/PlacementIndicator");
        debugger = GameObject.Find("Debugger").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (debugger) debugger.text = "Touch found";
            if (Physics.Raycast(ray,out hit) && flag && hit.collider.gameObject.name=="Base")
            {
                flag = false;
                if (debugger) debugger.text = hit.collider.gameObject.name + " Hit "+ name;
                transition = GameObject.Find("LoadScene").transform.GetChild(0).GetComponent<Animator>();
                ChangeScene();
                //Destroy(transform);
            }
        }
    }

    public void ChangeScene()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex;
        while (nextLevel == SceneManager.GetActiveScene().buildIndex)
        {
            nextLevel = Random.Range(2, SceneManager.sceneCountInBuildSettings);
        }
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Destroy(objectToDelete);
        Instantiate(objectToReplace, transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
