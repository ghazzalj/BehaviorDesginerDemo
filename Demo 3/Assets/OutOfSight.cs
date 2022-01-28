using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class outOfSight : Conditional
{
   

    public SharedBool _outOfSight;


    public override TaskStatus OnUpdate()
    {

        if (_outOfSight.Value)
        {

            _outOfSight.Value = false;
                return TaskStatus.Success;
            




        }
        else return TaskStatus.Failure;



    }
}
