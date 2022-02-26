using System;
using UnityEngine;

// Token: 0x02000401 RID: 1025
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C19 RID: 7193 RVA: 0x001475EC File Offset: 0x001457EC
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C1A RID: 7194 RVA: 0x00147614 File Offset: 0x00145814
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x0400315C RID: 12636
	public Vector3 posePosition;

	// Token: 0x0400315D RID: 12637
	public Vector3 poseRotation;

	// Token: 0x0400315E RID: 12638
	public Vector3 poseScale;
}
