using UnityEngine;

public interface ICopy
{
    public ICopy Copy(Transform parent);
}

public class BaseEnemy : Clone
{ 
    [SerializeField]protected int speed;
    
    public virtual void Attack()
    {
        
    }
}

