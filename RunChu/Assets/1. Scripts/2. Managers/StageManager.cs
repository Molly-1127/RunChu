using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public event Action OnStageStart;
    public event Action OnStageEnd;
    public event Action<float> OnDistanceChanged;
    public StageSO StageData;

    private bool isStageEnd;
    private float curDistance = 0f;
    private Coroutine stageCor;

    private void Start()
    {
        StageStart();
    }

    private void StageStart()
    {
        isStageEnd = false;
        curDistance = 0f;

        OnStageStart?.Invoke();
        OnDistanceChanged?.Invoke(curDistance);

        if (stageCor != null)
            StopCoroutine(stageCor);
        stageCor = StartCoroutine(StageCoroutine());
    }

    private IEnumerator StageCoroutine()
    {
        while (!isStageEnd)
        {
            curDistance = Mathf.Min(curDistance + Time.deltaTime * GameManager.Instance.Unit.StatHandler.GetCurrentSpeed(), StageData.Distance);
            OnDistanceChanged?.Invoke(curDistance);

            if (CheckStageEnd())
            {
                OnStageEnd?.Invoke();
                yield break;
            }
                
            yield return null;
        }
    }

    private bool CheckStageEnd()
    {
        if (isStageEnd)
            return true;
        if (curDistance >= StageData.Distance)
            return true;
        return false;
    }
}
