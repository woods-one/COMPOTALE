using UnityEngine;
using System.Collections;

/// �G
public class Enemy : Token
{
    public static int Count;
    public static int Count2 = 0;
    public AudioClip sound1;
    AudioSource audioSource;
    bool flag = true;
    public float spd;
    public float dir;
    /// �J�n
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if (Enemy.Count == Enemy.Count2 && flag!)
        {
            audioSource.PlayOneShot(sound1);
            flag = false;
            Enemy.Count2++;
        }
        else if (Enemy.Count == Enemy.Count2 && !flag)
        {
            audioSource.PlayOneShot(sound1);
            flag = true;
            Enemy.Count2++;
        }
    }
    public void OnMouseDown()
    {

        // �p�[�e�B�N���𐶐�
        Count++;
        for (int i = 0; i < 32; i++)
        {
        Particle.Add(X, Y, 1);
        int probability = Random.Range(1, 5);
        if(probability < 2)spd += 2;
        else if(probability > 4 )spd -= 1;
        if(spd < 1)spd = 1;
        else if(spd > 15)spd = 15;
        dir = Random.Range(0, 359);
        SetVelocity(dir, spd);
        Debug.Log(Count - 1);
        }
    }

}