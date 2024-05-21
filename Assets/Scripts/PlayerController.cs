using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float jumpPower = 10;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool isGameActive =  GameManager.Instance.IsGameActive();
        bool canJump = jumpCooldown <= 0 && isGameActive;
        
        if(canJump){
            bool jumpingInput = Input.GetKey(KeyCode.Space);
            if(jumpingInput){
                jump();
        }
        
        }
        thisRigidbody.useGravity = isGameActive;
    }

    void OnCollisionEnter(Collision other){
        onCustomCollider(other.gameObject);
    }

    void OnTriggerEnter(Collider other){
        onCustomCollider(other.gameObject);
    }
    private void onCustomCollider(GameObject other){
        bool isSensor = other.CompareTag("Sensor");
        if(isSensor){
            GameManager.Instance.score++;
            Debug.Log("Scrore: " + GameManager.Instance.score);
        } else{
            GameManager.Instance.EndGame();
            
        }
    }

    private void jump(){
        jumpCooldown = jumpInterval;
        //resetar cooldown

        thisRigidbody.velocity = Vector3.zero;
        //vector3.zero é o mesmo que new vector3(0,0,0)

        thisRigidbody.AddForce(new Vector3(0, jumpPower,0), ForceMode.Impulse);
        //aplicar a força
    } 
}
