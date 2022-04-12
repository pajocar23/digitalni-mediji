using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;

    public float speed = 1f;
    bool coroutineStarted = false;
    bool resurrectionDone = false;
    bool movementCondition = false;

    public Transform[] positions;

    public int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);

            if (distance < 4.5f)
            {
                if (resurrectionDone == false)
                {
                    this.GetComponent<Animator>().Play("Enemy_resurect");
                    resurrectionDone = true;
                }
                if (coroutineStarted == false)
                {
                    coroutineStarted = true;
                    StartCoroutine(activateAttack(2));
                    StartCoroutine(startMoving(4));
                    coroutineStarted = true;
                }

            }

            if (distance < 5f && movementCondition == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }

    }

    IEnumerator activateAttack(int secs)
    {
        yield return new WaitForSeconds(secs);
        this.GetComponent<Animator>().Play("Enemy_attack");
    }

    IEnumerator startMoving(int secs)
    {
        yield return new WaitForSeconds(secs);
        movementCondition = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(2);
        }
    }


}
