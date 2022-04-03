using System;
using UnityEngine;

// Token: 0x02000405 RID: 1029
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C32 RID: 7218 RVA: 0x00149488 File Offset: 0x00147688
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C33 RID: 7219 RVA: 0x001494B0 File Offset: 0x001476B0
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x040031BF RID: 12735
	public Vector3 posePosition;

	// Token: 0x040031C0 RID: 12736
	public Vector3 poseRotation;

	// Token: 0x040031C1 RID: 12737
	public Vector3 poseScale;
}
