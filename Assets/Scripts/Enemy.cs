using UnityEngine;
using System.Collections;

/// �G
public class Enemy : Token
{
    public static int Count = 0;
    public static int Count2 = 0;
    public AudioClip sound1;
    AudioSource audioSource;
    bool flag = true;
    /// �J�n
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Count++;
        Count2 = Count - 1;
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        // �����_���ȕ����Ɉړ�����
        // �����������_���Ɍ��߂�
        float dir = Random.Range(0, 359);
        // ������2
        float spd = 7;
        SetVelocity(dir, spd);
    }
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
        if (Enemy.Count == Enemy.Count2 && flag == true)
        {
            audioSource.PlayOneShot(sound1);
            flag = false;
            Enemy.Count2--;
        }
        else if (Enemy.Count == Enemy.Count2 && flag == false)
        {
            audioSource.PlayOneShot(sound1);
            flag = true;
            Enemy.Count2--;
        }
    }
    public void OnMouseDown()
    {

        // �p�[�e�B�N���𐶐�
        Count--;
        for (int i = 0; i < 32; i++)
        {
            Particle.Add(X, Y);
        }
        // �j����
        DestroyObj();
    }

}