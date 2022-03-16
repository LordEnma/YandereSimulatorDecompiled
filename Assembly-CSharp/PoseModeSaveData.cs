using System;
using UnityEngine;

// Token: 0x02000402 RID: 1026
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C28 RID: 7208 RVA: 0x001489CC File Offset: 0x00146BCC
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C29 RID: 7209 RVA: 0x001489F4 File Offset: 0x00146BF4
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x040031A6 RID: 12710
	public Vector3 posePosition;

	// Token: 0x040031A7 RID: 12711
	public Vector3 poseRotation;

	// Token: 0x040031A8 RID: 12712
	public Vector3 poseScale;
}
