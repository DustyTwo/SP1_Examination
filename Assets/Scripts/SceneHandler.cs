using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] SceneAsset assignedScene;
    
    public void GoToAssignedScene()
    {
        SceneManager.LoadSceneAsync(assignedScene.name, LoadSceneMode.Single);
    }
    
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
    
}
