using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{

    public Transform contentPanel;
    public Text myText;
    public Font myFont;


    void Start()
    {

        Score score = JsonRepository.LoadScore();

        if (score != null) {

            for (int i = 0; i < score.scoreList.Count; i++) {
                CreateText( i.ToString(), score.scoreList[i].scorePoint.ToString(), score.scoreList[i].level.ToString(), score.scoreList[i].scoreDate);
            }

        }
        
        
    }


    public void GoToMainMenu() {

        SceneManager.LoadScene("MainMenu");

    }
    

    public void CreateText(string name, string scorePoint, string scoreLevel, string scoreDate) {

        GameObject scoretext = new GameObject(name + "Text");
        RectTransform trans = scoretext.AddComponent<RectTransform>();
        trans.localScale = new Vector3(2f, 2f);
        Text text = scoretext.AddComponent<Text>();
        text.text = scorePoint + " -- " + scoreLevel + " -- " + scoreDate;
        text.fontSize = 40;
        text.font = myFont;
        text.color = Color.yellow;
        text.alignment = TextAnchor.MiddleCenter;
        scoretext.transform.SetParent(contentPanel);


    }




}
