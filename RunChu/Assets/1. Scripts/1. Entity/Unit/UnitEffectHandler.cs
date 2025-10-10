using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEffectHandler : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color originColor;
    private Color transparentColor;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        originColor = sprite.color;
        transparentColor = new Color(originColor.r, originColor.g, originColor.b, 0.5f);
    }

    public void SetSpriteTransparent()
    {
        sprite.color = transparentColor;
    }

    public void SetSpriteOriginal()
    {
        sprite.color = originColor;
    }
}
