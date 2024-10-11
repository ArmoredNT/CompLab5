using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{

    [SerializeField]
    public PathManager pathManager;

    List<Waypoint> thePath;
    Waypoint target;

    public bool isWalking = false;

    public float MoveSpeed;
    public float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        thePath = pathManager.GetPath();
        if(thePath != null && thePath.Count > 0)
        {
            // set starting target to the first waypoint
            target = thePath[0];
        }
    }

    void rotateTowardsTarget()
    {
        float stepSize = RotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    void moveForward()
    {
        float stepSize = Time.deltaTime * MoveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize)
        {
         
        }
        Vector3 movDir = Vector3.forward;
        transform.Translate(movDir * stepSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        target = pathManager.GetNextTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            // toggle if any key is pressed
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
        }
    }
}
