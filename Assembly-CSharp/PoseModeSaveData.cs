using System;
using UnityEngine;

// Token: 0x02000400 RID: 1024
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C10 RID: 7184 RVA: 0x00146B74 File Offset: 0x00144D74
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C11 RID: 7185 RVA: 0x00146B9C File Offset: 0x00144D9C
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x0400314C RID: 12620
	public Vector3 posePosition;

	// Token: 0x0400314D RID: 12621
	public Vector3 poseRotation;

	// Token: 0x0400314E RID: 12622
	public Vector3 poseScale;
}
