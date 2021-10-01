using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public Rigidbody playerRed;
    
    public GameObject playerRedCenter;
    [SerializeField] float forceattack = 10;
    private MoveForward playerBluereference;
    
    // Start is called before the first frame update
    void Start()
    {
        
        playerRed = GetComponent<Rigidbody>();
        playerBluereference = GameObject.Find("blueTeam").GetComponent<MoveForward>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBluereference.conditiontoDefense == true)
        {
            Vector3 attack = (playerRedCenter.transform.position - playerRed.transform.position).normalized;
            playerRed.AddForce(attack * forceattack);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("blueTeam"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }



}
