using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerBlue : MonoBehaviour
{
    public GameObject playerBlue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = playerBlue.transform.position + new Vector3(0, 40, 0);
    }
}
