using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotatingObstacle : MonoBehaviour
{
    private float speed;

    public GameObject pivotPoint;
    private void Start()
    {
        speed = Random.Range(30f, 50f);
    }

    private void Update()
    {
        transform.RotateAround(pivotPoint.transform.position, new Vector3(0,0,1f), speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(2);
        }
    }


}
