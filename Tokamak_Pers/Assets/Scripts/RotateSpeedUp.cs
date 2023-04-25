using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpeedUp : MonoBehaviour
{
    public float speedIncrease = 0.5f; 
    private Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
    {
   
        anim.speed += speedIncrease * Time.deltaTime;
    }
}
