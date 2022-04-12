using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{

    public string state = "none";

    public float force = 100f;
    private Animator animator;

    private bool facingRight = true;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.Play("Player_Idle");

        actions.Add("above", Above);
        actions.Add("down", Down);
        actions.Add("left", Left);
        actions.Add("right", Right);
        actions.Add("stop", Stop);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Stop();
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
  
        //Debug.Log(speech.text);

        if (speech.text == "")
        {
            animator.Play("Player_Idle");
        }

        actions[speech.text].Invoke();  
    }

    private void Above()
    {
        state = "above";
        animator.Play("Player_walk_up");
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force));
    }

    private void Down()
    {
        state = "down";
        animator.Play("Player_walk_down");
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -force));
    }

    private void Left()
    {
        state = "left";
        if (facingRight == true)
        {
            this.transform.Rotate(0f, 180f, 0f);
        }
        facingRight = false;
        animator.Play("Player_walk_lr");
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, 0f));
    }

    private void Right()
    {
        state = "right";
        if (facingRight == false)
        {
            this.transform.Rotate(0f, 180f, 0f);
        }
        facingRight = true;
        animator.Play("Player_walk_lr");
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0f));
    }

    private void Stop()
    {
        animator.Play("Player_Idle");
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
    }

}
