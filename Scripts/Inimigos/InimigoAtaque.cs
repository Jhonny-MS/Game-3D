using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtaque : MonoBehaviour {

	public float tempoDelayAtaque = 0.5f;
	public int danoAtaque = 10;

	Animator anim;
	GameObject jogador;
	VidaJogador vidaJogador;
	bool jogadorCercado;
	float tempo;

	void Awake () {
		jogador = GameObject.FindGameObjectWithTag ("Player");
		vidaJogador = jogador.GetComponent<VidaJogador>();
		anim = GetComponent<Animator> ();
	}
	void OnTriggerEnter(Collider obj){
		if (obj.gameObject == jogador) {
			jogadorCercado = true;
		}
	}
	void OnTriggerExit(Collider obj){
		if (obj.gameObject == jogador) {
			jogadorCercado = false;
		}
	}


	void Update () {
		tempo += Time.deltaTime;
		if (tempo >= tempoDelayAtaque && jogadorCercado) {
			Ataque ();
		}
		if (vidaJogador.vidaAtual <= 0) {
			anim.SetTrigger ("jogadorMorto");
		}
	}

	void Ataque(){
		tempo = 0f;
		if (vidaJogador.vidaAtual > 0) {
			vidaJogador.HouveDano (danoAtaque);
			
	}

}
}
