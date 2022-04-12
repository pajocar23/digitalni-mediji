using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "Wall" && other.gameObject.tag != "Enemy" && other.gameObject.tag != "Arrow" && other.gameObject.tag != "Obstacle")
		{
			Destroy(other.gameObject);
		}
	}
}
