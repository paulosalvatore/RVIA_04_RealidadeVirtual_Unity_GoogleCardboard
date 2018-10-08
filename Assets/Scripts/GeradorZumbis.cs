using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
	public GameObject zumbiPrefab;
	public float delay = 2f;
	public float area = 5f;

	// Use this for initialization
	private void Start()
	{
		InvokeRepeating("GerarZumbi", delay, delay);
	}

	private void GerarZumbi()
	{
		Vector2 posicaoAleatoria = Random.insideUnitCircle * area;

		GameObject zumbi = Instantiate(zumbiPrefab);
		zumbi.transform.position = new Vector3(
			posicaoAleatoria.x,
			zumbiPrefab.transform.position.y,
			posicaoAleatoria.y
		);
	}
}
