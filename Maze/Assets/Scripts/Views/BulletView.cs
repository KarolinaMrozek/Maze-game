using UnityEngine;

namespace Views
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] float autoDestroyAfterSeconds = 4f;


        void Start()
        {

            Destroy(gameObject, autoDestroyAfterSeconds);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
        }

    }
}