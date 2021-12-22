using System;
using UnityEngine;

// Token: 0x020002DA RID: 730
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014CE RID: 5326 RVA: 0x000CDA0C File Offset: 0x000CBC0C
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

	// Token: 0x040020D6 RID: 8406
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x040020D7 RID: 8407
	public float[] TargetWeight;

	// Token: 0x040020D8 RID: 8408
	public float[] Weight;

	// Token: 0x040020D9 RID: 8409
	public float Strength = 100f;

	// Token: 0x040020DA RID: 8410
	public int ID;
}
