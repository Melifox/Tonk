using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    
    public string levelToLoad;
    public string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene()
    {
        currentLevel = levelToLoad;
        SceneManager.LoadScene(levelToLoad);
    }
}
