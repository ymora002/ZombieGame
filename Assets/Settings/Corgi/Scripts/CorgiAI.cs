using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiAI : MonoBehaviour
{
    [SerializeField] private FollowScript playerFollow;

    [SerializeField] private Animator corgiAnimator;

    public bool isPlayerVisible;
    public bool isPlayerNearby;
    public bool isPlayerPetting;


    void Update()
    {
        // Check if the position of the cube and sphere are approximately equal.
        if (isPlayerVisible)
        {
            //Debug.Log("DISTANCE: " + Vector3.Distance(transform.position, playerFollow.target.position));

            if (Vector3.Distance(transform.position, playerFollow.Target.position) < 1.0625f)
            {
                isPlayerNearby = true;



                playerFollow.enabled = false;
            }
            else
            {
                isPlayerNearby = false;

                if (corgiAnimator.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
                {
                    playerFollow.enabled = true;

                }
                else
                {
                    playerFollow.enabled = false;
                }
            }
        }
        else
        {
            playerFollow.enabled = false;
        }

        corgiAnimator.SetBool("IsPlayerVisible", isPlayerVisible);
        corgiAnimator.SetBool("IsPlayerPetting", isPlayerPetting);
        corgiAnimator.SetBool("IsPlayerNearby", isPlayerNearby);
    }




}
