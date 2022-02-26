using System;
using UnityEngine;

// Token: 0x020002DD RID: 733
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014E1 RID: 5345 RVA: 0x000CEF58 File Offset: 0x000CD158
	private void Update()
	{
		this.ID = 0;
		while (this.ID < this.Weight.Length)
		{
			this.Weight[this.ID] = Mathf.MoveTowards(this.Weight[this.ID], this.TargetWeight[this.ID], Time.deltaTime * this.Strength);
			if (this.Weight[this.ID] == this.TargetWeight[this.ID])
			{
				this.TargetWeight[this.ID] = UnityEngine.Random.Range(0f, 100f);
			}
			this.MyMesh.SetBlendShapeWeight(this.ID, this.Weight[this.ID]);
			this.ID++;
		}
	}

	// Token: 0x040020FC RID: 8444
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x040020FD RID: 8445
	public float[] TargetWeight;

	// Token: 0x040020FE RID: 8446
	public float[] Weight;

	// Token: 0x040020FF RID: 8447
	public float Strength = 100f;

	// Token: 0x04002100 RID: 8448
	public int ID;
}
