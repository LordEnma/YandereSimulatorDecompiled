using System;
using UnityEngine;

// Token: 0x020002DF RID: 735
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014ED RID: 5357 RVA: 0x000CF87C File Offset: 0x000CDA7C
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

	// Token: 0x0400211D RID: 8477
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x0400211E RID: 8478
	public float[] TargetWeight;

	// Token: 0x0400211F RID: 8479
	public float[] Weight;

	// Token: 0x04002120 RID: 8480
	public float Strength = 100f;

	// Token: 0x04002121 RID: 8481
	public int ID;
}
