using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    RoomTemplates templates;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 2f);
    }

    void Spawn()
    {
        for (int i=0;i< templates.rooms.Count;i++)
        {
            if (templates.rooms[i].name != "Entry Room" && i!= templates.rooms.Count-1)
            {
                int rand = Random.Range(0, templates.obastcles.Length+1);

  
                if(rand< templates.obastcles.Length)
                {
                    Instantiate(templates.obastcles[rand], templates.rooms[i].transform.position, Quaternion.identity);
                }
            }
        }
    }


}
