using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

	//HUD BUTTON
	public GameObject buttonToPress;
    public Image spriteHUD;
    [Range (0,1)]
    public float alphaSpeed;

    //AUDIOSOURCE
    AudioSource audios;
    public AudioClip DoorOpenSFX, DoorCloseSFX;

    //VARIABLES ABRIR Y CERRAR
    float startRotation;
    sbyte speed = 100;
    sbyte direccion;
    sbyte savedDireccion;
    sbyte enemySavedDireccion;

	public bool locked;
    public bool abriendo;
    public bool abierto;
    public bool cerrado;
    public bool cerrando;
    private BoxCollider2D doorCollider;

	// Use this for initialization
	void Start () {
        audios = GetComponent<AudioSource>();
        startRotation = transform.GetChild(0).eulerAngles.y;
        doorCollider = GetComponentInChildren<DummyScripts>().GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        DoorMethod();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Color color = spriteHUD.color;
            color.a = alphaSpeed;
            spriteHUD.color = color;
            buttonToPress.SetActive(true);

        }          
    }

	void OnTriggerStay2D(Collider2D other)
    {
		if (Input.GetKey (KeyCode.E)) {
			if (!locked) {
				if (cerrado) {
					savedDireccion = direccion;
					abriendo = true;
				}
				if (abierto)
					cerrando = true;
			}
			/*if (locked){
				// Play sound locked
			}*/
		}

        if (other.gameObject.tag == "Enemy")
        {
            if (!locked)
            {
                if (cerrado)
                {
                    savedDireccion = direccion;
                    abriendo = true;
                }
            }
        }

        // PLAYER DIRECTION DOOR
        if (other.transform.position.x - transform.position.x > 0)
            direccion = -1;
        if (other.transform.position.x - transform.position.x < 0)
            direccion = 1;
        // ENEMY DIRECTION DOOR
        /*
        if (other.transform.position.x - transform.position.x > 0)
            direccion = -1;
        if (other.transform.position.x - transform.position.x < 0)
            direccion = 1;*/
    }

	void OnTriggerExit2D(Collider2D other)
    {
		if (other.gameObject.tag == "Player")
			buttonToPress.SetActive (false);
        if (abierto && other.gameObject.tag == "Enemy")
            cerrando = true;
    }
    
    void DoorMethod()
    {
        if (!locked)
        {
            if (abriendo)
            {
                if (!audios.isPlaying)
                {
                    audios.PlayOneShot(DoorOpenSFX, 0.4f);
                }
                abierto = false;
                transform.GetChild(0).Rotate(Vector3.up * speed * savedDireccion * Time.deltaTime);
            }
            if (transform.GetChild(0).eulerAngles.y > startRotation + 90f || transform.GetChild(0).eulerAngles.y < startRotation - 90f)
            {
                abriendo = false;
                abierto = true;
                cerrado = false;
            }
            if (cerrando)
            {
                if (!audios.isPlaying)
                {
                    audios.PlayOneShot(DoorCloseSFX, 0.4f);
                }
                cerrado = false;
                transform.GetChild(0).Rotate(Vector3.up * speed * -savedDireccion * Time.deltaTime);
            }
            if (transform.GetChild(0).eulerAngles.y > startRotation - 1 && transform.GetChild(0).eulerAngles.y < startRotation + 1)
            {
                cerrando = false;
                cerrado = true;
                abierto = false;
            }
            if (cerrado)
            {
                doorCollider.enabled = true;
            }
            else
            {
                doorCollider.enabled = false;
            }
        }

    }
}
