using System;
using UnityEngine;

// Token: 0x02000242 RID: 578
public class ChemistScannerScript : MonoBehaviour
{
	// Token: 0x06001245 RID: 4677 RVA: 0x0008C258 File Offset: 0x0008A458
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

	// Token: 0x04001706 RID: 5894
	public StudentScript Student;

	// Token: 0x04001707 RID: 5895
	public Renderer MyRenderer;

	// Token: 0x04001708 RID: 5896
	public Texture AlarmedEyes;

	// Token: 0x04001709 RID: 5897
	public Texture DeadEyes;

	// Token: 0x0400170A RID: 5898
	public Texture SadEyes;

	// Token: 0x0400170B RID: 5899
	public Texture[] Textures;

	// Token: 0x0400170C RID: 5900
	public float Timer;

	// Token: 0x0400170D RID: 5901
	public int PreviousID;

	// Token: 0x0400170E RID: 5902
	public int ID;
}
