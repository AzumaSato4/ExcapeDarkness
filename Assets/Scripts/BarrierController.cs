using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public float deleteTime = 5;


    void Start()
    {
        SoundManager.instance.SEPlay(SEType.Barrier); //�o���A������������

        //deleteTime�b��ɏ���
        Destroy(gameObject, deleteTime);    
    }
}
