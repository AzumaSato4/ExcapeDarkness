using UnityEngine;

public class BillData : MonoBehaviour
{
    Rigidbody2D rbody;
    public int itemNum; //�A�C�e���̎��ʔԍ�

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();        //Rigidbody2D�R���|�[�l���g�̎擾
        rbody.bodyType = RigidbodyType2D.Static;    //Rigidbody�̋�����Î~
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.bill++; //1���₷
            //�Y������擾�t���O��ON
            GameManager.itemPickedState[itemNum] = true;

            //�A�C�e���擾���o
            //�R���C�_�[�𖳌���
            GetComponent<CircleCollider2D>().enabled = false;

            //Rigidbody2D�̕���(Dynamic�ɂ���)
            rbody.bodyType = RigidbodyType2D.Dynamic;

            //��ɑł��グ(�����5�̗�)
            rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

            //�������g�𖕏�(0.5�b��)
            Destroy(gameObject, 0.5f);
        }
    }
}
