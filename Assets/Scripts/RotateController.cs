using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;

public class RotateController : MonoBehaviour
{

    [SerializeField] private float rotateDegree;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    private Quaternion boxStartingRot;
    private Quaternion ballStartingRot;
    private Vector3 ballStartingPos;
    private Rigidbody rBody;
    private int _score = 0;

        // Start is called before the first frame update
    void Start()
    {
        rBody = transform.GetChild(0).GetComponent<Rigidbody>();
        boxStartingRot = transform.rotation;
        ballStartingPos = rBody.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.forward,-rotateDegree);
        }
        
        if (Input.GetKey(right))
        {
            transform.Rotate(Vector3.forward,rotateDegree);
        }

        if (Input.GetKey(KeyCode.K))
        {
            OnRest();
        }
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
