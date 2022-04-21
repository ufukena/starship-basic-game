using SimpleInputNamespace;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    private float movementSpeed;
    private float fireSpeed;

    public float maxY = 4.5f, minY = -4.5f;
    [SerializeField] private GameObject playerLaserPrefab;
    [SerializeField] private GameObject playerBombPrefab;
    [SerializeField] private Transform weaponPosition;
    private float currentAttackTimer;
    private bool attackFlg;
    public LevelManager levelManager;
    private AudioSource[] objectAudioLibrary;
    private Animator destroyAnimator;
    float move;

    public Button fireButton;
    public Button bombButton;

    public static event Action OnResetBomb = delegate { };


    private void Awake() {

        destroyAnimator = GetComponent<Animator>();
        objectAudioLibrary = GetComponents<AudioSource>();
    }

    void Start() {

        Button firebtn = fireButton.GetComponent<Button>(); 
        firebtn.onClick.AddListener(Attack); 

        Button bombBtn = bombButton.GetComponent<Button>(); 
        bombBtn.onClick.AddListener(Bomb); 


        movementSpeed = PlayerConfig.MovementSpeed;
        fireSpeed = PlayerConfig.FireSpeed;
        currentAttackTimer = fireSpeed;
               
    } 

    
    void Update() {
        
        MovePlayer();
        // Attack();
        fireSpeed += Time.deltaTime;
    }

    void MovePlayer() {

        //move = Input.GetAxisRaw("Vertical");
        move = SimpleInput.GetAxisRaw("Vertical");




        if (move > 0) {

            Vector3 position = transform.position;
            position.y += movementSpeed * Time.deltaTime;

            if (position.y > maxY)
                position.y = maxY;

            transform.position = position;

        }
        else if (move < 0) {

            Vector3 position = transform.position;
            position.y -= movementSpeed * Time.deltaTime;

            if (position.y < minY)
                position.y = minY;

            transform.position = position;

        }

        

    }


    public void Attack() {
      
        if (fireSpeed > currentAttackTimer) { attackFlg = true; }

        //if (Input.GetKeyDown(KeyCode.Space)) {

            if (attackFlg && PlayerConfig.WeaponCurrent > 0) {

                attackFlg = false;
                fireSpeed = 0;
                Instantiate(playerLaserPrefab, weaponPosition.position, Quaternion.Euler(0,0,90));

                levelManager.UpdateWeapon(-1);

                if (GameConfig.SoundFLG)
                    objectAudioLibrary[0].Play();
                
            }           
        //}


    }

    public void Bomb() {

        if (fireSpeed > currentAttackTimer) { attackFlg = true; }
        

            if (PlayerConfig.BombPiece == 0) {

                float y = 7f;
                for (int i = 0; i < 40; i++) {

                    Instantiate(playerBombPrefab, new Vector3(-10, y), Quaternion.Euler(0, 0, 90));
                    y -= 0.6f;
                }

                PlayerConfig.BombPiece = InventoryConfig.BombPieceInventory;
                OnResetBomb();

            }
        

    }


    private void OnTriggerEnter2D(Collider2D collision) {

        

        switch (collision.tag) {

            case "Enemy":
                levelManager.UpdateHealth(-10);
                if (PlayerConfig.HealthCurrent <= 0) {

                    objectAudioLibrary[1].Play();
                    destroyAnimator.Play("Explosion");
                    Invoke("DestroyGameObject", 0.5f);
                    GotToGameOver();
                }
                break;
            case "Health":
                objectAudioLibrary[2].Play();
                levelManager.UpdateHealth(UnityEngine.Random.Range(1, 6));
                break;
            case "Score":
                objectAudioLibrary[2].Play();
                levelManager.UpdateScore(UnityEngine.Random.Range(1, 6));
                break;
            case "Weapon":
                objectAudioLibrary[2].Play();
                levelManager.UpdateWeapon(UnityEngine.Random.Range(1, 6));
                break;
            case "Bomb":
                objectAudioLibrary[2].Play();
                levelManager.UpdateBomb();
                break;
            default:
                break;
        }



    }

    void DestroyGameObject() {

        Destroy(gameObject);

    }


    public void GotToGameOver() {

        SceneManager.LoadScene("GameOver");

    }


}



