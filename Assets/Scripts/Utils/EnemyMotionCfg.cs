using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "EnemyMotionCfg", menuName = "Unity_Danmaku_Coop/EnemyMotionCfg", order = 0)]
public class EnemyMotionCfg : ScriptableObject 
{
	[Header("曲线类型")]
	public ECurveType CurveType;
	[Header("生成点")]
	public Vector3 SpawnPoint;
	[Header("X轴速度-时间曲线")]
	public AnimationCurve HorVelocity_TimeCurve;
	[Header("Y轴速度-时间曲线")]
	public AnimationCurve VerVelocity_TimeCurve;
	[Header("X轴加速度-时间曲线")]
	public AnimationCurve HorAcceleration_TimeCurve;
	[Header("Y轴加速度-时间曲线")]
	public AnimationCurve VerAcceleration_TimeCurve;
	[Header("注释"), TextArea]
	public string Comment;
}

public enum ECurveType
{
	VT,
	AT
}



