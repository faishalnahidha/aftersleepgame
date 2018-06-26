using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarManager : MonoBehaviour {

	Image hpFill;
	Color currentHpFillColor;



	public Slider healthSlider;
	public int warningValue = 50;
	public int cautionValue = 25;

	// Use this for initialization
	void Awake () {
		hpFill = this.GetComponentInChildren <Image>();
		currentHpFillColor = hpFill.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (healthSlider.value > warningValue) {
			hpFill.color = currentHpFillColor;
		}

		if (healthSlider.value <= warningValue && healthSlider.value > cautionValue) {
			hpFill.color = new Color(1f,0.5f,0f,0.75f);
		}

		if (healthSlider.value <= cautionValue && healthSlider.value > 0) {
			hpFill.color = new Color(1f,0f,0f,0.75f);
		}

		if (healthSlider.value <= 0) {
			hpFill.color = new Color(1f,0f,0f,0f);
		}
	}

	/*void ChangeFillColor(){
		if (healthSlider.value <= 50) {
			hpFill.color = new Color(1f,0f, 0f,1f);
		}
	}*/

}
