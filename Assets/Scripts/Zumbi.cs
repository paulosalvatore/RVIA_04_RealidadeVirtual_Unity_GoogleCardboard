using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
	// ...
	private Animator animator;
	private Rigidbody rb;

	public float velocidade = 0.3f;
	public float delayAndar = 1f;
	private bool andando = false;

	private bool morto = false;

	private GameObject jogador;

	// Use this for initialization
	private void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();

		Invoke("Andar", delayAndar);

		jogador = GameObject.Find("Jogador");
	}

	private void Andar()
	{
		andando = true;
	}

	// Update is called once per frame
	private void Update()
	{
		if (andando)
		{
			transform.LookAt(jogador.transform);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

			rb.velocity = (jogador.transform.position - transform.position).normalized * velocidade;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (morto)
			return;

		if (other.CompareTag("Projétil"))
		{
			// Projétil entrou em contato com o Zumbi
			Destroy(other.gameObject);
			Morrer();
		}
	}

	private void Morrer()
	{
		animator.SetTrigger("Morrer");
		andando = false;
		morto = true;
	}
}
