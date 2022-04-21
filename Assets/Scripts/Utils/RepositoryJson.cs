using System.IO;
using System.Linq;
using UnityEngine;

public static class JsonRepository
{
    //private static string directoryName => Application.dataPath + "/Data/";
    private static string directoryName => Application.persistentDataPath + "/Data/";
    private static string optionFileName => "OptionsFile.json";
    private static string gameConfigFileName => "GameConfigFile.json";
    private static string scoreFileName => "ScoreFile.json";


    public static void SaveOptions(bool sound) {
        
        Options option = new Options { soundFlg = sound };
        
        string jsonData = JsonUtility.ToJson(option);
                   
        File.WriteAllText(directoryName + optionFileName, jsonData);
        
    }

    public static Options LoadOptions() {

        Options option = new Options();

        if (!Directory.Exists(directoryName)) {
            Directory.CreateDirectory(directoryName);
        }

        if (!File.Exists(directoryName + optionFileName)) {

            TextAsset optionJsonDataPath = Resources.Load<TextAsset>("OptionsFile");
            option = JsonUtility.FromJson<Options>(optionJsonDataPath.ToString());

        }
        else {

            string optionJsonDataPath2 = File.ReadAllText(directoryName + optionFileName);
            option = JsonUtility.FromJson<Options>(optionJsonDataPath2);

        }

        return option;

    }

    public static void SaveScore() {        

        Score score = LoadScore();

        if (score == null) {
            score = new Score();
            score.scoreList = new System.Collections.Generic.List<ScoreDetail>();
        }

        score.scoreList.Add( new ScoreDetail { scorePoint = PlayerConfig.ScoreCurrent, level = LevelConfig.ActiveLevel,  scoreDate = System.DateTime.Now.ToString("yyyy-MM-dd") } );

        score.scoreList = score.scoreList.OrderByDescending(o => o.scorePoint).Take(5).ToList();

        string jsonData = JsonUtility.ToJson(score);        

        File.WriteAllText(directoryName + scoreFileName, jsonData);        

    }

    public static Score LoadScore() {
      
            Score score = new Score();

            if (!Directory.Exists(directoryName)) {
                Directory.CreateDirectory(directoryName);
            }

            if (!File.Exists(directoryName + scoreFileName)) {                

                TextAsset scoreJsonDataPath = Resources.Load<TextAsset>("ScoreFile");
                score = JsonUtility.FromJson<Score>(scoreJsonDataPath.ToString());

            }
            else {

                string scoreJsonDataPath2 = File.ReadAllText(directoryName + scoreFileName);
                score = JsonUtility.FromJson<Score>(scoreJsonDataPath2);
                
            }

            return score;
              
    }


}
