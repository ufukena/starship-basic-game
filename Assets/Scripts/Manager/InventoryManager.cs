using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{

    public Text scoreText;
    public Text moveSpeedText;
    public Text fireSpeedText;
    public Text laserSpeedText;
    public Text weaponText;
    public Text bombPieceText;

    void Start() {
        


    }

    
    void Update() {

        scoreText.text = "Your Scores : " + PlayerConfig.ScoreCurrent.ToString();
        moveSpeedText.text = "Mov.Speed -> " + InventoryConfig.MovementInventory;
        fireSpeedText.text = "Fire Speed -> " + InventoryConfig.FireSpeedInventory;
        laserSpeedText.text = "Laser Speed -> " + InventoryConfig.LaserSpeedInventory;
        bombPieceText.text = "Bomb Piece -> " + InventoryConfig.BombPieceInventory;
        weaponText.text = "Weapon -> " + PlayerConfig.WeaponCurrent;

    }



    public void GoToReturnBack() {

        SceneManager.LoadScene("NextLevel");

    }

    public void SetMoveSpeed() {

        InventoryConfig.SetMovementSpeed();

    }

    public void SetFireSpeed() {

        InventoryConfig.SetFireSpeed();

    }

    public void SetLaserSpeed() {

        InventoryConfig.SetLaserSpeed();

    }

    public void SetBombPiece() {

        InventoryConfig.SetBombPiece();

    }

    public void SetWeapon() {

        InventoryConfig.SetWeapon();

    }



}
