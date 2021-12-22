using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace sidz.spaceinvaders
{ 
public class UIController : MonoBehaviour
{
        public TMP_Text uiScoreText;
        public TMP_Text uiLivesText;

        public GameObject uiGameOver;
        public GameObject uiGameStart;

        public void UI_UpdateScore(int a_Score)
        {
            uiScoreText.text = a_Score.ToString();
        }
        public void UI_UpdateLives(int a_iLives)
        {
            uiLivesText.text = a_iLives.ToString();
        }
        public void UI_TryAgain()
        {
            GameManager.Instance.RestartGame();
        }
        public void UI_StartGame()
        {
            GameManager.Instance.StartGame();
        }
        public void UI_RestartGame()
        {
            GameManager.Instance.RestartGame();
        }
        public void UI_QuitGame()
        {
            GameManager.Instance.QuitGame();
        }

        public void UI_ToggleGameOverScreen(bool a_bState)
        {
            uiGameOver.SetActive(a_bState);
        }
        public void UI_ToggleGameStartScreen(bool a_bState)
        {
            uiGameStart.SetActive(a_bState);
        }
    }
}
