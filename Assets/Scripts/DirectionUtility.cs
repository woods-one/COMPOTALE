using System.Collections;
using System.Collections.Generic;

public static class DirectionUtility
{
    /// <summary>
    /// 象限の種別
    /// </summary>
    public enum QuadrantType
    {
        /// <summary>第一象限</summary>
        First = 1,
        /// <summary>第二象限</summary>
        Second,
        /// <summary>第三象限</summary>
        Third,
        /// <summary>第四象限</summary>
        Fourth
    }

    /// <summary>
    /// 各象限の角度の範囲
    /// </summary>
    private static readonly Dictionary<QuadrantType, DirectionRange> DirectionRangePetterns = new Dictionary<QuadrantType, DirectionRange>() {
        { QuadrantType.First, new DirectionRange(0, 89) },
        { QuadrantType.Second, new DirectionRange(90, 179) },
        { QuadrantType.Third, new DirectionRange(180, 269) },
        { QuadrantType.Fourth, new DirectionRange(270, 359) },
    };

    /// <summary>
    /// 方向の範囲
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
        /// コンストラクタ
        /// </summary>
        public DirectionRange(float directionStart, float directionEnd)
        {
            this.directionStart = directionStart;
            this.directionEnd = directionEnd;
        }
    }

    /// <summary>
    /// 方向の範囲を取得
    /// </summary>
    public static DirectionRange GetDirectionRange(QuadrantType quadrantType)
    {
        return DirectionRangePetterns[quadrantType];
    }


    /// <summary>
    /// 象限の番号から象限のタイプを変換（1始まり）
    /// </summary>
    /// <param name="quadrantNum">第何象限（1～4）</param>
    public static QuadrantType ConvertIntToQuadrantType (int quadrantNum)
    {
        // TODO:引数チェックを入れるとより安全です

        QuadrantType type = (QuadrantType)System.Enum.ToObject(typeof(QuadrantType), quadrantNum);
        return type;
    }
}