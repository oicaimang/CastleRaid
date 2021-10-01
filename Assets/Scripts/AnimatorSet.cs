using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSet : MonoBehaviour
{
    public static AnimatorSet Instance;

    private Animator playerAni;
    
    public float speed;

    //public static AnimatorSet Instance;
    private Rigidbody playerBlue;

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        playerAni = GetComponent<Animator>();
        playerBlue = GameObject.Find("blueTeam").GetComponent<Rigidbody>();
        



    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Round(playerBlue.velocity.magnitude * 2.347f);
        if (speed > 0)
        {
            playerAni.SetFloat("Speed_f", 0.6f);


        }
        else
        {
            playerAni.SetFloat("Speed_f", 0f);
            
}

    }
    
    
}
