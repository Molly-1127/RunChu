using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageIndicator : MonoBehaviour
{
    [Header("Stage Indicator Info")]
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private Image unitProgressImage;
    [SerializeField] private Image enemyProgressImage;
    [SerializeField] private Image totalBarImage;

    private StringBuilder distanceSB = new StringBuilder();
    private StringBuilder stageSB = new StringBuilder();

    private RectTransform totalBarRect;
    private RectTransform unitProgressRect;
    private RectTransform enemyProgressRect;

    private void Awake()
    {
        totalBarRect = totalBarImage.GetComponent<RectTransform>();
        unitProgressRect = unitProgressImage.GetComponent<RectTransform>();
        enemyProgressRect = enemyProgressImage.GetComponent<RectTransform>();
    }

    private void Start()
    {
        StageManager.Instance.OnStageStart += UpdateStageText;
        StageManager.Instance.OnDistanceChanged += UpdateDistanceText;
        StageManager.Instance.OnDistanceChanged += UpdateUnitProgressImage;
    }

    private void UpdateStageText()
    {
        stageSB.Clear();
        stageSB.Append("STAGE ");
        stageSB.Append(StageManager.Instance.StageData.StageNumber);

        stageText.text = stageSB.ToString();
    }

    private void UpdateDistanceText(float distance)
    {
        distanceSB.Clear();
        distanceSB.Append((int)distance);
        distanceSB.Append(" M");

        distanceText.text = distanceSB.ToString();
    }

    private void UpdateUnitProgressImage(float distance)
    {
        float progressPercentage = distance / StageManager.Instance.StageData.Distance;
        SetProgressImage(progressPercentage, unitProgressRect);
    }
    
    private void UpdateEnemyProgressImage(int distance)
    {
        SetProgressImage(1f, enemyProgressRect);
    }

    /// <summary>
    /// progress 바를 0~1 비율로 볼 때, image를 progressPercentage위치에 옮기는 메서드
    /// </summary>
    /// <param name="progressPercentage">0.0f에서 1.0f 사이의 진행 비율</param>
    /// <param name="rect">위치를 옮길 RectTransform 컴포넌트</param>
    private void SetProgressImage(float progressPercentage, RectTransform rect)
    {
        float totalWidth = totalBarRect.rect.width;

        // 목표 X 위치
        float targetX = totalWidth * progressPercentage;

        // 앵커 위치를 바꾸는 것이므로, 두 progressImage의 앵커가 반드시 왼쪽으로 잡혀있어야함!
        rect.anchoredPosition = new Vector2(targetX-2f, rect.anchoredPosition.y);
    }
}
