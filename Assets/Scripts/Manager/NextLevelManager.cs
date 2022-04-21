using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelManager : MonoBehaviour
{
    public Text completedText;
    

    void Start()
    {
        completedText.text = "Level " + LevelConfig.ActiveLevel.ToString() + " Completed..";
    }

   
    public void GoToInventory() {

        SceneManager.LoadScene("Inventory");

    }


    public void GoToNextLevel() {

        LevelConfig.ActiveLevel += 1;
        LevelConfig.SetLevel();

        SceneManager.LoadScene("Level");

    }


}
