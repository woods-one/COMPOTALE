using UnityEngine;
using System.Collections;

/// �p�[�e�B�N��
public class Particle : Token
{

    static GameObject _prefab = null;
    /// �p�[�e�B�N���̐���
    public static Particle Add(float x, float y)
    {
        // �v���n�u���擾
        _prefab = GetPrefab(_prefab, "Particle");
        // �v���n�u����C���X�^���X�𐶐�
        return CreateInstance2<Particle>(_prefab, x, y);
    }
    /// �J�n�B�R���[�`���ŏ������s��
    IEnumerator Start()
    {
        // �ړ������Ƒ����������_���Ɍ��߂�
        float dir = Random.Range(0, 359);
        float spd = Random.Range(10.0f, 20.0f);
        SetVelocity(dir, spd);

        // �����Ȃ��Ȃ�܂ŏ���������
        while (ScaleX > 0.01f)
        {
            // 0.01�b�Q�[�����[�v�ɐ����Ԃ�
            yield return new WaitForSeconds(0.01f);
            // ���񂾂񏬂�������
            MulScale(0.9f);
            // ���񂾂񌸑�����
            MulVelocity(0.9f);
        }

        // ����
        DestroyObj();
    }
}