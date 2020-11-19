using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHandler : MonoBehaviour
{
    public ScoreHistory scoreHistory;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name + " " + name);

        if (gameObject.tag.Equals("Fail"))
        {
            //TODO decrease award
            
            transform.parent.GetComponent<RotateController>().OnRest();
        } else if (gameObject.tag.Equals("Success"))
        {
            //TODO increase award
            
            transform.parent.GetComponent<RotateController>().Score += 1;
            if (transform.parent.GetComponent<RotateController>().Score > scoreHistory.Highscore)
            {
                scoreHistory.Highscore = transform.parent.GetComponent<RotateController>().Score;
            }
            transform.parent.GetComponent<RotateController>().OnRest();
        }
    }
}
