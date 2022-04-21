using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{

    private float movementSpeed;
    [SerializeField] private float bound = -10f;

    void Awake() {


    }


    void Start() {

        movementSpeed = Random.Range(5, 15);

    }


    void Update() {

        Move();

    }


    void Move() {

        Vector3 temp = transform.position;
        temp.x -= movementSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.x < bound) { Destroy(gameObject); }

    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Player") {

            DestroyGameObject();

        }

    }

    void DestroyGameObject() {
        Destroy(gameObject);
    }


}
