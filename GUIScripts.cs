using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScripts : MonoBehaviour {

    //VARIABLES BATERIA
	public Sprite Bateria100;
	public Sprite Bateria75;
	public Sprite Bateria50;
	public Sprite Bateria25;
	public Sprite Bateria0;

	public Light lantern;
	public Light auxLight;

	public Image bateriaImage;
    public Text bateriaPercentaje;
	CharacterMovement varBateria;

    //VARIABLES SLIDER
    public Slider barraSanity;

	// Use this for initialization
	void Start () {
		varBateria = GetComponent<CharacterMovement> ();
        StartCoroutine("SanityUIMethod");
    }
	
	// Update is called once per frame
	void Update () {
        LanternUIMethod();
	}

    void LanternUIMethod()
    {
        bateriaPercentaje.text = varBateria.fuelLantern.ToString() + " %";
        if (varBateria.fuelLantern > 75)
        {
            bateriaImage.sprite = Bateria100;
        }
        if (varBateria.fuelLantern > 50 && varBateria.fuelLantern <= 75)
        {
            bateriaImage.sprite = Bateria75;
        }
        if (varBateria.fuelLantern > 25 && varBateria.fuelLantern <= 50)
        {
            bateriaImage.sprite = Bateria50;
        }
        if (varBateria.fuelLantern > 0 && varBateria.fuelLantern <= 25)
        {
            bateriaImage.sprite = Bateria25;
        }
        if (varBateria.fuelLantern == 0)
        {
            bateriaImage.sprite = Bateria0;
        }
    }
    IEnumerator SanityUIMethod()
    {
        while (true)
        {
            if (!lantern.enabled && barraSanity.value > 0)
                barraSanity.value --;
            if (lantern.enabled && barraSanity.value < 100)
                barraSanity.value++;

            yield return new WaitForSeconds(1);
        }
    }
}
