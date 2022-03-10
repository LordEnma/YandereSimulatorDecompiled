using System;
using UnityEngine;

// Token: 0x020002DD RID: 733
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014E1 RID: 5345 RVA: 0x000CF0D4 File Offset: 0x000CD2D4
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

	// Token: 0x04002106 RID: 8454
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04002107 RID: 8455
	public float[] TargetWeight;

	// Token: 0x04002108 RID: 8456
	public float[] Weight;

	// Token: 0x04002109 RID: 8457
	public float Strength = 100f;

	// Token: 0x0400210A RID: 8458
	public int ID;
}
