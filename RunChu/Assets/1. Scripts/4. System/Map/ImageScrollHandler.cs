using System;
using System.Collections;
using UnityEngine;

public class ImageScrollHandler : MonoBehaviour
{
    [Header("Image Component")]
    [SerializeField] private Transform[] images;

    private float scrollSpeed;  
    private float leftPosX = 0f;
    private float xScreenHalfSize = 0f;
    private float yScreenHalfSize;
    private Vector3 timeDelta; // 매초 움직이는 값
    private Vector3 rightDelta; // 오른쪽 끝으로 움직이는 값
    private Camera mainCam;
    private float imageSizeX;

    private void Start()
    {
        mainCam = Camera.main;

        InitParams();
        InitImages();
    }

    private void Update()
    {
        InfiniteScrolling();
    }

    /// <summary>
    /// 배경 무한맵을 만들기 위한 변수들 초기화
    /// </summary>
    private void InitParams()
    {
        yScreenHalfSize = mainCam.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * mainCam.aspect;

        imageSizeX = images[0].GetComponent<Renderer>().bounds.size.x; // 이미지 하나의 크기
        leftPosX = mainCam.transform.position.x - xScreenHalfSize - (imageSizeX / 2f); // 왼쪽 좌표

        scrollSpeed = GameManager.Instance.Unit.Data.Speed; // 스크롤 속도 = 플레이어 속도
        timeDelta = new Vector3(-scrollSpeed, 0, 0); // 매 초 움직이는 거리
        rightDelta = new Vector3(imageSizeX * images.Length, 0, 0); // 왼쪽 맵이 오른쪽 끝으로 이동할 때 더해지는 값
    }

    /// <summary>
    /// 게임 시작시 이미지를 겹치지않게 나열
    /// </summary>
    private void InitImages()
    {
        if (images.Length < 2) return;

        float standardXPos = images[0].position.x;

        for (int i = 1; i < images.Length; i++)
        {
            standardXPos += imageSizeX;
            Vector3 nextPos = images[i].position; 
            nextPos.x = standardXPos; 
            
            images[i].position = nextPos;
        }
    }

    /// <summary>
    /// 무한 스크롤 로직 메서드
    /// </summary>
    /// <returns></returns>
    private void InfiniteScrolling()
    {
        if (xScreenHalfSize == 0) return;

        for (int i = 0; i < images.Length; i++)
        {
            // 플레이어가 특정 상태이상에 걸려 속도가 달라졌을 때, 스크롤 속도도 느려져야함
            if (GameManager.Instance.Unit.StatHandler.GetCurrentSpeed() != scrollSpeed)
            {
                timeDelta = new Vector3(-GameManager.Instance.Unit.StatHandler.GetCurrentSpeed(), 0, 0);
            }
            images[i].position += timeDelta * Time.deltaTime; // 이미지를 지정된 속도만큼 x축 이동

            if (images[i].position.x < leftPosX)
            {
                Vector3 nextPos = images[i].position;
                nextPos += rightDelta;
                images[i].position = nextPos;
            }
        }
    }

}
