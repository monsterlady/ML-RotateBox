using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class RotateController : Agent
{

    [SerializeField] public float rotateDegree;
    [SerializeField] public KeyCode left;
    [SerializeField] public KeyCode right;
    [SerializeField] public GameObject[] checkpoints;
    private Quaternion boxStartingRot;
    private Quaternion ballStartingRot;
    private Vector3 ballStartingPos;
    private Rigidbody rBody;
    private int _score = 0;

        // Start is called before the first frame update

        public override void Initialize()
    {
        rBody = transform.GetChild(0).GetComponent<Rigidbody>();
        boxStartingRot = transform.rotation;
        ballStartingPos = rBody.transform.position;
    }
        
        public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if (Input.GetKey(left))
        {
            actionsOut[0] = 1;
        } else if (Input.GetKey(right))
        {
            actionsOut[0] = 2;
        }
    }
    

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(rBody.transform.localPosition);
        sensor.AddObservation(rBody.velocity);
        sensor.AddObservation(transform.rotation);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        
        if (Mathf.FloorToInt(vectorAction[0]) == 1)
        {
           RotateLeft();
        } else if (Mathf.FloorToInt(vectorAction[0]) == 2)
        {
            RotateRight();
        } 
    }
    
    public override void OnEpisodeBegin()
    {
        foreach (GameObject cp in checkpoints)
        {
            cp.SetActive(true);
        }
        OnRest();
    }
    
    private void RotateLeft()
    {
        transform.Rotate(Vector3.forward,-rotateDegree);
    }

    private void RotateRight()
    {
        transform.Rotate(Vector3.forward,rotateDegree);
    }

    public void OnRest()
    {   
        transform.rotation = boxStartingRot;
        rBody.velocity = Vector3.zero;
        rBody.angularVelocity = Vector3.zero;
        rBody.transform.position = ballStartingPos;
        rBody.transform.rotation = ballStartingRot;
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }
}
