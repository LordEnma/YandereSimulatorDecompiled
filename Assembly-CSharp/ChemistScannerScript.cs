using System;
using UnityEngine;

// Token: 0x02000243 RID: 579
public class ChemistScannerScript : MonoBehaviour
{
	// Token: 0x0600124B RID: 4683 RVA: 0x0008CC60 File Offset: 0x0008AE60
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

	// Token: 0x0400171E RID: 5918
	public StudentScript Student;

	// Token: 0x0400171F RID: 5919
	public Renderer MyRenderer;

	// Token: 0x04001720 RID: 5920
	public Texture AlarmedEyes;

	// Token: 0x04001721 RID: 5921
	public Texture DeadEyes;

	// Token: 0x04001722 RID: 5922
	public Texture SadEyes;

	// Token: 0x04001723 RID: 5923
	public Texture[] Textures;

	// Token: 0x04001724 RID: 5924
	public float Timer;

	// Token: 0x04001725 RID: 5925
	public int PreviousID;

	// Token: 0x04001726 RID: 5926
	public int ID;
}
