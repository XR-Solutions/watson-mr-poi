using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InputRedirect : MonoBehaviour
{

    public TMP_Text Textinput;
    public TMP_Text Textoutput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Textinput.text = Textoutput.text;
    }
}
