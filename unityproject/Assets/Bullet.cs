using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.spaceinvaders
{
    public class Bullet : MonoBehaviour
    {
        public float fSpeed = 2.1f;
        public GameManager instanceGM;
        public Vector3 vDirection = Vector3.up;

        public bool bEnemyOnly = true;
        private void Start()
        {
            instanceGM = GameManager.Instance;
            Destroy(this.gameObject, 5);
        }
      
        private void Update()
        {
            transform.Translate(vDirection * Time.deltaTime * fSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (bEnemyOnly && other.tag == "Enemy")
            {
                instanceGM.GE_EnemyHitByBullet(other.GetComponent<EnemyView>(), this);
            }
            if (bEnemyOnly == false && other.tag == "Player")
            {
                GameManager.Instance.GE_PlayerHurt(other.GetComponent<PlayerView>(), gameObject);
            }
        }
    }
}