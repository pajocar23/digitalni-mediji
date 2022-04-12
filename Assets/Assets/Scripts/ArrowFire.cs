using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFire : MonoBehaviour
{

    public Transform shootingPointRight;
    public Transform shootingPointAbove;
    public Transform shootingPointDown;

    public GameObject arrow;

    private PlayerMovement playerMovement;
    private Animator animator;

    public float cooldownTime=2;

    private float nextFireTime=0;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        playerMovement = this.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time>nextFireTime)
        {
            nextFireTime = Time.time + cooldownTime;

            if (playerMovement.state == "above")
            {
                //Transform newPosition1 = shootingPointRight;
                //newPosition1.position = new Vector3(shootingPointAbove.position.x, shootingPointAbove.position.y, shootingPointAbove.position.z * -1);

                animator.Play("Player_shooting_up");
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                Instantiate(arrow, shootingPointAbove.position, Quaternion.Euler(0f,0f,90f));    
            }
            else if (playerMovement.state == "down")
            {
                //Transform newPosition2 = shootingPointDown;
                //newPosition2.position = new Vector3(shootingPointDown.position.x, shootingPointDown.position.y, shootingPointDown.position.z * -1);

                animator.Play("Player_shooting_down");
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                Instantiate(arrow, shootingPointDown.position, Quaternion.Euler(0f, 0f, -90f));
            }
            else if (playerMovement.state == "right" || playerMovement.state == "left")
            {
                //Transform newPosition3= shootingPointRight;
                //newPosition3.position= new Vector3(shootingPointRight.position.x, shootingPointRight.position.y, shootingPointRight.position.z*-1);

                animator.Play("Player_shooting_lr");
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                Instantiate(arrow, shootingPointRight.position, transform.rotation);
            }

            StartCoroutine(startDefaultAnim(0.5f));

        }
    }

    IEnumerator startDefaultAnim(float secs)
    {
        yield return new WaitForSeconds(secs);
        animator.Play("Player_Idle");
    }


}
