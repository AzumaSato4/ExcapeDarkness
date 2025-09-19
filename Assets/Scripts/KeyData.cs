using UnityEngine;

public enum KeyType
{
    key1,
    key2,
    key3
}

public class KeyData : MonoBehaviour
{
    public KeyType keytype = KeyType.key1;  //識別タイプ
    Rigidbody2D rbody;


    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (keytype)
            {
                case KeyType.key1:
                    GameManager.key1++;
                    GameManager.keyPickedState[0] = true;
                    break;
                case KeyType.key2:
                    GameManager.key2++;
                    GameManager.keyPickedState[1] = true;
                    break;
                case KeyType.key3:
                    GameManager.key3++;
                    GameManager.keyPickedState[2] = true;
                    break;
            }

            //取得演出
            GetComponent<CircleCollider2D>().enabled = false;
            rbody.bodyType = RigidbodyType2D.Dynamic;
            rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);
        }
    }
}
