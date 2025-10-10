
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public Dictionary<EObstacleType, int> ObstacleDataDictionary = new Dictionary<EObstacleType, int>();

    protected override void Awake()
    {
        base.Awake();
        InitObstacleData();
    }

    /// <summary>
    /// 임시로 직접 적용. 추후 구글 데이터 시트와 연동 (데이터 로드 후 사용되도록 수정)
    /// key - 장애물 타입, value - 장애물 데미지
    /// </summary>
    private void InitObstacleData()
    {
        ObstacleDataDictionary[EObstacleType.EJumpSingle] = 10;
        ObstacleDataDictionary[EObstacleType.EJumpDouble] = 30;
        ObstacleDataDictionary[EObstacleType.EPlatformer] = 0;
        ObstacleDataDictionary[EObstacleType.EDropHarzard] = 50;
    }
}
