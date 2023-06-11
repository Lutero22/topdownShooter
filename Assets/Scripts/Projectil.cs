using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
	public float speed;

	public GameObject effect;

	
	private void Update()
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Enemy")){ 
			other.GetComponent<Enemigo>().vida--;
			Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
