using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacle
{
    [Header("Obstacle Component")]
    [SerializeField] protected EObstacleType type;
    [SerializeField] protected int damage;
    [SerializeField] protected LayerMask unitMask;

    protected virtual void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        damage = DataManager.Instance.ObstacleDataDictionary[type];
        IntroAnim();
    }

    public virtual void OnCollide()
    {
        GameManager.Instance.Unit.StatHandler.TakeDamage(damage);
    }

    public virtual void IntroAnim()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ExtensionMethods.IsSameLayer(unitMask, collision.transform.gameObject.layer))
        {
            OnCollide();
        }
    }

}
