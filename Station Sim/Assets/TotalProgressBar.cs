using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalProgressBar : MonoBehaviour
{
    public float MaxValue;
    private float CurrentValue = 0;
    public Image Mask;
    public GameObject GameStateManager;

    private void Start()
    {
        MaxValue = GameStateManager.GetComponent<GameStateManager>().Rounds.Count;
    }

    public void UpdateProgress()
    {
        CurrentValue++;
        float fillAmount = (float)CurrentValue / (float)MaxValue;
        Mask.fillAmount = fillAmount;
    }
}
