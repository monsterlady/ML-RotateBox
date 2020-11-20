using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHandler : MonoBehaviour
{
    private bool _checkPoint1;
    private bool _checkPoint2;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            if (gameObject.tag.Equals("Fail"))
            {
                // decrease award
                transform.parent.GetComponent<RotateController>().AddReward(-1f);
                //
                transform.parent.GetComponent<RotateController>().EndEpisode();
            } else if (gameObject.tag.Equals("Success"))
            {
                // increase award
                transform.parent.GetComponent<RotateController>().AddReward(0.7f);
                //
                transform.parent.GetComponent<RotateController>().Score += 1;
                if (transform.parent.GetComponent<RotateController>().Score > ScoreHistory.Instance.Highscore)
                {
                    ScoreHistory.Instance.Highscore = transform.parent.GetComponent<RotateController>().Score;
                }
                transform.parent.GetComponent<RotateController>().EndEpisode();
            } else if (gameObject.tag.Equals("Border"))
            {
                // decrease award
                transform.parent.GetComponent<RotateController>().AddReward(-1f);
                //
                transform.parent.GetComponent<RotateController>().EndEpisode();
            } else if (gameObject.name.Equals("RightTop") || gameObject.name.Equals("LeftTop"))
            {
                // decrease award
                transform.parent.GetComponent<RotateController>().AddReward(-1f);
                //
                transform.parent.GetComponent<RotateController>().EndEpisode();
            }
        }
    }

     void OnTriggerExit(Collider collision)
    {
        if (collision.tag.Equals("Ball"))
        {
            if (gameObject.tag.Equals("CheckPoint"))
            {
                // increase award
                switch (name)
                {
                        case "AwardCheckPoint1":
                        transform.parent.GetComponent<RotateController>().AddReward(0.3f);
                        break;
                        case "AwardCheckPoint2":
                        transform.parent.GetComponent<RotateController>().AddReward(0.5f);
                        break;
                        case "AwardCheckPoint3":
                        transform.parent.GetComponent<RotateController>().AddReward(0.1f);
                        break;
                        default:
                            break;
                }
                if (gameObject.name.Equals("AwardCheckPoint1"))
                {
                    transform.parent.GetComponent<RotateController>().RequestDecision();
                }
                gameObject.SetActive(false);
            }
        }
    }
}
