using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Button button1, button2, button3;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    //public SceneManager sceneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button1.onClick.AddListener(() => ButtonClicked(1));
        button2.onClick.AddListener(() => ButtonClicked(2));
        button3.onClick.AddListener(() => ButtonClicked(3));

        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ButtonClicked(int buttinNum)
    {
        Debug.Log("Button Clicked" + buttinNum);
        if (buttinNum == 1)
        {
            SceneManager.LoadScene("TestingTry2", LoadSceneMode.Single);
        }
        if (buttinNum == 2)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        if (buttinNum == 3)
        {
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
    }
}
