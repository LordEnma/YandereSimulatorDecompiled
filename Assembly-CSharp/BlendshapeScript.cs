using System;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class BlendshapeScript : MonoBehaviour
{
	// Token: 0x06000A30 RID: 2608 RVA: 0x0005A5AC File Offset: 0x000587AC
	private void LateUpdate()
	{
		this.Happiness += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(8, 100f);
	}

	// Token: 0x04000B8D RID: 2957
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04000B8E RID: 2958
	public float Happiness;

	// Token: 0x04000B8F RID: 2959
	public float Blink;
}
