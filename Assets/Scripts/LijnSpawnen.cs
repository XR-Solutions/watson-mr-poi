using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LijnSpawnen : MonoBehaviour
{
    public float Hoek_van_Inslag;
    public float Richting_van_inslag;
    public GameObject Line;
    // Start is called before the first frame update
    void Start()
    {
    OnPointerClick:Instantiate(Line, transform);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
