using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ゲーム状態を管理する列挙型
    public enum GameState
    {
        playing,
        talk,
        gameover,
        gameclear,
        ending
    }

    static public bool hasSpotLight;  //スポットライトを持っているかどうか

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
