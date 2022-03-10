using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int positionZ = 14;
    private int positionX = 1;
    public GameObject[] obstacle;
    public int obstacleRange;
    void Start()
    {
        for (int i = 0; i < obstacleRange; i++)
        {
            int index = Random.Range(0, obstacle.Length);
            if (index == 0)
            {
                positionX = 0;
            }
            else
                positionX = 1;
            Vector3 position = new Vector3(positionX, 0.6f, positionZ);
            Instantiate(obstacle[index], position, obstacle[index].transform.rotation);
            positionZ += 20;
        }

    }
}
