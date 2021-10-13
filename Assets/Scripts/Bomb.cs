using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Token
{
    public static int gameover;
    // Start is called before the first frame update
    void Start()
    {
        gameover = 0;
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
    }
    public void OnMouseDown()
    {
        gameover = 1;
        // �p�[�e�B�N���𐶐�
        for (int i = 0; i < 32; i++)
        {
            Particle.Add(X, Y);
        }
        /*enemyBox.SetActive(false);*/
        // �j����
        DestroyObj();
    }
}
