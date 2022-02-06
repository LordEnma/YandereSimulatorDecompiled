using System;
using UnityEngine;

// Token: 0x020003FF RID: 1023
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C09 RID: 7177 RVA: 0x00146874 File Offset: 0x00144A74
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C0A RID: 7178 RVA: 0x0014689C File Offset: 0x00144A9C
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x04003146 RID: 12614
	public Vector3 posePosition;

	// Token: 0x04003147 RID: 12615
	public Vector3 poseRotation;

	// Token: 0x04003148 RID: 12616
	public Vector3 poseScale;
}
