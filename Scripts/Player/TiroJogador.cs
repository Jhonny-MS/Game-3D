using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroJogador : MonoBehaviour {

	public int danoPorTiro = 20;
	public float intervaloTiro = 0.15f;
	public float distanciaTiro = 100;


	float tempo;
	Ray tiroRaio = new Ray();
	RaycastHit localDoTiro;
	int tiroMask;
	ParticleSystem particulaTiro;
	LineRenderer tiroLinha;
	AudioSource somTiro;
	Light luzTiro;
	float tempoEfeitoDisparo = 0.2f;


	void Awake(){
		tiroMask = LayerMask.GetMask ("Disparavel");
		particulaTiro = GetComponent<ParticleSystem> ();
		tiroLinha = GetComponent<LineRenderer> ();
		somTiro = GetComponent<AudioSource> ();
		luzTiro = GetComponent<Light> ();

	}


	void Start () {
		
	}
	

	void Update () {
		tempo += Time.deltaTime;
		if (Input.GetButton ("Fire1") && tempo >= intervaloTiro) {
			Atirar ();
		}
		if (tempo >= intervaloTiro * tempoEfeitoDisparo) {
			InativarEfeitos ();
		}
	}
		public void InativarEfeitos(){
			tiroLinha.enabled = false;
			luzTiro.enabled = false;

	}
	void Atirar(){
		tempo = 0f;
		somTiro.Play ();
		luzTiro.enabled = true;
		particulaTiro.Stop ();
		tiroLinha.enabled = true;
		tiroLinha.SetPosition (0, transform.position);
		tiroRaio.origin = transform.position;
		tiroRaio.direction = transform.forward;

		if (Physics.Raycast (tiroRaio, out localDoTiro, distanciaTiro, tiroMask)) {
			VidaInimigo vidaInimigo = localDoTiro.collider.GetComponent<VidaInimigo> ();
			if (vidaInimigo != null) {
				vidaInimigo.DanoInimigo (danoPorTiro, localDoTiro.point);
			}
			tiroLinha.SetPosition (1, localDoTiro.point);
		} else {
			tiroLinha.SetPosition (1, tiroRaio.origin + tiroRaio.direction * distanciaTiro);
	}

			
}
}
