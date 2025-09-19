using UnityEngine;

public class BillData : MonoBehaviour
{
    Rigidbody2D rbody;
    public int itemNum; //アイテムの識別番号

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();        //Rigidbody2Dコンポーネントの取得
        rbody.bodyType = RigidbodyType2D.Static;    //Rigidbodyの挙動を静止
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.bill++; //1増やす
            //該当する取得フラグをON
            GameManager.itemPickedState[itemNum] = true;

            //アイテム取得演出
            //コライダーを無効化
            GetComponent<CircleCollider2D>().enabled = false;

            //Rigidbody2Dの復活(Dynamicにする)
            rbody.bodyType = RigidbodyType2D.Dynamic;

            //上に打ち上げ(上向き5の力)
            rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

            //自分自身を抹消(0.5秒後)
            Destroy(gameObject, 0.5f);
        }
    }
}
