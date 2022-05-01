using System;
using UnityEngine;

// Token: 0x02000407 RID: 1031
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C43 RID: 7235 RVA: 0x0014A3B8 File Offset: 0x001485B8
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C44 RID: 7236 RVA: 0x0014A3E0 File Offset: 0x001485E0
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x040031DC RID: 12764
	public Vector3 posePosition;

	// Token: 0x040031DD RID: 12765
	public Vector3 poseRotation;

	// Token: 0x040031DE RID: 12766
	public Vector3 poseScale;
}
