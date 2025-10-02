public class UI_Btn_Slide : UI_Btn
{
    public void OnPointerDownSlideBtn()
    {
        GameManager.Instance.Unit.EventHandler.CallSlideEvent(true);
    }

    public void OnPointerUpSlideBtn()
    {
        GameManager.Instance.Unit.EventHandler.CallSlideEvent(false);
    }
}