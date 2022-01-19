using System;
using UnityEngine;

// Token: 0x020003FF RID: 1023
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C06 RID: 7174 RVA: 0x00146194 File Offset: 0x00144394
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C07 RID: 7175 RVA: 0x001461BC File Offset: 0x001443BC
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x0400313C RID: 12604
	public Vector3 posePosition;

	// Token: 0x0400313D RID: 12605
	public Vector3 poseRotation;

	// Token: 0x0400313E RID: 12606
	public Vector3 poseScale;
}
