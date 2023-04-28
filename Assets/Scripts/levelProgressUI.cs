using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelProgressUI : MonoBehaviour
{
   [Header("UI references:")]
   [SerializeField] private Image uiFillImage;
   [SerializeField] private Text uiStartText;
   [SerializeField] private Text uiEndText;

   [Header("Object references:")]
   [SerializeField] private Transform playerTransform;
   [SerializeField] private Transform endLineTransform;

   private Vector3 endLinePosition;
   private float fullDistance;

   public void Start()
   {
    endLinePosition = endLineTransform.position;
    fullDistance = GetDistance();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
   }


   public void SetLevelTexts(int level)
   {
    uiStartText.text = level.ToString();
    uiEndText.text = (level + 1).ToString();
   }
   public float GetDistance()
   {
    return Vector3.Distance(playerTransform.position,endLinePosition);
   }
   private void UpdateProgressFill(float value)
   {
    uiFillImage.fillAmount = value;
   }

   private void Update()
   {
    float newDistance = GetDistance();
    float progressValue = Mathf.InverseLerp(0f,fullDistance,newDistance);

    UpdateProgressFill (progressValue);
   }
}
