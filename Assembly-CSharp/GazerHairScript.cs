using System;
using UnityEngine;

// Token: 0x020002DE RID: 734
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014E7 RID: 5351 RVA: 0x000CF774 File Offset: 0x000CD974
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

	// Token: 0x0400211B RID: 8475
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x0400211C RID: 8476
	public float[] TargetWeight;

	// Token: 0x0400211D RID: 8477
	public float[] Weight;

	// Token: 0x0400211E RID: 8478
	public float Strength = 100f;

	// Token: 0x0400211F RID: 8479
	public int ID;
}
