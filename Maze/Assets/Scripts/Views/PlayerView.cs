using System;
using Models;
using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {

        public GameObject thePlayer;
        public bool isRunning;
        public float horizontalMove;
        public float verticalMove;

     
        
         public static event Action<PlayerView, Vector3> OnPlayerFired;

        public float speed = 3f;

        [SerializeField] PlayerModel playerModel;
        [SerializeField] Camera cam;
        [SerializeField] Animator anim;
        private static readonly int DIE_TRIGGER = Animator.StringToHash("Die");

        void Update()
         {
                if (Input.GetMouseButton(0))
                {
                    var destination = GetFireDestination();
                    OnPlayerFired?.Invoke(this, destination);
                }

                /* if (Input.GetKey(KeyCode.D))
                  {
                      transform.Rotate(Vector3.right * speed);
                  }

                  if (Input.GetKey(KeyCode.A))
                  {
                      transform.Translate(Vector3.left * speed);
                  }*/

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed);
            }


            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 8;
                isRunning = true;
                transform.Rotate(0, horizontalMove, 0);
                transform.Rotate(0, 0, verticalMove);
            }



        }

        Vector3 GetFireDestination()
        {
            var ray = cam.ViewportPointToRay(
             new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y,
                    Input.mousePosition.z));
            return Physics.Raycast(ray, out var hit) ? hit.point : ray.GetPoint(1000);
        }

        public void Die()
        {
            anim.SetTrigger(DIE_TRIGGER);
        }
    }
}