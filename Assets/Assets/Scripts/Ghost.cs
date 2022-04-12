using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;

    IEnumerator Start()
    {
        while (true)
        {
            do yield return null; while (MoveTowards(pointA));
            this.transform.Rotate(0f, 180f, 0f);
            do yield return null; while (MoveTowards(pointB));
            this.transform.Rotate(0f, -180f, 0f);
        }
    }

    bool MoveTowards(Transform target)
    {
        speed= Random.Range(0.6f, 2.6f);
        transform.position = Vector3.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
        return transform.position != target.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(2);
        }
    }
}

