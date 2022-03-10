using System;
using UnityEngine;

// Token: 0x02000401 RID: 1025
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C1B RID: 7195 RVA: 0x00147B28 File Offset: 0x00145D28
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C1C RID: 7196 RVA: 0x00147B50 File Offset: 0x00145D50
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x04003172 RID: 12658
	public Vector3 posePosition;

	// Token: 0x04003173 RID: 12659
	public Vector3 poseRotation;

	// Token: 0x04003174 RID: 12660
	public Vector3 poseScale;
}
