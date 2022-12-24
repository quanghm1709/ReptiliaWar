using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private float waitToLoad;
    private bool canLoad = false;
    private string sceneName;
    private bool startLoad = false;

    private void Update()
    {

        if (startLoad)
        {
            StartCoroutine(WaitLoadToScene(sceneName));
            HomeUIController.instace.loadCD.minValue = 0f;
            HomeUIController.instace.loadCD.value += Time.deltaTime;
            HomeUIController.instace.loadCD.maxValue = 2f;
        }
    }

    public void LoadToScene(int sceneToLoad)
    {      
        if (HomeUIController.instace.isActiveMap[sceneToLoad])
        {
            sceneName = "SampleScene";
            HomeUIController.instace.loadScreen.SetActive(true);
            startLoad = true;
        }       
    }

    IEnumerator WaitLoadToScene(string sceneToLoad)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
