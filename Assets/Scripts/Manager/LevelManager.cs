using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text levelText;
    public Text scoreText;
    public Text healthText;
    public Text weaponText;
    public Text nextLevelText;
    public Text bombPieceText;

    private int levelCompleted;


    private void Awake() {

        //DontDestroyOnLoad(bombPieceText);
        PlayerManager.OnResetBomb += OnResetBomb;
    }

    private void Update() {

        if (levelCompleted <= 0) {
            SceneManager.LoadScene("NextLevel");
        }

    }

    void Start() {

        levelCompleted = LevelConfig.LevelCompleted;
        PlayerConfig.BombPiece = InventoryConfig.BombPieceInventory;

        levelText.text = "Level  :  "   + LevelConfig.ActiveLevel;
        weaponText.text = "Weapon  :  " + PlayerConfig.WeaponCurrent;
        scoreText.text = "Score  :  "   + PlayerConfig.ScoreCurrent;
        healthText.text = "Health  :  " + PlayerConfig.HealthCurrent;
        nextLevelText.text = "Next Level  :  " + levelCompleted;
        bombPieceText.text = "Bomb Piece  :  " + InventoryConfig.BombPieceInventory;


    }
    

    public void UpdateScore(int scorePoint) {

        PlayerConfig.ScoreCurrent += scorePoint;

        scoreText.text = "Score  :  " + PlayerConfig.ScoreCurrent;

    }    

    public void UpdateWeapon(int weaponpoint) {

        PlayerConfig.WeaponCurrent += weaponpoint;

        weaponText.text = "Weapon  :  " + PlayerConfig.WeaponCurrent;

    }

    public void UpdateHealth(int healthpoint) {

        PlayerConfig.HealthCurrent += healthpoint;

        healthText.text = "Health  :  " + PlayerConfig.HealthCurrent;

    }

    public void UpdateNextLevel() {

        levelCompleted -= 1;

        nextLevelText.text = "Next Level  :  " + levelCompleted;

    }

    public void UpdateBomb() {

        if (PlayerConfig.BombPiece != 0)
            PlayerConfig.BombPiece -= 1;

        if (PlayerConfig.BombPiece == 0) {
            bombPieceText.text = "Bomb Ready";
        }
        else {
            bombPieceText.text = "Bomb Piece : " + PlayerConfig.BombPiece;
        }
        

    }

    private void OnResetBomb() {

        if (bombPieceText != null) {
            bombPieceText.text = "Bomb Piece  :  " + InventoryConfig.BombPieceInventory;
        }
        
    }





}
