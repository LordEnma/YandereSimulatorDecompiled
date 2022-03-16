using System;
using UnityEngine;

// Token: 0x020002DD RID: 733
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014E4 RID: 5348 RVA: 0x000CF544 File Offset: 0x000CD744
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

	// Token: 0x04002116 RID: 8470
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04002117 RID: 8471
	public float[] TargetWeight;

	// Token: 0x04002118 RID: 8472
	public float[] Weight;

	// Token: 0x04002119 RID: 8473
	public float Strength = 100f;

	// Token: 0x0400211A RID: 8474
	public int ID;
}
