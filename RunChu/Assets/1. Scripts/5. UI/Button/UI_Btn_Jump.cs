using UnityEngine.UI;
using UnityEngine;

public class UI_Btn_Jump : UI_Btn
{
    [SerializeField] private int jumpCount;

    protected override void Start()
    {
        base.Start();
        btn.onClick.AddListener(OnClickJumpBtn);

        jumpCount = 0;
        GameManager.Instance.Player.EventHandler.OnGround += CheckOnGround;
    }

    private void OnClickJumpBtn()
    {
        GameManager.Instance.Player.EventHandler.CallJumpEvent();

        jumpCount ++;

        if(jumpCount == 2){
            DeActivateBtn();
            jumpCount = 0;
        } 
    }

    private void CheckOnGround(bool onGround)
    {
        if(onGround){
            ActivateBtn();
            jumpCount = 0;
        }          
    }
}
