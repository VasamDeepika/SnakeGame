using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour
{
    // Food Prefab
    public GameObject foodPrefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    bool ate = false;

    void Start()
    {
        // Spawn food every 4 seconds, starting in 1
            InvokeRepeating("Spawn", 1, 4);
    }

    public void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x); //generates random x value in between left and right borders
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); //object,position,rotation
    }
}