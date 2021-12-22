using System;
using UnityEngine;

// Token: 0x020003FC RID: 1020
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001BFB RID: 7163 RVA: 0x0014431C File Offset: 0x0014251C
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001BFC RID: 7164 RVA: 0x00144344 File Offset: 0x00142544
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x0400312A RID: 12586
	public Vector3 posePosition;

	// Token: 0x0400312B RID: 12587
	public Vector3 poseRotation;

	// Token: 0x0400312C RID: 12588
	public Vector3 poseScale;
}
