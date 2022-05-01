using System;
using UnityEngine;

// Token: 0x020000E5 RID: 229
public class BlendShapeRemover : MonoBehaviour
{
	// Token: 0x06000A2E RID: 2606 RVA: 0x0005A7A3 File Offset: 0x000589A3
	private void Awake()
	{
		if (!SystemInfo.supportsComputeShaders)
		{
			this.SelectedMesh.sharedMesh.ClearBlendShapes();
		}
	}

	// Token: 0x04000B8F RID: 2959
	public SkinnedMeshRenderer SelectedMesh;
}
