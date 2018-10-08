using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
	public GameObject projetilPrefab;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Atirar();
		}
	}

	private void Atirar()
	{
		GameObject projetil = Instantiate(
			projetilPrefab,
			Camera.main.transform.position,
			Camera.main.transform.rotation
		);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Zumbi"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
