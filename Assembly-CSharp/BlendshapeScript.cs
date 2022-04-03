using System;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class BlendshapeScript : MonoBehaviour
{
	// Token: 0x06000A30 RID: 2608 RVA: 0x0005A5B8 File Offset: 0x000587B8
	private void LateUpdate()
	{
		this.Happiness += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(8, 100f);
	}

	// Token: 0x04000B8E RID: 2958
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04000B8F RID: 2959
	public float Happiness;

	// Token: 0x04000B90 RID: 2960
	public float Blink;
}
