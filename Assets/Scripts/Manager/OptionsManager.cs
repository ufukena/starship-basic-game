using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OptionsManager : MonoBehaviour
{

    public Toggle soundToggle;
    //public GameConfig_SO gameConfig;


    private void Start() {

        Options option = JsonRepository.LoadOptions();        
        soundToggle.isOn = option.soundFlg;

        //gameConfig.soundFLG = option.soundFlg;
        //soundToggle.isOn = gameConfig.soundFLG;

    }

    public void ReturnMainMenu() {

        if (soundToggle.isOn)
            //gameConfig.soundFLG = true;
            GameConfig.SoundFLG = true;
        else
            //gameConfig.soundFLG = false;
            GameConfig.SoundFLG = false;

        //JsonRepository.SaveOptions(gameConfig.soundFLG);
        JsonRepository.SaveOptions(GameConfig.SoundFLG);

        SceneManager.LoadScene("MainMenu");

        

    }


}


