using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public float obstacleSpeed = 10;
    public float obstacleOffsetX = 0;
    public Vector2 obstaccleOffsetY = new Vector2(0, 0);
    [HideInInspector]
    public int score;
    private bool isGameOver = false;
    void Awake(){
        //singleton
        if(Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    public bool IsGameActive(){
        return !isGameOver; 
    }
    public bool IsGamerOver(){
        return isGameOver;
    }
    public void EndGame(){
        isGameOver = true;
        Debug.Log("GAME OVER. Your score is: "+ score);

        StartCoroutine(ReloadScene(2));
    }
    
    private IEnumerator ReloadScene(float delay){
        yield return new WaitForSeconds(delay);

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName); 
    }
}
