using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    Rigidbody2D gameover;
    public void Start()
    {
        gameover = GetComponent<Rigidbody2D>();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {

       
        if (collision.gameObject.CompareTag("block"))
        {
            Debug.Log("ya");
            BlockSpawner.instance.GameOver();
        }



    }
}
