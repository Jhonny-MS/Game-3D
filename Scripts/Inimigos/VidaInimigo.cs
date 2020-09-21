using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VidaInimigo : MonoBehaviour {

	public int vidaInicial = 100;
	public int vidaAtual;
	public float velMover = 2.5f;
	public int pontos = 10;
	public AudioClip somMorte;


	Animator anim;
	AudioSource somInimigo;
	ParticleSystem hitParticulas;
	CapsuleCollider colisor;
	bool morreu;
	bool atingido;

	void Awake(){
		
		anim = GetComponent<Animator> ();
		somInimigo = GetComponent<AudioSource> ();
		hitParticulas = GetComponentInChildren<ParticleSystem> ();
		colisor = GetComponent<CapsuleCollider> ();
		vidaAtual = vidaInicial;

	}

	void Start () {
		
	}
	

	void Update () {
		if (atingido) {
			transform.Translate (-Vector3.up * velMover * Time.deltaTime);
		}

	}

	public void DanoInimigo(int valorDano, Vector3 localAtingido){
		if (morreu) {
			return;
		}
		somInimigo.Play ();
		vidaAtual -= valorDano;
		hitParticulas.transform.position = localAtingido;
		hitParticulas.Play ();
		if (vidaAtual <= 0) {
			Morreu ();
		}
	}
	void Morreu(){
		morreu = true;
		colisor.isTrigger = true;
		anim.SetTrigger ("morto");
		somInimigo.clip = somMorte;
		somInimigo.Play ();

}
	public void StartSinking(){
		GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		atingido = true;
		Destroy (gameObject, 2f);
		ConfigPontos.ponto += pontos;
	}

}
