using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Token
{
    public AudioClip sound4;
    AudioSource audioSource;
    int sflag;
    int sflag2;
    bool flag = true;
    public static int gameover;
    public static int gameover2;
    public static int gameover3;
    public static int gameover4;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sflag = 0;
        sflag2 = 1;
        gameover = 0;
        gameover2 = 0;
        gameover3 = 0;
        gameover4 = 0;
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        // �����_���ȕ����Ɉړ�����
        // �����������_���Ɍ��߂�
        float dir = Random.Range(0, 359);
        float spd = 5;
        SetVelocity(dir, spd);
    }

    // Update is called once per frame
    void Update()
    {

        // �J�����̍������W���擾
        Vector2 min = GetWorldMin();
        // �J�����̉E����W���擾����
        Vector2 max = GetWorldMax();
        if (X < min.x || max.x < X)
        {
            // ��ʊO�ɏo���̂ŁAX�ړ��ʂ𔽓]����
            VX *= -1;
            // ��ʓ��Ɉړ�����
            ClampScreen();
        }
        if (Y < min.y || max.y < Y)
        {
            // ��ʊO�ɏo���̂ŁAY�ړ��ʂ𔽓]����
            VY *= -1;
            // ��ʓ��Ɉړ�����
            ClampScreen();
        }
        
        if (sflag == sflag2 && flag)
        {
            audioSource.PlayOneShot(sound4);
            flag = false;
            sflag2++;
        }
        else if (sflag == sflag2 && !flag)
        {
            audioSource.PlayOneShot(sound4);
            flag = true;
            sflag2++;
        }
    }
    public void OnMouseDown()
    {
        gameover = 1;
        gameover2 = 1;
        gameover3 = 1;
        gameover4 = 1;
        Enemy.spd = 6;
        Enemy.scr--;
        sflag++;
        if(Enemy.scr < 0)Enemy.scr = 0;
        // �p�[�e�B�N���𐶐�
        for (int i = 0; i < 32; i++)
        {
            Particle.Add(X, Y, 2);
        }
        // �j����
    }
}
