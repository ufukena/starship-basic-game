using UnityEngine;

public class PlayerBomb : MonoBehaviour
{


    private float moveSpeed;
    [SerializeField] private float destroyTimer = 6f;
    private GameObject player;

    void Start() {

        Invoke("DestroyObject", destroyTimer);
        player = GameObject.Find("LevelManager");
        moveSpeed = 10f;
    }


    void Update() {

        Move();

    }

    void Move() {

        Vector3 temp = transform.position;
        temp.x += moveSpeed * Time.deltaTime;
        transform.position = temp;

    }

    private void DestroyObject() {

        //gameObject.SetActive(false);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Enemy") {

            player.GetComponent<LevelManager>().UpdateScore(1);
            player.GetComponent<LevelManager>().UpdateNextLevel();
            Destroy(gameObject);
        }

    }


}
