using UnityEngine;

    //�Q�[����Ԃ��Ǘ�����񋓌^
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
    public static GameState gameState;  //�Q�[���̃X�e�[�^�X
    public static bool[] doorsOpenedState;  //�h�A�̊J��
    public static int key1; //��1�̎�����
    public static int key2; //��2�̎�����
    public static int key3; //��3�̎�����
    public static bool[] keyPickedState;    //���̎擾��

    public static int bill = 10; //���D�̎�����
    public static bool[] itemPickedState;   //�A�C�e���̎擾��

    static public bool hasSpotLight;  //�X�|�b�g���C�g�������Ă��邩�ǂ���
    public static int playerHP = 3;  //�v���C���[��HP



    void Start()
    {
        //�܂��̓Q�[���͊J�n��Ԃɂ���
        gameState = GameState.playing;
    }


    void Update()
    {

    }
}
