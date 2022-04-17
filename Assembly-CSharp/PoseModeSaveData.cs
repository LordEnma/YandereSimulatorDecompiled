using System;
using UnityEngine;

// Token: 0x02000406 RID: 1030
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C3C RID: 7228 RVA: 0x00149B7C File Offset: 0x00147D7C
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C3D RID: 7229 RVA: 0x00149BA4 File Offset: 0x00147DA4
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x040031CD RID: 12749
	public Vector3 posePosition;

	// Token: 0x040031CE RID: 12750
	public Vector3 poseRotation;

	// Token: 0x040031CF RID: 12751
	public Vector3 poseScale;
}
