using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Bounds area;
    public GameObject Enemy;
    public static float waitTime = 2f;

 

    // Start is called before the first frame update
    void Start()
    {//Keep spawning enemys
        area = transform.GetChild(1).GetComponent<Renderer>().bounds;
        StartCoroutine("EnemyAttack");
    }


    IEnumerator EnemyAttack()
    {
        while (true)
        {//Calculate 2D area from wall to randomly spawn at
            Vector3 min = area.min + (Vector3.forward * 5);
            Vector3 max = area.max + (Vector3.forward * 5);
            float x = Random.Range(min.x + 3f, max.x - 3f);
            float y = Random.Range(min.y + 0.4f, max.y - 6f);
            float z = min.z;
            Vector3 position = new Vector3(x, y, z);
            Instantiate(Enemy, position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            waitTime -= (Time.deltaTime * Time.deltaTime * 6);
        }
    }



    void Update()
    {
        if (GameManager.instance.isGameOver)
        {//Stop spawning where game over
            StopCoroutine("EnemyAttack");
        }
    }

}
