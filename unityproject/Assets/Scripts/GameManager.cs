using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace sidz.spaceinvaders
{
    public class GameManager : MBSingleton<GameManager>
    {
        private Vector2 vScreenBounds;
        public override void OnInit()
        {
            base.OnInit();
            ServiceLocator.Instance.AddService(this);
            vScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        }

        #region HELPER_FUNC
        public void Helper_InsideGameBounds(ref Vector3 a_vWorldPos)
        {
            a_vWorldPos.x = Mathf.Clamp(a_vWorldPos.x, (vScreenBounds.x), -vScreenBounds.x);
            a_vWorldPos.y = Mathf.Clamp(a_vWorldPos.y, (vScreenBounds.y), -vScreenBounds.y);
        }
        #endregion HELPER_FUNC

    }
}