using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour
{

    // initialization
    bool ate = false;
    public GameObject TailPrefab;
    Vector2 dir = Vector2.right; //default
    List<Transform> tail = new List<Transform>();


    int Score;
    
    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.name.StartsWith("FoodPrefab"))
        {
            ate = true;
            Destroy(coll.gameObject);
            Score++;
            //SpawnFood sn = gameObject.GetComponent<SpawnFood>();
            //sn.Spawn();
        }
        else
        {
            print("Game Over");
            print("Your score is " + Score);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;    
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right; 
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
    }
    void Move()
    {
        // current position in v
        Vector2 pos = transform.position;

        transform.Translate(dir); 

        //insert new element if it eats something
        if (ate)
        {
            // Load Prefab 
            GameObject tailPrefab = Instantiate(TailPrefab,pos,Quaternion.identity);

            tail.Insert(0, tailPrefab.transform); //adding new position of tail to tail list

            // Reset flag
            ate = false;
        }
        else if (tail.Count > 0)
        {
            // Moving last Tail Element to where the Head was
            tail.Last().position = pos;

            // Adding to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
}