using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class WithinSight : Conditional
{ 
    // How wide of an angle the object can see
    public float fieldOfViewAngle;
    // The tag of the targets
    public string targetTag;
    public float distance;
    // Set the target variable when a target has been found so th subsequent tasks know which object is the target
   //public SharedTransform target;
    // A cache of all of the possible targets
    private Transform[] possibleTargets;
    public GameObject targets;
    public SharedBool isWithinSight;


    public override void OnAwake()
    {
        /*// Cache all of the transforms that have a tag of targetTag
        targets = GameObject.FindGameObjectsWithTag(targetTag);
        possibleTargets = new Transform[targets.Length];
        for (int i = 0; i < targets.Length; ++i)
        {
            possibleTargets[i] = targets[i].transform;
        }*/
    }
    public override TaskStatus OnUpdate()
    {
        // Return success if a target is within sight
        // for (int i = 0; i < possibleTargets.Length; ++i)
        // {
        isWithinSight.Value = withinSight(targets.transform);
            if (isWithinSight.Value)
            {
 // Set the target so other tasks will know which transformis within sight
           // target.Value = possibleTargets[i];
                return TaskStatus.Success;
            }
       // }
        return TaskStatus.Failure;
    }
    // Returns true if targetTransform is within sight of current transform
    public bool withinSight(Transform targetTransform)
    {
        Vector3 direction = targetTransform.position - transform.position;


       // UnityEngine.Debug.Log("distance: " + (Vector3.Distance(transform.position, targets.transform.position)));
        // An object is within sight if the angle is less than field ofview
        return ((Vector3.Angle(direction, transform.forward) < fieldOfViewAngle) && (Vector3.Distance(transform.position,targets.transform.position)< distance));
    }
}