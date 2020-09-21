using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPositionScript : MonoBehaviour {

	public Transform alvo;
	public float suavizacao = 5f;
	Vector3 distancia;

	void Start () {
		distancia = transform.position - alvo.position;
	}
	

	void FixedUpdate () {
		Vector3 alvoCameraPos = alvo.position + distancia;
		transform.position = Vector3.Lerp (transform.position, alvoCameraPos, suavizacao * Time.deltaTime);
			
	}
}
