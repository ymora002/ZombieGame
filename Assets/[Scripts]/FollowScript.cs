using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public float Speed;

    private Vector3 Human;

    private Transform Dog;


    void Update()
    {
        //Ignore y position of target and allow natural gravity of Dog
        Human = new Vector3(Target.position.x, Dog.position.y, Target.position.z);


        // calculate distance to move
        float distance = Speed * Time.deltaTime; 


        Debug.Log("FOLLOW THE HUMAN!!");


        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        var lookPos = Target.position - transform.position;
        lookPos.y = 0;
        var targetRotation = Quaternion.LookRotation(lookPos);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Speed * 4f * Time.deltaTime);
    }

    public Transform Target;

    #region Setup
    private void Awake()
    {
        Dog = this.transform;
    }
    #endregion




}
