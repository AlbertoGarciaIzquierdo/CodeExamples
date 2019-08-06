using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	// FLOATS
	public sbyte direccion = 1;

	// VECTORES RAYCAST
	public Vector3 posInicial;
	public Vector2 distancia;
	private Vector3 posRaycast;
	private Color targetColor;

    // PLAYER TARGETED
    GameObject player;

	// Use this for initialization
	void Start () {
		//RAYCAST
		posInicial = new Vector3 (0.5f,0.5f,0f);
		distancia = new Vector2 (8.0f,0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		RayCastMethod ();
	}

	void PatrolEnemyMethod(){

	}

    void PlayerSpottedMethod()
    {

    }

	void RayCastMethod() {

		posRaycast = transform.position + posInicial;
		posRaycast.x = (transform.position.x + (posInicial.x * direccion));

		// Testeo
		if (true) {
			Debug.DrawRay (posRaycast, (Vector2.left + distancia) * direccion, targetColor);
		}

		// Codigo Valido
		RaycastHit2D rayCast = Physics2D.Raycast (posRaycast, (Vector2.left + distancia) * direccion);
		if (rayCast.collider.tag == "Player") {
			targetColor = Color.red;
		} else {
			targetColor = Color.green;
		}
	}
}
