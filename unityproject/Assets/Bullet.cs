using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.spaceinvaders
{
    public class Bullet : MonoBehaviour
    {
        public float fSpeed = 2.1f;
        private void Start()
        {
            Destroy(this.gameObject, 5);
        }
        private void Update()
        {
            transform.Translate(Vector3.up * Time.deltaTime * fSpeed);

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}