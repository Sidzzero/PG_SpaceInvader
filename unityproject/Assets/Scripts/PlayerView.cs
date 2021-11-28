using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.spaceinvaders
{
    public class PlayerView : MonoBehaviour
    {
        public float fMoveDistance = 1;
        private Vector3 vMovingPos;
        public void Move(eDirection a_Direction)
        {
            vMovingPos = transform.position;
            switch (a_Direction)
            {
                case eDirection.LEFT:
                    vMovingPos = transform.position - transform.right * fMoveDistance*Time.deltaTime;
                   GameManager.Instance.Helper_InsideGameBounds(ref vMovingPos);
                    break;
                case eDirection.RIGHT:
                    vMovingPos =  transform.position + transform.right * fMoveDistance * Time.deltaTime;
                    GameManager.Instance.Helper_InsideGameBounds(ref vMovingPos);
                    break;
            }
            transform.position = vMovingPos;
        }

        
    }
}