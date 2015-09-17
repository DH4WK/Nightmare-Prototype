namespace Player
{
    using UnityEngine;
    using System.Collections;

    public class PlayerAnimationControllScript : MonoBehaviour
    {
        private Animator anim;

        float move;

        int speedHashID = Animator.StringToHash("Speed");

        // Use this for initialization
        void Start()
        {
            // Get the animator
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            move = Input.GetAxis("Vertical");
            //anim.SetFloat("Speed", move);
            anim.SetFloat(speedHashID, move);
        }
    }
}
