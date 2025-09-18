using UnityEngine;

    //ゲーム状態を管理する列挙型
    public enum GameState
    {
        playing,
        talk,
        gameover,
        gameclear,
        ending
    }

public class GameManager : MonoBehaviour
{
    public static GameState gameState;  //ゲームのステータス
    public static bool[] doorsOpenedState;  //ドアの開閉状況
    public static int key1; //鍵1の持ち数
    public static int key2; //鍵2の持ち数
    public static int key3; //鍵3の持ち数
    public static bool[] keyPickedState;    //鍵の取得状況

    public static int bill = 10; //お札の持ち数
    public static bool[] itemPickedState;   //アイテムの取得状況

    static public bool hasSpotLight;  //スポットライトを持っているかどうか
    public static int playerHP = 3;  //プレイヤーのHP



    void Start()
    {
        //まずはゲームは開始状態にする
        gameState = GameState.playing;
    }


    void Update()
    {

    }
}
