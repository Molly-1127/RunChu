using UnityEngine;
using UnityEngine.UI;

public class UI_Slider : MonoBehaviour
{
    [Header("Slider Component")]
    [SerializeField] protected Image fillImage;

    protected Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }
}
