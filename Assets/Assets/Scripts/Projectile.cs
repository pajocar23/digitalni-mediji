using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyPorjectile", lifeTime);
        Invoke("DestroyPorjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1f,0f,0f) * speed * Time.deltaTime);
    }

    void DestroyPorjectile()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            
            collision.gameObject.GetComponent<EnemyAttack>().enemyHealth--;
            //print("Enemy hp: "+ collision.gameObject.GetComponent<EnemyAttack>().enemyHealth);

            if (collision.gameObject.GetComponent<SpriteRenderer>().color.g > 0.2)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(collision.gameObject.GetComponent<SpriteRenderer>().color.r, collision.gameObject.GetComponent<SpriteRenderer>().color.g - 0.2f, collision.gameObject.GetComponent<SpriteRenderer>().color.b - 0.2f, collision.gameObject.GetComponent<SpriteRenderer>().color.a);
            }
           
            if (collision.gameObject.GetComponent<EnemyAttack>().enemyHealth < 0)
            {
                Destroy(collision.gameObject);
                Invoke("LoadLastScene", 1.5f);
            }

            //print("Boje: " + collision.gameObject.GetComponent<SpriteRenderer>().color);

        }
    }

    void LoadLastScene()
    {
        SceneManager.LoadScene(2);
    }


}
