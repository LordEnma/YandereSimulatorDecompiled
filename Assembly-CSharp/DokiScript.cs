using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class DokiScript : MonoBehaviour
{
	// Token: 0x0600138E RID: 5006 RVA: 0x000B70D4 File Offset: 0x000B52D4
	private void Update()
	{
		if (!this.Yandere.Egg)
		{
			if (this.OtherPrompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.enabled = false;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Yandere.PantyAttacher.newRenderer.enabled = false;
				this.Prompt.Circle[0].fillAmount = 1f;
				UnityEngine.Object.Instantiate<GameObject>(this.TransformEffect, this.Yandere.Hips.position, Quaternion.identity);
				this.Yandere.MyRenderer.sharedMesh = this.Yandere.Uniforms[4];
				this.Yandere.MyRenderer.materials[0].mainTexture = this.DokiTexture;
				this.Yandere.MyRenderer.materials[1].mainTexture = this.DokiTexture;
				this.ID++;
				if (this.ID > 4)
				{
					this.ID = 1;
				}
				this.Credits.SongLabel.text = this.DokiName[this.ID] + " from Doki Doki Literature Club";
				this.Credits.BandLabel.text = "by Team Salvato";
				this.Credits.Panel.enabled = true;
				this.Credits.Slide = true;
				this.Credits.Timer = 0f;
				if (this.ID == 1)
				{
					this.Yandere.MyRenderer.materials[0].SetTexture("_OverlayTex", this.DokiSocks[0]);
					this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.DokiSocks[0]);
				}
				else
				{
					this.Yandere.MyRenderer.materials[0].SetTexture("_OverlayTex", this.DokiSocks[1]);
					this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.DokiSocks[1]);
				}
				Debug.Log("Activating shadows on Yandere-chan.");
				this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
				this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
				this.Yandere.MyRenderer.materials[2].mainTexture = this.DokiHair[this.ID];
				this.Yandere.Hairstyle = 136 + this.ID;
				this.Yandere.UpdateHair();
				return;
			}
		}
		else
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x04001CD9 RID: 7385
	public MusicCreditScript Credits;

	// Token: 0x04001CDA RID: 7386
	public YandereScript Yandere;

	// Token: 0x04001CDB RID: 7387
	public PromptScript OtherPrompt;

	// Token: 0x04001CDC RID: 7388
	public PromptScript Prompt;

	// Token: 0x04001CDD RID: 7389
	public GameObject TransformEffect;

	// Token: 0x04001CDE RID: 7390
	public Texture DokiTexture;

	// Token: 0x04001CDF RID: 7391
	public Texture[] DokiSocks;

	// Token: 0x04001CE0 RID: 7392
	public Texture[] DokiHair;

	// Token: 0x04001CE1 RID: 7393
	public string[] DokiName;

	// Token: 0x04001CE2 RID: 7394
	public int ID;
}
