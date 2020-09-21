using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public VidaJogador vidaJogador;
	Animator anim;

	void Awake(){
		anim = GetComponent<Animator> ();

	}
	void Update () {
		if (vidaJogador.vidaAtual <= 0) {
			anim.SetTrigger ("GameOver");
		}

	}}
