using System;
using UnityEngine;

// Token: 0x02000287 RID: 647
public class DokiScript : MonoBehaviour
{
	// Token: 0x06001395 RID: 5013 RVA: 0x000B7670 File Offset: 0x000B5870
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

	// Token: 0x04001CF9 RID: 7417
	public MusicCreditScript Credits;

	// Token: 0x04001CFA RID: 7418
	public YandereScript Yandere;

	// Token: 0x04001CFB RID: 7419
	public PromptScript OtherPrompt;

	// Token: 0x04001CFC RID: 7420
	public PromptScript Prompt;

	// Token: 0x04001CFD RID: 7421
	public GameObject TransformEffect;

	// Token: 0x04001CFE RID: 7422
	public Texture DokiTexture;

	// Token: 0x04001CFF RID: 7423
	public Texture[] DokiSocks;

	// Token: 0x04001D00 RID: 7424
	public Texture[] DokiHair;

	// Token: 0x04001D01 RID: 7425
	public string[] DokiName;

	// Token: 0x04001D02 RID: 7426
	public int ID;
}
