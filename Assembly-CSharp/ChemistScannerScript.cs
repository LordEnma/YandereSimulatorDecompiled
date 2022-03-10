using System;
using UnityEngine;

// Token: 0x02000243 RID: 579
public class ChemistScannerScript : MonoBehaviour
{
	// Token: 0x06001249 RID: 4681 RVA: 0x0008C7FC File Offset: 0x0008A9FC
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

	// Token: 0x04001717 RID: 5911
	public StudentScript Student;

	// Token: 0x04001718 RID: 5912
	public Renderer MyRenderer;

	// Token: 0x04001719 RID: 5913
	public Texture AlarmedEyes;

	// Token: 0x0400171A RID: 5914
	public Texture DeadEyes;

	// Token: 0x0400171B RID: 5915
	public Texture SadEyes;

	// Token: 0x0400171C RID: 5916
	public Texture[] Textures;

	// Token: 0x0400171D RID: 5917
	public float Timer;

	// Token: 0x0400171E RID: 5918
	public int PreviousID;

	// Token: 0x0400171F RID: 5919
	public int ID;
}
