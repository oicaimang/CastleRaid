using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    private float xspot;
    private float yspot;

    // Start is called before the first frame update

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }




    void OnMouseOver()
    {

        if (gameObject.CompareTag("obstacles"))
        {
            Collider[] nearObjects = Physics.OverlapSphere(gameObject.transform.position, 1f);
            foreach (Collider Object in nearObjects)
            {
                if (Object.tag == "obstacles") //Does the object have a certain tag.
                {

                    Destroy(Object.gameObject);
                }


            }
        }


    }
}
