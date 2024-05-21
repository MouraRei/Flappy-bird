using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float coolDown = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance; 

        if(gameManager.IsGamerOver()){
            return;
        }

        coolDown -= Time.deltaTime;
        if(coolDown <= 0f){
            coolDown = GameManager.Instance.obstacleInterval;

            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];

            float x = gameManager.obstacleOffsetX;
            //posição do x
            float y = Random.Range(gameManager.obstaccleOffsetY.x, gameManager.obstaccleOffsetY.y);
            //posição do y
            float z = -5.43f;
            //posição do z, fixa 
            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
}
