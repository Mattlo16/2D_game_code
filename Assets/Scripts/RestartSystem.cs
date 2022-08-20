using System.Collections;
using System.Collections.Generic;
using UnityEngine; // C# works with Unity.
using UnityEngine.SceneManagement; // Needed to restart the scene.

public class RestartSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){ //When I press "r" the game restarts.
            SceneRestart();
        }
    } 

    public void SceneRestart() //The function I call to restart the scene.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //This reloads the current scene that the game is on.
    }
}
