using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyze : IState
{

    private GameObject alien;
    private bool complete;

    float totalRotation = 0;
    float rotationAmount = 180;

    public Analyze (GameObject alien, bool complete)
    {
        this.alien = alien;
        this.complete = complete;
    }

    public void Enter()
    {

    }

    public void Execute()
    {

        Vector3 to = new Vector3(0.0f, 0.0f,180.0f);

        if (Vector3.Distance(alien.transform.eulerAngles, to) > 4.0f)
        {
            alien.transform.eulerAngles = Vector3.Lerp(alien.transform.rotation.eulerAngles, to, Time.deltaTime);
        }
        else
        {
            alien.transform.eulerAngles = to;
            complete = true;
        }



        //if (alien.transform.rotation.z != 180)
        //{
        //    alien.transform.Rotate(0.0f, 0.0f, 100 * Time.deltaTime);
        //}
        //else
        //{
        //    alien.transform.Rotate(0.0f, 0.0f, 0.0f);
        //}



    }

    public void Exit()
    {

    }


}
