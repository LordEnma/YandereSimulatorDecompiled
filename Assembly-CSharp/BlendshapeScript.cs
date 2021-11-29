using System;
using UnityEngine;

// Token: 0x020000E5 RID: 229
public class BlendshapeScript : MonoBehaviour
{
	// Token: 0x06000A2D RID: 2605 RVA: 0x0005A2D8 File Offset: 0x000584D8
	private void LateUpdate()
	{
		this.Happiness += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(8, 100f);
	}

	// Token: 0x04000B80 RID: 2944
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04000B81 RID: 2945
	public float Happiness;

	// Token: 0x04000B82 RID: 2946
	public float Blink;
}
