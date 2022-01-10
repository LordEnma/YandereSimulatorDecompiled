using System;
using UnityEngine;

// Token: 0x020003FE RID: 1022
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C04 RID: 7172 RVA: 0x00144A8C File Offset: 0x00142C8C
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C05 RID: 7173 RVA: 0x00144AB4 File Offset: 0x00142CB4
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x04003137 RID: 12599
	public Vector3 posePosition;

	// Token: 0x04003138 RID: 12600
	public Vector3 poseRotation;

	// Token: 0x04003139 RID: 12601
	public Vector3 poseScale;
}
