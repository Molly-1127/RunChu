using UnityEngine;

public class CameraFollowHandler : MonoBehaviour
{
    [Header("Camera Property")]
    [SerializeField] private float cameraFrontOffset; // 카메라가 플레이어보다 얼마나 앞에 있을 것인지
    [SerializeField] [Range(0f,1f)] private float smoothing = 1f; // 얼마나 부드럽게 이동할 것인지

    private Player player;

    private void Start()
    {
        player = GameManager.Instance.Player;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x + cameraFrontOffset, transform.position.y, -1);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }
}
