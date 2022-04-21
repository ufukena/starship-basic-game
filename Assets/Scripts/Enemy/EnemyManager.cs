using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    //private bool moveable = true;  
    //public bool shootable = true;

    private float minEnemyMovementSpeed;
    private float maxEnemyMovementSpeed;
    private float minEnemyFireSpeed;
    private float maxEnemyFireSpeed;


    private float enemyMovementSpeed;

    public GameObject enemyLaserPrefab;
    [SerializeField] private float bound = -10f;          
    public Transform attackPoint;    
    private AudioSource destroySound;
    private Animator destroyAnimator;    
    

    void Awake() {

        destroyAnimator = GetComponent<Animator>();
        destroySound = GetComponent<AudioSource>();
    }


    void Start() {

        minEnemyMovementSpeed = LevelConfig.MinEnemyMovementSpeed;
        maxEnemyMovementSpeed = LevelConfig.MinEnemyMovementSpeed;
        minEnemyFireSpeed = LevelConfig.MinEnemyFireSpeed;
        maxEnemyFireSpeed = LevelConfig.MaxEnemyFireSpeed;

        enemyMovementSpeed = Random.Range(minEnemyMovementSpeed, maxEnemyMovementSpeed);

        Invoke("StartShooting", Random.Range(1, 3)); 

        

    }


    void Update() {

        Move();

    }


    void Move() {


            Vector3 temp = transform.position;
            temp.x -= enemyMovementSpeed * Time.deltaTime;
            transform.position = temp;
            if (temp.x < bound) { Destroy(gameObject); }

        
        

    }

    void StartShooting() {

        GameObject laser = Instantiate(enemyLaserPrefab, attackPoint.position, Quaternion.Euler(0, 0, 90));
        Invoke("StartShooting", Random.Range(1,3));         

    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Player") {

            if(GameConfig.SoundFLG)
                destroySound.Play();

            destroyAnimator.Play("Explosion");

            Invoke("DestroyGameObject", 0.5f);
                                


        }

    }

    void DestroyGameObject() {

        Destroy(gameObject);

    }


}
