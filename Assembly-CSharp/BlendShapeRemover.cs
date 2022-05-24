using System;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class BlendShapeRemover : MonoBehaviour
{
	// Token: 0x06000A30 RID: 2608 RVA: 0x0005AA4B File Offset: 0x00058C4B
	private void Awake()
	{
		if (!SystemInfo.supportsComputeShaders)
		{
			this.SelectedMesh.sharedMesh.ClearBlendShapes();
		}
	}

	// Token: 0x04000B93 RID: 2963
	public SkinnedMeshRenderer SelectedMesh;
}
