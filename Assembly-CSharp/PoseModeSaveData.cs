using System;
using UnityEngine;

// Token: 0x02000408 RID: 1032
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C4A RID: 7242 RVA: 0x0014B2F4 File Offset: 0x001494F4
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C4B RID: 7243 RVA: 0x0014B31C File Offset: 0x0014951C
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x040031F9 RID: 12793
	public Vector3 posePosition;

	// Token: 0x040031FA RID: 12794
	public Vector3 poseRotation;

	// Token: 0x040031FB RID: 12795
	public Vector3 poseScale;
}
