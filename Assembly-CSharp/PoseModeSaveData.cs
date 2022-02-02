using System;
using UnityEngine;

// Token: 0x020003FF RID: 1023
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x001465D8 File Offset: 0x001447D8
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C08 RID: 7176 RVA: 0x00146600 File Offset: 0x00144800
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x04003142 RID: 12610
	public Vector3 posePosition;

	// Token: 0x04003143 RID: 12611
	public Vector3 poseRotation;

	// Token: 0x04003144 RID: 12612
	public Vector3 poseScale;
}
