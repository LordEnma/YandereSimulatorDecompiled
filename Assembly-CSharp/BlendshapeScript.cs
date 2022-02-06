using System;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class BlendshapeScript : MonoBehaviour
{
	// Token: 0x06000A30 RID: 2608 RVA: 0x0005A470 File Offset: 0x00058670
	private void LateUpdate()
	{
		this.Happiness += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(8, 100f);
	}

	// Token: 0x04000B84 RID: 2948
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04000B85 RID: 2949
	public float Happiness;

	// Token: 0x04000B86 RID: 2950
	public float Blink;
}
