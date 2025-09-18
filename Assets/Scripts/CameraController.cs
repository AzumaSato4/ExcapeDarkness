using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;  //ターゲットとなるプレイヤーの情報

    public float followSpeed = 5.0f;    //プレイヤーに追いつくスピード

    void Start()
    {
        //プレイヤーの情報を取得
        player = GameObject.FindGameObjectWithTag("Player");

        //スタートした瞬間のカメラの現在地
        transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            -10
        );
    }


    void LateUpdate()
    {
        if (player != null) return; //ゲームオーバーの時のエラー回避

        //目指すべきポイント
        Vector3 nextPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        //現在ポイント
        Vector3 nowPos = transform.position;

        //現在地　→　目指すべき地点までの補間
        transform.position = Vector3.Lerp(nowPos, nextPos, followSpeed * Time.deltaTime);
    }
}
