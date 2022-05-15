using System;
using UnityEngine;

// Token: 0x020000E7 RID: 231
public class BlendshapeScript : MonoBehaviour
{
	// Token: 0x06000A32 RID: 2610 RVA: 0x0005AA44 File Offset: 0x00058C44
	private void LateUpdate()
	{
		this.Happiness += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(8, 100f);
	}

	// Token: 0x04000B94 RID: 2964
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04000B95 RID: 2965
	public float Happiness;

	// Token: 0x04000B96 RID: 2966
	public float Blink;
}
