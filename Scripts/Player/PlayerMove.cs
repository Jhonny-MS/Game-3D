using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float velocidade = 6f;
	Vector3 movimento;
	Animator anim;
	Rigidbody rbJogador;
	int pisoMask;
	float camLongitude = 100f;

	void Awake(){
		anim = GetComponent<Animator> ();
		rbJogador = GetComponent<Rigidbody> ();
		pisoMask = LayerMask.GetMask ("Piso");
	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Mov (h, v);
		Apontar ();
		Animar (h,v);


	}
	void Mov(float h, float v){
		movimento.Set (h, 0f, v);
		movimento = movimento.normalized * velocidade * Time.deltaTime;
		rbJogador.MovePosition (transform.position + movimento);

	}
	void Apontar(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit pisoHit;
		if (Physics.Raycast (camRay, out pisoHit, camLongitude, pisoMask)) {
			Vector3 jogadorMouse = pisoHit.point - transform.position;
			jogadorMouse.y = 0f;
			Quaternion novaRotacao = Quaternion.LookRotation (jogadorMouse);
			rbJogador.MoveRotation (novaRotacao);
		}
			
	}

	void Animar(float h, float v){
		bool parado = ((v == 0) && (h == 0));
		anim.SetBool ("estaAndando", !parado);
	}
	void Start () {
		
	}
	

	void Update () {
		
	}
}
