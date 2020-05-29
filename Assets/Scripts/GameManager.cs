using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int EnemiesAlive = 0;

    public void IncreaseEnemyCount()
    {
        EnemiesAlive++;
    }

    public void DecreaseEnemyCount()
    {
        EnemiesAlive--;

        // If there is no more enemies, load the next level
        if(EnemiesAlive <= 0)
        {
            // Load the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
