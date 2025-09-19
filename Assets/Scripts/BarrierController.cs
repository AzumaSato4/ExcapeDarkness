using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public float deleteTime = 5;


    void Start()
    {
        Destroy(gameObject, deleteTime);    
    }
}
