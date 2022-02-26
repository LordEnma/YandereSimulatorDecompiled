using System;
using UnityEngine;

// Token: 0x02000243 RID: 579
public class ChemistScannerScript : MonoBehaviour
{
	// Token: 0x06001249 RID: 4681 RVA: 0x0008C6B4 File Offset: 0x0008A8B4
	private void Update()
	{
		if (this.Student.Ragdoll != null && this.Student.Ragdoll.enabled)
		{
			this.MyRenderer.materials[1].mainTexture = this.DeadEyes;
			base.enabled = false;
			return;
		}
		if (this.Student.Dying)
		{
			if (this.MyRenderer.materials[1].mainTexture != this.AlarmedEyes)
			{
				this.MyRenderer.materials[1].mainTexture = this.AlarmedEyes;
				return;
			}
		}
		else if (this.Student.Emetic || this.Student.Lethal || this.Student.Tranquil || this.Student.Headache)
		{
			if (this.MyRenderer.materials[1].mainTexture != this.Textures[6])
			{
				this.MyRenderer.materials[1].mainTexture = this.Textures[6];
				return;
			}
		}
		else if (this.Student.Grudge)
		{
			if (this.MyRenderer.materials[1].mainTexture != this.Textures[1])
			{
				this.MyRenderer.materials[1].mainTexture = this.Textures[1];
				return;
			}
		}
		else if (this.Student.LostTeacherTrust)
		{
			if (this.MyRenderer.materials[1].mainTexture != this.SadEyes)
			{
				this.MyRenderer.materials[1].mainTexture = this.SadEyes;
				return;
			}
		}
		else if (this.Student.WitnessedMurder || this.Student.WitnessedCorpse)
		{
			if (this.MyRenderer.materials[1].mainTexture != this.AlarmedEyes)
			{
				this.MyRenderer.materials[1].mainTexture = this.AlarmedEyes;
				return;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 2f)
			{
				while (this.ID == this.PreviousID)
				{
					this.ID = UnityEngine.Random.Range(0, this.Textures.Length);
				}
				this.MyRenderer.materials[1].mainTexture = this.Textures[this.ID];
				this.PreviousID = this.ID;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x0400170E RID: 5902
	public StudentScript Student;

	// Token: 0x0400170F RID: 5903
	public Renderer MyRenderer;

	// Token: 0x04001710 RID: 5904
	public Texture AlarmedEyes;

	// Token: 0x04001711 RID: 5905
	public Texture DeadEyes;

	// Token: 0x04001712 RID: 5906
	public Texture SadEyes;

	// Token: 0x04001713 RID: 5907
	public Texture[] Textures;

	// Token: 0x04001714 RID: 5908
	public float Timer;

	// Token: 0x04001715 RID: 5909
	public int PreviousID;

	// Token: 0x04001716 RID: 5910
	public int ID;
}
