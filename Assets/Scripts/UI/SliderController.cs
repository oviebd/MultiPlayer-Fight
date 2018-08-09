using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class SliderController : MonoBehaviour
{

    Slider slider;
    float cooldownTimer;
    bool isOnCooldown;
    Image[] signImages;

	// Use this for initialization
	void Start ()
    {       
        slider = GetComponent<Slider>();
        isOnCooldown = false;

        signImages = GetComponentsInChildren<Image>();
        foreach (Image image in signImages)
        {
            image.enabled = false;
        }

        OnCooldown(10f);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (isOnCooldown)
        {
            float percentage = (slider.maxValue - slider.minValue) * Time.deltaTime/cooldownTimer;
            slider.value += percentage;

            if (Mathf.Approximately(slider.value, slider.maxValue))
            {
                isOnCooldown = false;
                slider.value = slider.maxValue;

                foreach (Image image in signImages)
                {
                    image.enabled = false;
                }
            }
        }

	}

    public void OnCooldown(float time)
    {
        isOnCooldown = true;
        cooldownTimer = time;

        foreach (Image image in signImages)
        {
            image.enabled = true;
        }

        slider.value = slider.minValue;

    }
}
