using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    public List<GameObject> objects;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manageTimer();
    }

    void manageTimer()
    {
        GameObject obstacle = objects[Random.Range(0, objects.Count)];
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            addObstacle(obstacle);
            timer = 0;
        }
    }

    void addObstacle(GameObject obstacle)
    {
        Vector3 positionOfPlayer = GameObject.Find("player").GetComponent<ControlPlayer>().initialPosition;
        GameObject t1;
        t1 = (GameObject)(GameObject.Instantiate(obstacle, positionOfPlayer + Vector3.right * 20, Quaternion.identity));
        SpawnRandom(obstacle);
    }

    void SpawnRandom(GameObject obstacle)
    {
        Vector3 position = new Vector3(Random.Range(4.0F, 4.0F), 1, Random.Range(5.0F, 5.0F));
        Instantiate(obstacle, position, Quaternion.identity);
    }
}
