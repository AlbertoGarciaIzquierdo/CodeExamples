using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    //FLOATS
    float volumenConfig = 1;
    public float speed = 2f;
    private float direccion;

    //BOOLS
    bool flEnabled, moving, gastadaLinterna = false;
    bool corriendo = true;

    //AUDIO
    AudioSource audios;
    AudioSource audios2;
    public AudioClip lightOn, lightOff, stepsSFX, runSFX;
    AudioClip movementAudio;

    //RIGIDBODY

    //LIGHTS
    public Light auxLight;
    public Light flashLight;

    //VECTORES


    //GAMEOBJECT


	//BYTES
	public byte fuelLantern = 100;
    

    void Start () {

        //DECLARACION DE GETCOMPONENTS
		audios = GetComponent<AudioSource> ();
		audios2 = GetComponent<AudioSource> ();

		StartCoroutine (LanternFuel ());
	}

	void Update (){
        LinternaMethod();
        CorrerMethod();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MovimientoMethod();
	}

    void LinternaMethod()
    {

        //Apagar o encender
        if (Input.GetKeyDown(KeyCode.F) && gastadaLinterna == false)
        {
            if (flEnabled == false)
            {
                flEnabled = true;
                audios2.PlayOneShot(lightOn, 0.2f);
                auxLight.enabled = true;
                flashLight.enabled = true;
                GetComponentInChildren<Animation>().Play("FlashLightAnim");
            }
            else
            {
                flEnabled = false;
                audios2.PlayOneShot(lightOff, 0.2f);
                auxLight.enabled = false;
                flashLight.enabled = false;
                GetComponentInChildren<Animation>().Stop();
            }
        }
    }

    void CorrerMethod()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!corriendo)
            {
                audios.Stop();
                volumenConfig = 1;
                movementAudio = runSFX;
                corriendo = true;
            }
            speed = 3f;
        }
        else
        {
            if (corriendo)
            {
                audios.Stop();
                volumenConfig = 2;
                movementAudio = stepsSFX;
                corriendo = false;
            }
            speed = 1f;
        }
    }

    void MovimientoMethod()
    {

        direccion = Input.GetAxis("Horizontal");

        if (direccion > 0)
        {
            moving = true;
            if (!audios.isPlaying)
                GetComponent<AudioSource>().PlayOneShot(movementAudio, 0.2f * volumenConfig);
			transform.localScale = new Vector3 (1f, 1f, 1f);
        }
        if (direccion < 0)
        {
            moving = true;
            if (!audios.isPlaying)
                GetComponent<AudioSource>().PlayOneShot(movementAudio, 0.2f * volumenConfig);
			transform.localScale = new Vector3 (-1f, 1f, 1f);
        }
        if (direccion == 0)
        {
            if (moving == true)
            {
                audios.Stop();
                moving = false;
            }
        }

        transform.Translate(direccion * Vector2.right * speed * Time.deltaTime);
    }

	IEnumerator LanternFuel(){
		while (true) {
			if (flEnabled) {
				if (fuelLantern > 0)
				fuelLantern -= 2;

				if (fuelLantern > 75) {
					flashLight.intensity = 3f;
					auxLight.intensity = 2f;
				}
				if (fuelLantern > 50 && fuelLantern <= 75) {
					flashLight.intensity = 2.5f;
					auxLight.intensity = 1.5f;
				}
				if (fuelLantern > 25 && fuelLantern <= 50) {
					flashLight.intensity = 2f;
					auxLight.intensity = 1f;
				}
				if (fuelLantern > 0 && fuelLantern <= 25) {
					flashLight.intensity = 1.5f;
					auxLight.intensity = 0.5f;
				}
				if (fuelLantern == 0) {
					gastadaLinterna = true;
					flashLight.enabled = false;
					auxLight.enabled = false;
				}
			}
			yield return new WaitForSeconds (5);
		}
	}
}
