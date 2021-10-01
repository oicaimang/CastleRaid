using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveForward : MonoBehaviour
{
    public static MoveForward Instance;
    public Rigidbody playerBlue;
    public Rigidbody target;
    [SerializeField] LayerMask obstaclesMask;

    [SerializeField] float max_avoid = 10;
    private float Seek_Coffiency = 5;

    /*private float forceSmall = 1;*/



    public bool conditiontoDefense=false;
   

    [SerializeField] float forceTarget = 15.0f;
    

   // [SerializeField] float forceForward = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerBlue = GetComponent<Rigidbody>();

        target = GameObject.Find("redTeam").GetComponent<Rigidbody>();
        


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (conditiontoDefense == false)
        {


            playerBlue.AddForce(Pursuit(target.transform) + obstacleAvoidance());


        }
        else { }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sensor"))
        {
            conditiontoDefense = true;
                       

        }
        

    }
    Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 velocityEnemyRb = playerBlue.velocity;
        Vector3 desired_velocity = (target.transform.position - playerBlue.transform.position).normalized * Seek_Coffiency;
        Vector3 seek = desired_velocity - velocityEnemyRb;
        return seek;
    }
    Vector3 obstacleAvoidance()
    {
        Vector3 velocity = playerBlue.velocity;
        Vector3 steering = Vector3.zero;

        RaycastHit outInfor;
        int mask = 1 << LayerMask.NameToLayer("obstacles");
        bool hit = Physics.Raycast(transform.position, new Vector3(velocity.x, velocity.y, velocity.z), out outInfor, 3, mask);
        if (hit)
        {
            if (outInfor.collider.gameObject.layer == LayerMask.NameToLayer("obstacles"))
            {
                Vector3 diff = -(playerBlue.transform.position - outInfor.collider.gameObject.transform.position);
                Vector3 diffrotate = Quaternion.Euler(0, 90, 0) * diff;

                steering += new Vector3(diffrotate.x, diffrotate.y, diffrotate.z).normalized * max_avoid;
                Debug.Log("collider");
            }
        }
        steering = steering.normalized * max_avoid;
        Debug.DrawRay(transform.position, new Vector3(velocity.x, velocity.y, velocity.z) * 1, Color.red);
        return steering;
    }
    Vector3 Pursuit(Transform targetTransform)
    {
        float updatesAhead = 3;
        Vector3 futurePosition = targetTransform.position + new Vector3(targetTransform.GetComponent<Rigidbody>().velocity.x, targetTransform.GetComponent<Rigidbody>().velocity.y, 0) * updatesAhead;
        return Seek(futurePosition);
    }


}
