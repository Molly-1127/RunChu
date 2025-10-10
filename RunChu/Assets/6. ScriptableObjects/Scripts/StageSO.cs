using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stage", fileName = "StageSO")]
public class StageSO : ScriptableObject
{
    [Header("Stage Info")]
    public int ID; // 고유 id
    public int StageNumber; // 스테이지 번호
    public int Distance; // 스테이지 총 길이
    public List<SegmentData> Data = new List<SegmentData>();
}
