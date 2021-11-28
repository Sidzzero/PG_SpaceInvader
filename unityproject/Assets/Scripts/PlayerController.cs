using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.spaceinvaders
{ 
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView view;

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
        }
    }
}
