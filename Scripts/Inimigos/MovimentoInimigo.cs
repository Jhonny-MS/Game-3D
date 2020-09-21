using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MovimentoInimigo : MonoBehaviour {

	Transform jogador;
	NavMeshAgent nav;
	VidaJogador vidaJogador;
	VidaInimigo vidaInimigo;

	void Awake(){
		jogador = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
		vidaJogador = jogador.GetComponent<VidaJogador> ();
		vidaInimigo = GetComponent<VidaInimigo> ();

	}

	void Start () {
		
	}
	

	void Update () {
		if(vidaInimigo.vidaAtual > 0 && vidaJogador.vidaAtual > 0){
		nav.SetDestination (jogador.position);
		}else{
			nav.enabled = false;
}
	}
}
