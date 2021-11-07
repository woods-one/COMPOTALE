using System.Collections;
using System.Collections.Generic;

public static class DirectionUtility
{
    /// <summary>
    /// �ی��̎��
    /// </summary>
    public enum QuadrantType
    {
        /// <summary>���ی�</summary>
        First = 1,
        /// <summary>���ی�</summary>
        Second,
        /// <summary>��O�ی�</summary>
        Third,
        /// <summary>��l�ی�</summary>
        Fourth
    }

    /// <summary>
    /// �e�ی��̊p�x�͈̔�
    /// </summary>
    private static readonly Dictionary<QuadrantType, DirectionRange> DirectionRangePetterns = new Dictionary<QuadrantType, DirectionRange>() {
        { QuadrantType.First, new DirectionRange(0, 89) },
        { QuadrantType.Second, new DirectionRange(90, 179) },
        { QuadrantType.Third, new DirectionRange(180, 269) },
        { QuadrantType.Fourth, new DirectionRange(270, 359) },
    };

    /// <summary>
    /// �����͈̔�
    /// </summary>
    public class DirectionRange
    {
        public float directionStart
        {
            get;
        }
        public float directionEnd
        {
            get;
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public DirectionRange(float directionStart, float directionEnd)
        {
            this.directionStart = directionStart;
            this.directionEnd = directionEnd;
        }
    }

    /// <summary>
    /// �����͈̔͂��擾
    /// </summary>
    public static DirectionRange GetDirectionRange(QuadrantType quadrantType)
    {
        return DirectionRangePetterns[quadrantType];
    }


    /// <summary>
    /// �ی��̔ԍ�����ی��̃^�C�v��ϊ��i1�n�܂�j
    /// </summary>
    /// <param name="quadrantNum">�扽�ی��i1�`4�j</param>
    public static QuadrantType ConvertIntToQuadrantType (int quadrantNum)
    {
        // TODO:�����`�F�b�N������Ƃ����S�ł�

        QuadrantType type = (QuadrantType)System.Enum.ToObject(typeof(QuadrantType), quadrantNum);
        return type;
    }
}
