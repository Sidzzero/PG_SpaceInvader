using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.spaceinvaders
{ 
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView view;

        [SerializeField] private Transform resBullet;

        private PlayerData data;
        private void LateUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                view.Move(eDirection.LEFT);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                view.Move(eDirection.RIGHT);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var createdBullet =Instantiate(resBullet,view.transform.position,transform.rotation);
                createdBullet.GetComponent<Bullet>().vDirection = Vector3.up;
            }
        }
    }
}
