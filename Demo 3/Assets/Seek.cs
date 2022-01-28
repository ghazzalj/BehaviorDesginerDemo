using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class Seek : Action
{
    // The speed of the object
    public float speed = 0;
    // The transform that the object is moving towards
    public SharedTransform target;

    public SharedBool outOfSight;


    public override TaskStatus OnUpdate()
    {

        if (outOfSight.Value)
        {
            // Return a task status of success once we've reached the target
            if (Vector3.SqrMagnitude(transform.position -
           target.Value.position) < 0.1f)
            {
                return TaskStatus.Success;
            }



            // We go to the targets last location and move towards it if the target is out of sight.

            transform.position = Vector3.MoveTowards(transform.position,
            target.Value.position, speed * Time.deltaTime);
            return TaskStatus.Running;
            

        }
        else return TaskStatus.Failure;



    }
}