using System;
using UnityEngine;

// Token: 0x020000E4 RID: 228
public class BlendShapeRemover : MonoBehaviour
{
	// Token: 0x06000A2B RID: 2603 RVA: 0x0005A2B7 File Offset: 0x000584B7
	private void Awake()
	{
		if (!SystemInfo.supportsComputeShaders)
		{
			this.SelectedMesh.sharedMesh.ClearBlendShapes();
		}
	}

	// Token: 0x04000B7F RID: 2943
	public SkinnedMeshRenderer SelectedMesh;
}
