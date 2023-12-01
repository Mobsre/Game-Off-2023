using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    bool gameHasEnded = false;
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            Debug.Log("Game Over");
            gameHasEnded = true;
            Restart();
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.None;
    }
}