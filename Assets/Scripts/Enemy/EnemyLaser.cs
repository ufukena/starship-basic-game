using UnityEngine;

public class EnemyLaser : MonoBehaviour
{

    private float moveSpeed ;
    private float destroyTimer = 4f;
    

    void Start() {


        moveSpeed = Random.Range(LevelConfig.MinEnemyLaserMoveSpeed, LevelConfig.MaxEnemyLaserMoveSpeed);

        //çünkü sağdan sola gidiyor
        moveSpeed *= -1f;

        Invoke("DestroyObject", destroyTimer);

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

        if (collision.tag == "Player") {                       
             Destroy(gameObject);                                   
        }

    }

}
