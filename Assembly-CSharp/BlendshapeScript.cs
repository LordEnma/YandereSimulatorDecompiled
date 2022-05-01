using System;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class BlendshapeScript : MonoBehaviour
{
	// Token: 0x06000A30 RID: 2608 RVA: 0x0005A7C4 File Offset: 0x000589C4
	private void LateUpdate()
	{
		this.Happiness += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(8, 100f);
	}

	// Token: 0x04000B90 RID: 2960
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04000B91 RID: 2961
	public float Happiness;

	// Token: 0x04000B92 RID: 2962
	public float Blink;
}
