using System.Collections;
using TMPro;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public RoomData roomData;   //親オブジェクトの持っているスクリプトを取得
    MessageData message;    //親オブジェクトが持つScriptableObject情報を取得

    bool isPlayerInRange; //プレイヤーが領域に入ったかどうか
    bool isTalk; //トークが開始されたかどうか
    GameObject canvas; //トークUIを含んだCanvasオブジェクト
    GameObject talkPanel; //対象となるトークUIパネル
    TextMeshProUGUI nameText; //対象となるトークUIパネルの名前
    TextMeshProUGUI messageText; //対象となるトークUIパネルのメッセージ


    private void Start()
    {
        message = roomData.message; //トークデータは親オブジェクトのスクリプトにある変数を参照

        //トークUIオブジェクトなどの情報を取得
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        talkPanel = canvas.transform.Find("TalkPanel").gameObject;
        nameText = talkPanel.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        messageText = talkPanel.transform.Find("MessageText").GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        //ドアの領域内にいる　かつ　トーク中でない　かつ　Eキーが押されたら
        if (isPlayerInRange && !isTalk && Input.GetKeyDown(KeyCode.E))
        {
            //トークの始まり
            StartConversation();
        }
    }


    //トークの始まりとなるメソッド
    void StartConversation()
    {
        isTalk = true;  //トークフラグON
        GameManager.gameState = GameState.talk; //ゲームステータスがtalk
        talkPanel.SetActive(true);  //トークUIを表示
        nameText.text = message.msgArray[0].name;   //親オブジェクトから取得したmessageの配列の先頭の名前を表示
        messageText.text = message.msgArray[0].message; //親オブジェクトから取得したmessageの配列の先頭のメッセージを表示
        Time.timeScale = -0;    //ゲームの進行をストップ
        StartCoroutine(TalkProcess());   //TalkProcessコルーチンの発動
    }


    //TalkProcessコルーチンの設計
    IEnumerator TalkProcess()
    {
        //フラッシュ入力阻止のため、少し処理を止める
        yield return new WaitForSecondsRealtime(0.1f);

        //Eキーが押されるまで
        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null;  //Eキーが押されるまで何もしない
        }

        bool nextTalk = false;  //トークをさらに展開するかどうか

        switch (roomData.roomName)
        {
            case "fromRoom1":
                if (GameManager.key1 > 0)   //該当するカギを持っていたら
                {
                    GameManager.key1--; //鍵の消耗
                    nextTalk = true;    //次のトーク展開をさせる
                    GameManager.doorsOpenedState[0] = true; //記録用の施錠状況をtrue
                }
                break;
            case "fromRoom2":
                if (GameManager.key2 > 0)   //該当するカギを持っていたら
                {
                    GameManager.key2--; //鍵の消耗
                    nextTalk = true;    //次のトーク展開をさせる
                    GameManager.doorsOpenedState[1] = true; //記録用の施錠状況をtrue
                }
                break;
            case "fromRoom3":
                if (GameManager.key3 > 0)   //該当するカギを持っていたら
                {
                    GameManager.key3--; //鍵の消耗
                    nextTalk = true;    //次のトーク展開をさせる
                    GameManager.doorsOpenedState[2] = true; //記録用の施錠状況をtrue
                }
                break;
        }

        if (nextTalk)
        {
            //解錠したという類のメッセージを表示
            nameText.text = message.msgArray[1].name;
            messageText.text = message.msgArray[1].message;


            //フラッシュ入力防止
            yield return new WaitForSecondsRealtime(0.1f);

            //Eキーが押されるまで待つ
            while (!Input.GetKeyDown(KeyCode.E))
            {
                yield return null;
            }

            roomData.openedDoor = true; //親のスクリプトのドア解錠フラグをON
            roomData.DoorOpenCheck();   //解錠フラグに応じてドアの表示/非表示
        }

        EndConversation();  //コルーチンを終了してゲーム進行を戻すメソッド
    }


    void EndConversation()
    {
        talkPanel.SetActive(false); //トークUIを非表示
        GameManager.gameState = GameState.playing;//ゲームステータスをplayingに戻す
        isTalk = false; //トーク中フラグをOFF
        Time.timeScale = 1.0f;  //ゲーム進行をもとに戻す
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーが領域に入ったら
        if (collision.gameObject.CompareTag("Player"))
        {
            //フラグがオン
            isPlayerInRange = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //プレイヤーが領域に入ったら
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
