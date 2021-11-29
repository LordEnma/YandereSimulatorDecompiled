using System;
using UnityEngine;

// Token: 0x020002D9 RID: 729
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014C7 RID: 5319 RVA: 0x000CD268 File Offset: 0x000CB468
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

	// Token: 0x040020B6 RID: 8374
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x040020B7 RID: 8375
	public float[] TargetWeight;

	// Token: 0x040020B8 RID: 8376
	public float[] Weight;

	// Token: 0x040020B9 RID: 8377
	public float Strength = 100f;

	// Token: 0x040020BA RID: 8378
	public int ID;
}
