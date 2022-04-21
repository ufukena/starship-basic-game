using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{

    public Text scorePointText;
    


    void Start()
    {
         JsonRepository.SaveScore();

         scorePointText.text = PlayerConfig.ScoreCurrent.ToString();
        
    }

    public void GotToMainMenu() {

        SceneManager.LoadScene("MainMenu");

    }


}
