using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJogador : MonoBehaviour {

	public int vidaInicial = 100;
	public int vidaAtual;
	public Slider sliderVida;
	public Image danoImagem;
	public AudioClip somMorte;
	public float velCorFlash;
	public Color corFlash = new Color(1f, 0f, 0f, 0.1f);

	Animator anim;
	AudioSource jogadorAudio;
	PlayerMove movimentacaoJogador;
	bool estaMorto;
	bool teveDano;
	TiroJogador tiroJogador;

	void Awake(){
		
		anim = GetComponent<Animator> ();
		jogadorAudio = GetComponent<AudioSource> ();
		movimentacaoJogador = GetComponent<PlayerMove> ();
		vidaAtual = vidaInicial;
		tiroJogador = GetComponentInChildren<TiroJogador> ();
	}
	void Start () {
		
	}
	

	void Update () {
		if (teveDano) {
			danoImagem.color = corFlash;
		} else {
			danoImagem.color = Color.Lerp (danoImagem.color, Color.clear, velCorFlash * Time.deltaTime);
		}
		teveDano = false;
	}
	public void HouveDano(int vida){
		teveDano = true;
		vidaAtual -= vida;
		sliderVida.value = vidaAtual;
		jogadorAudio.Play ();
		if (vidaAtual <= 0 && !estaMorto) {
			Morte ();
		}
	}
	void Morte (){
		tiroJogador.InativarEfeitos ();
		estaMorto = true;
		anim.SetTrigger ("morreu");
		jogadorAudio.clip = somMorte;
		jogadorAudio.Play ();
		movimentacaoJogador.enabled = false;
		tiroJogador.enabled = false;
	}

	public void TempoReiniciarJogo(){
		StartCoroutine (ReiniciarJogo ());
	}

	IEnumerator ReiniciarJogo(){
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene (0);

}
}
