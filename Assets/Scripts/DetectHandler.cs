using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (gameObject.tag.Equals("Fail"))
        {
            //TODO decrease award
            transform.parent.GetComponent<RotateController>().AddReward(-1f);
            //
            transform.parent.GetComponent<RotateController>().EndEpisode();
        } else if (gameObject.tag.Equals("Success"))
        {
            //TODO increase award
            transform.parent.GetComponent<RotateController>().AddReward(0.1f);
            //
            transform.parent.GetComponent<RotateController>().Score += 1;
            if (transform.parent.GetComponent<RotateController>().Score > ScoreHistory.Instance.Highscore)
            {
                ScoreHistory.Instance.Highscore = transform.parent.GetComponent<RotateController>().Score;
            }
            transform.parent.GetComponent<RotateController>().EndEpisode();
        }
    }
}
