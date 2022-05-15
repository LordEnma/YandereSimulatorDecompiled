using System;
using UnityEngine;

// Token: 0x020002E0 RID: 736
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014F5 RID: 5365 RVA: 0x000D01C4 File Offset: 0x000CE3C4
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

	// Token: 0x04002131 RID: 8497
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04002132 RID: 8498
	public float[] TargetWeight;

	// Token: 0x04002133 RID: 8499
	public float[] Weight;

	// Token: 0x04002134 RID: 8500
	public float Strength = 100f;

	// Token: 0x04002135 RID: 8501
	public int ID;
}
