using System;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014D8 RID: 5336 RVA: 0x000CE674 File Offset: 0x000CC874
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

	// Token: 0x040020ED RID: 8429
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x040020EE RID: 8430
	public float[] TargetWeight;

	// Token: 0x040020EF RID: 8431
	public float[] Weight;

	// Token: 0x040020F0 RID: 8432
	public float Strength = 100f;

	// Token: 0x040020F1 RID: 8433
	public int ID;
}
