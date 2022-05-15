using System;
using UnityEngine;

// Token: 0x02000408 RID: 1032
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C49 RID: 7241 RVA: 0x0014B038 File Offset: 0x00149238
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C4A RID: 7242 RVA: 0x0014B060 File Offset: 0x00149260
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x040031F1 RID: 12785
	public Vector3 posePosition;

	// Token: 0x040031F2 RID: 12786
	public Vector3 poseRotation;

	// Token: 0x040031F3 RID: 12787
	public Vector3 poseScale;
}
