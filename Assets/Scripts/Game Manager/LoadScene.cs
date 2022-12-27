using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private float waitToLoad;
    private bool canLoad = false;
    [SerializeField] private string sceneName;
    [SerializeField] private bool startLoad = false;

    private void Update()
    {

        if (startLoad)
        {
            StartCoroutine(WaitLoadToScene(sceneName));
            if (HomeUIController.instace != null)
            {
                HomeUIController.instace.loadCD.minValue = 0f;
                HomeUIController.instace.loadCD.value += Time.deltaTime;
                HomeUIController.instace.loadCD.maxValue = 2f;
            }
            if (UIController.instance != null)
            {
                UIController.instance.loadCD.minValue = 0f;
                UIController.instance.loadCD.value += Time.deltaTime;
                UIController.instance.loadCD.maxValue = 2f;
            }
        }
    }

    public void LoadToScene(int sceneToLoad)
    {    
        if(HomeUIController.instace != null)
        {
            if (MapSelect.instance.isActiveMap[sceneToLoad])
            {
                HomeUIController.instace.loadScreen.SetActive(true);
                startLoad = true;
                MapSelect.instance.mapIndex = sceneToLoad;
            }
        }
        if(UIController.instance != null)
        {
            UIController.instance.loadScreen.SetActive(true);
            Time.timeScale = 1f;
            startLoad = true;
        }     
    }

    IEnumerator WaitLoadToScene(string sceneToLoad)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
