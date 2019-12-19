using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandlers : MonoBehaviour
{

    public Button EmissionButton;
    public LeftController leftHand;
    public RightController rightHand;

    private float red;
    private float green;
    private float blue;
    private bool isEmissive;
    private float emissive_red;
    private float emissive_green;
    private float emissive_blue;

    // Start is called before the first frame update.
    void Start()
    {
        red = 255;
        green = 255;
        blue = 255;
        isEmissive = false;
    }

    // Update is called once per frame.
    void Update()
    {

    }

    public void RedSliderChange(float value)
    {
        red = value;
        rightHand.setRed(value);
    }

    public void GreenSliderChange(float value)
    {
        green = value;
        rightHand.setGreen(value);
    }

    public void BlueSliderChange(float value)
    {
        blue = value;
        rightHand.setBlue(value);
    }

    // Emissive.
    public void isEnableEmission()
    {
        isEmissive = !isEmissive;
        rightHand.setEmissive(isEmissive);
        if (isEmissive)
        {
            EmissionButton.GetComponentInChildren<Text>().text = "DISABLE";
        } else
        {
            EmissionButton.GetComponentInChildren<Text>().text = "ENABLE";
        }
    }

    public void EmissiveRedSliderChange(float value)
    {
        emissive_red = value;
        rightHand.setEmissiveRed(value);
    }

    public void EmissiveGreenSliderChange(float value)
    {
        emissive_green = value;
        rightHand.setEmissiveGreen(value);
    }

    public void EmissiveBlueSliderChange(float value)
    {
        emissive_blue = value;
        rightHand.setEmissiveBlue(value);
    }

    public void SizeSliderChange(float value)
    {
        rightHand.setSize(value);
    }

}
