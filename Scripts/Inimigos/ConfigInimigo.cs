using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigInimigo : MonoBehaviour {

	public VidaJogador vidaJogador;
	public GameObject inimigo;
	public float tempoSurgimento = 3f;
	public Transform[] pontoSurgimento;


	void Start () {
		InvokeRepeating ("Spawn", tempoSurgimento, tempoSurgimento);
	}

	void Spawn(){
		if (vidaJogador.vidaAtual <= 0f) {
			return;
		}

		int indiceSurgimento = Random.Range (0, pontoSurgimento.Length);
		Instantiate (inimigo, pontoSurgimento [indiceSurgimento].position, pontoSurgimento [indiceSurgimento].rotation);

	}

	void Update () {
		
	}
}
