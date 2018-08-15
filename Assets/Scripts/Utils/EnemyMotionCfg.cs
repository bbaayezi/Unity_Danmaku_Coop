using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "EnemyMotionCfg", menuName = "Unity_Danmaku_Coop/EnemyMotionCfg", order = 0)]
public class EnemyMotionCfg : ScriptableObject 
{
	[ContextMenuItem("Generate Clips", "GenerateClips"), Range(1, 10),
	Header("便捷创建动作片段：输入片段数量并右键点击Generate Clips")]
	public int MotionClips = 1;
	public MotionConfig[] Configs;

	void GenerateClips()
	{
		Configs = new MotionConfig[MotionClips];
	}
}
[System.Serializable]
public class MotionConfig
{
	[Header("参考标准速度：0.6")]
	public Vector2 Speed;
	[Header("衰减速度（加速度）每秒衰减一次")]
	public Vector2 FadeSpeed;
	[Header("速度衰减限制（达到限制后速度不再衰减）")]
	public Vector2 LimitFadeSpeed;
	[Header("此动作片段与下一个动作片段的间隔时间")]
	public int OffsetTime;
}
