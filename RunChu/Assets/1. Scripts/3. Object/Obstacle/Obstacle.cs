using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Obstacle Component")]
    [SerializeField] protected EObstacleType type;
    [SerializeField] protected int damage;
    [SerializeField] protected LayerMask unitMask;

    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        damage = DataManager.Instance.ObstacleDataDictionary[type];
    }

    protected virtual void OnCollide()
    {
        GameManager.Instance.Unit.StatHandler.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ExtensionMethods.IsSameLayer(unitMask, collision.transform.gameObject.layer))
        {
            OnCollide();
        }
    }

}
