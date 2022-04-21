using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{    

    void Start()
    {
        Options option = JsonRepository.LoadOptions();        
        GameConfig.SoundFLG = option.soundFlg;                
    }

    public void GotToPlay() {

        PlayerConfig.Reset();
        InventoryConfig.Reset();

        LevelConfig.ActiveLevel = 1;
        LevelConfig.SetLevel();

        SceneManager.LoadScene("Level");

    }

    public void GotToOptions() {

        SceneManager.LoadScene("Options");

    }

    public void GotToScores() {

        SceneManager.LoadScene("Scores");

    }


}
