using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Btn : MonoBehaviour
{
    [Header("Btn Component")]
    [SerializeField] protected Button btn;

    protected virtual void Start()
    {
        btn.onClick.AddListener(BtnAnimation);
    }

    protected void ActivateBtn() => btn.interactable = true;
    protected void DeActivateBtn() => btn.interactable = false;

    protected void BtnAnimation()
    {

    }
}
