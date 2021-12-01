using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace sidz.spaceinvaders
{
    public class GameManager : MBSingleton<GameManager>
    {
        [Header("Controllers")]
        public UIController uiController;
        private Vector2 vScreenBounds;
        private PlayerData data;
        public override void OnInit()
        {
            base.OnInit();
            ServiceLocator.Instance.AddService(this);
            vScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            StartGame();
        }

        #region HELPER_FUNC
        public void Helper_InsideGameBounds(ref Vector3 a_vWorldPos)
        {
            a_vWorldPos.x = Mathf.Clamp(a_vWorldPos.x, (vScreenBounds.x), -vScreenBounds.x);
            a_vWorldPos.y = Mathf.Clamp(a_vWorldPos.y, (vScreenBounds.y), -vScreenBounds.y);
        }

        #endregion HELPER_FUNC

        #region GAME_LOGIC
        public void StartGame()
        {
            //PLayer Data
            data = new PlayerData();
            data.iLives = 3;
            data.iScore = 0;
            uiController.UI_UpdateScore(data.iScore);
            uiController.UI_UpdateLives(data.iLives);

            //Generate Enemies ?

            //Events setup

            //Start Movement
        }
        public void RestartGame()
        { 
         //Reset PLayer data
         //Reset Enemies 
         //Start Movement
        }

        public void PauseGame()
        { 
        
        }
        
        public void GE_EnemyHitByBullet(EnemyView a_enemyView , Bullet a_bullet)
        {
            data.iScore++;
            uiController.UI_UpdateScore(data.iScore);
            Destroy(a_enemyView.gameObject);
            Destroy(a_bullet.gameObject);
        }
        public void GE_PlayerHurt(PlayerView playerView, GameObject a_otherObject)
        {
            data.iLives--;
            Destroy(a_otherObject);
            if (data.iLives <=0)
            {
                data.iLives = 0;
                GameOver();
                return;
            }
            uiController.UI_UpdateLives(data.iLives);
        }
        public void GameOver()
        {
            Time.timeScale = 0;
        }

       
        #endregion GAME_LOGIC
    }
}