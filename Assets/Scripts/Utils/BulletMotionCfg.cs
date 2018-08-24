using UnityEngine;

[CreateAssetMenu(fileName = "BulletMotionCfg", menuName = "Unity_Danmaku_Coop/BulletMotionCfg", order = 0)]
public class BulletMotionCfg : ScriptableObject 
{
	public AnimationCurve HorVelocityTimeCurve;
	public AnimationCurve VerVelocityTimeCurve;
}