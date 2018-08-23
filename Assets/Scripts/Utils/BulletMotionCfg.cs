using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BulletMotionCfg", menuName = "Unity_Danmaku_Coop/BulletMotionCfg", order = 0)]
public class BulletMotionCfg : ScriptableObject 
{
	[Header("总共生成的子弹组个数。设置好个数后，其下包括子弹细节设置")]
	public BDetail[] TotalSpawn;
	[Header("是否重复以上子弹生成过程")]
	public bool RepeatProcedure;
	
	[System.Serializable]
	public class BDetail
	{
		[Header("子弹的外观")]
		public GameObject Appearence;
		[Header("单次生成的子弹个数。设置完后，其下包括每个子弹的旋转细节设置")]
		public Vector3[] Rotation;
		[Header("单次生成子弹时的生成位置。可以为空，并手动指定生成位置为敌机位置")]
		public List<Vector3> SpawnPoint;
		[Header("单次生成子弹的运动信息细节")]
		public BMotion Motion;
		[Header("此次生成子弹和上一次生成子弹的间隔时间")]
		public int StartSpawnTime;
	}

	[System.Serializable]
	public class BMotion
	{
		public AnimationCurve VerVelocity_TimeCurve;
		public AnimationCurve HorVelocity_TimeCurve;
	}
}