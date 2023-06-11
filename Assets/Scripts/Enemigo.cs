using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemigo : MonoBehaviour
{
	public float velocidad;
	private Transform target;

	public int vida;
	public int daño;

	public bool isPatrol;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	private Vector2 Patrullar;

	private void Start()
	{

		target = GameObject.FindGameObjectWithTag("Player").transform;

		Patrullar = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
	}

	private void Update()
	{
		if(isPatrol){
			transform.position = Vector2.MoveTowards(transform.position, Patrullar, velocidad * Time.deltaTime);

			if(Vector2.Distance(transform.position, Patrullar) < 0.2f){ 
				Patrullar = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
			}
		} else{
			transform.position = Vector2.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
		}
		

		if(vida <= 0)
		{ 
			
			int randScoreBonus = Random.Range(1, 6);
			target.GetComponent<Player>().score += randScoreBonus;
			Destroy(gameObject);
		}


	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player")){ 

			other.GetComponent<Player>().TakeDam(daño);
		}
	}
}
