public class UI_Btn_Slide : UI_Btn
{
    public void OnPointerDownSlideBtn()
    {
        GameManager.Instance.Player.EventHandler.CallSlideEvent(true);
    }

    public void OnPointerUpSlideBtn()
    {
        GameManager.Instance.Player.EventHandler.CallSlideEvent(false);
    }
}