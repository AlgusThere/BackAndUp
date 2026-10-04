using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    [Header("Referanslar")]
    [SerializeField] GameObject ground;
    [SerializeField] Transform groundParent;
    [SerializeField] Transform playerTransform;
    [SerializeField] int groundCount = 12;
    [SerializeField] float groundOffsetLength = 10f;
    [SerializeField] float groundSpeed = 10f;


    List<GameObject> grounds = new List<GameObject>();

    void Start()
    {
        InstantiateGround();
    }

    void Update()
    {
        MoveGrounds();
    }

    void InstantiateGround()
    {
        for(int i = 0; i < groundCount; i++)
        {            
            Vector3 groundSpawnPosition = new Vector3(transform.position.x, transform.position.y, i * groundOffsetLength);
            GameObject newGround = Instantiate(ground, groundSpawnPosition, Quaternion.identity, groundParent);
            grounds.Add(newGround);     
        }
    }

    void MoveGrounds()
    {

        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].transform.position += Vector3.back * groundSpeed * Time.deltaTime;
        }

        GameObject oldGround = grounds[0];

        if(playerTransform.position.z - oldGround.transform.position.z > groundOffsetLength)
        {
            GameObject newGround = grounds[grounds.Count - 1];
            float nextZPosition = newGround.transform.position.z + groundOffsetLength;

            oldGround.transform.position = new Vector3(oldGround.transform.position.x, oldGround.transform.position.y, nextZPosition);
            
            grounds.RemoveAt(0);
            grounds.Add(oldGround);
        }
    }
}
