using System;
using UnityEngine;

// Token: 0x020002DF RID: 735
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014F3 RID: 5363 RVA: 0x000CFEDC File Offset: 0x000CE0DC
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

	// Token: 0x04002128 RID: 8488
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04002129 RID: 8489
	public float[] TargetWeight;

	// Token: 0x0400212A RID: 8490
	public float[] Weight;

	// Token: 0x0400212B RID: 8491
	public float Strength = 100f;

	// Token: 0x0400212C RID: 8492
	public int ID;
}
