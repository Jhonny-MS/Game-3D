using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigPontos : MonoBehaviour {

	public static int ponto;
	Text text;

	void Awake (){
		text = GetComponent<Text> ();
		ponto = 0;
	}

	void Update () {
		text.text = "Pontos: " + ponto;
	}
}
