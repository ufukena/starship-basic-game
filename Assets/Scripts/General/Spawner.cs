using UnityEngine;


public class Spawner : MonoBehaviour
{
    public float minY = 4.5f, maxY = -4.5f;
    public GameObject[] enemyPrefab;
    
    private float enemytimerrandom = 1f;
    

    void Start() {

        Invoke("SpawnEnemies", enemytimerrandom);

    }

    
    void SpawnEnemies() {

        float posY = Random.Range(minY,maxY);
        Vector3 temp = transform.position;
        temp.y = posY;

        int enemyrandom = Random.Range(0,9);
        enemytimerrandom = Random.Range(0, 3);

        Instantiate(enemyPrefab[enemyrandom], temp, Quaternion.Euler(0, 0, 90));
    

        Invoke("SpawnEnemies", enemytimerrandom);

    }


}
