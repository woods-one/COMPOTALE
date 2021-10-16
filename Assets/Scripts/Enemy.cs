using UnityEngine;
using System.Collections;

/// �G
public class Enemy : Token
{
    public static int scr;
    public static int Count;
    public static int Count2;
    public AudioClip sound1;
    AudioSource audioSource;
    bool flag = true;
    public static float spd;
    public static float dir;
    /// �J�n
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scr = 0;
        Count = 1;
        Count2 = Count + 1;
        SetSize(SpriteWidth / 2, SpriteHeight / 2);
        // �����_���ȕ����Ɉړ�����
        // �����������_���Ɍ��߂�
        dir = Random.Range(0, 359);
        // ������2
        spd = 7;
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
        if (Count == Count2 && flag)
        {
            audioSource.PlayOneShot(sound1);
            flag = false;
            Count2++;
        }
        else if (Count == Count2 && !flag)
        {
            audioSource.PlayOneShot(sound1);
            flag = true;
            Count2++;
        }
    }
    public void OnMouseDown()
    {

        // �p�[�e�B�N���𐶐�
        scr++;
        Count++;
        for (int i = 0; i < 32; i++)
        {
        Particle.Add(X, Y, 1);
        }
        int probability = Random.Range(1, 5);
        if(probability < 2)spd += 1;
        else if(probability > 4 )spd -= 1;
        if(spd < 1)spd = 7;
        else if(spd > 15)spd = 7;
        dir = Random.Range(0, 359);
        
        SetVelocity(dir, spd);
    }

}