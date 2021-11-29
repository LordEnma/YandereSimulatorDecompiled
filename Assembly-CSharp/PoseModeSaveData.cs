using System;
using UnityEngine;

// Token: 0x020003FB RID: 1019
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001BF3 RID: 7155 RVA: 0x00143A5C File Offset: 0x00141C5C
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001BF4 RID: 7156 RVA: 0x00143A84 File Offset: 0x00141C84
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x04003100 RID: 12544
	public Vector3 posePosition;

	// Token: 0x04003101 RID: 12545
	public Vector3 poseRotation;

	// Token: 0x04003102 RID: 12546
	public Vector3 poseScale;
}
