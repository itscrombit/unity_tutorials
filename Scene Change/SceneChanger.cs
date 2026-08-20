using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene changing

public class SceneChanger : MonoBehaviour
{
    // Call this method via a UI Button OnClick() event or a trigger zone
    public void GoToNextScene()
    {
        SceneManager.LoadScene("Level2"); 
    }
}
