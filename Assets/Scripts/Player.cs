using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    public float speed;

	public int health;
	public TextMeshProUGUI healthDisplay;
	private float safeTime;
	public float startSafeTime;

	public int score;
	public TextMeshProUGUI scoreDisplay;
	public GameObject losePanel;
	public bool muerto;

	public float dashBoost;
	private float dashTime;
	public float startDashTime;
	private bool once;

	private void Start()
	{
		healthDisplay.text = health.ToString();
        Time.timeScale = 1f;
    }

    private void Update()
	{

		if(Input.GetMouseButtonDown(1) && once == false)
		{ 
			speed += dashBoost;
			once = true;
			dashTime = startDashTime;
		}

		if (dashTime < 0 && once == true)
		{			
			speed -= dashBoost;
			once = false;
		} else{ 
			dashTime -= Time.deltaTime;
		}

		Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
		transform.position += moveInput.normalized * speed * Time.deltaTime;


		if(safeTime > 0){ 
			safeTime -= Time.deltaTime;
		}

		scoreDisplay.text = score.ToString();

		if(health <= 0){ 
			losePanel.SetActive(true);
			speed = 0;
			muerto = true;
			Time.timeScale = 0f;

        }

	}

	public void TakeDam(int dam){ 
		if(safeTime <= 0)
		{
			health -= dam;
			healthDisplay.text = health.ToString();
			safeTime = startSafeTime;

        }
		
	}
}
