using System;
using UnityEngine;

// Token: 0x020000E5 RID: 229
public class BlendShapeRemover : MonoBehaviour
{
	// Token: 0x06000A2E RID: 2606 RVA: 0x0005A44F File Offset: 0x0005864F
	private void Awake()
	{
		if (!SystemInfo.supportsComputeShaders)
		{
			this.SelectedMesh.sharedMesh.ClearBlendShapes();
		}
	}

	// Token: 0x04000B82 RID: 2946
	public SkinnedMeshRenderer SelectedMesh;
}
