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

        public void UI_UpdateScore(int a_Score)
        {
            uiScoreText.text = a_Score.ToString();
        }
        public void UI_UpdateLives(int a_iLives)
        {
            uiLivesText.text = a_iLives.ToString();
        }
    }
}
