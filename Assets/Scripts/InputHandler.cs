using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    public TMP_Text XTextinput;
    public TMP_Text YTextinput;
    public TMP_Text Textoutput;

    private bool X = false;
    private bool Y = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateOutput();
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic if needed
    }

    public void Enter()
    {
        if (X)
        {
            XTextinput.text = Textoutput.text;
        }

        if (Y)
        {
            YTextinput.text = Textoutput.text;
        }

        // Ensure Textoutput is updated to reflect the current active input
        UpdateOutput();
    }

    public void ActivateX()
    {
        X = true;
        Y = false;
        UpdateOutput();
    }

    public void ActivateY()
    {
        X = false;
        Y = true;
        UpdateOutput();
    }

    private void UpdateOutput()
    {
        if (X)
        {
            Textoutput.text = XTextinput.text;
        }
        else if (Y)
        {
            Textoutput.text = YTextinput.text;
        }
    }
}
