using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200046C RID: 1132
public class ThanksForPlayingScript : MonoBehaviour
{
	// Token: 0x06001E90 RID: 7824 RVA: 0x001AC1AC File Offset: 0x001AA3AC
	private void Start()
	{
		this.Ryoba["f02_faceCouncilGrace_00"].layer = 1;
		this.Ryoba.Play("f02_faceCouncilGrace_00");
		this.YandereKun["AltYanKunFace"].layer = 1;
		this.YandereKun.Play("AltYanKunFace");
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.SkipPanel.alpha = 0f;
		this.Alpha = 1f;
		this.CameraEffects.UpdateDOF(2f);
		this.CameraEffects.UpdateBloom(1f);
		this.CameraEffects.UpdateBloomKnee(0.5f);
		this.CameraEffects.UpdateBloomRadius(4f);
	}

	// Token: 0x06001E91 RID: 7825 RVA: 0x001AC288 File Offset: 0x001AA488
	private void Update()
	{
		if (!this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.5f);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f)
			{
				this.SkipPanel.alpha += Time.deltaTime;
			}
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
			this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
			this.Jukebox.volume -= Time.deltaTime * 0.5f;
			if (this.Alpha == 1f)
			{
				SceneManager.LoadScene("NewTitleScene");
			}
		}
		if (this.SkipPanel.alpha == 1f)
		{
			if (Input.GetButton("X"))
			{
				this.SkipCircle.fillAmount -= Time.deltaTime;
				if (this.SkipCircle.fillAmount == 0f)
				{
					this.FadeOut = true;
				}
			}
			else
			{
				this.SkipCircle.fillAmount = 1f;
			}
		}
		if (Input.GetKeyDown("=") && Time.timeScale < 10f)
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("-") && Time.timeScale > 1f)
		{
			Time.timeScale -= 1f;
		}
		if (this.Yandere.position.z > 1f && this.Yandere.position.z < 10f)
		{
			this.ThankYouPanel.alpha = Mathf.MoveTowards(this.ThankYouPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			this.ThankYouPanel.alpha = Mathf.MoveTowards(this.ThankYouPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (this.Yandere.position.z > 20f && this.Yandere.position.z < 120f)
		{
			this.FinalGamePanel.alpha = Mathf.MoveTowards(this.FinalGamePanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			this.FinalGamePanel.alpha = Mathf.MoveTowards(this.FinalGamePanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (this.Yandere.position.z > 30f && this.Yandere.position.z < 40f)
		{
			this.RivalPanel.alpha = Mathf.MoveTowards(this.RivalPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			this.RivalPanel.alpha = Mathf.MoveTowards(this.RivalPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (this.Yandere.position.z > 50f && this.Yandere.position.z < 60f)
		{
			this.QualityPanel.alpha = Mathf.MoveTowards(this.QualityPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			this.QualityPanel.alpha = Mathf.MoveTowards(this.QualityPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (this.Yandere.position.z > 70f && this.Yandere.position.z < 80f)
		{
			this.WeaponsPanel.alpha = Mathf.MoveTowards(this.WeaponsPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			this.WeaponsPanel.alpha = Mathf.MoveTowards(this.WeaponsPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (this.Yandere.position.z > 90f && this.Yandere.position.z < 100f)
		{
			this.StoryPanel.alpha = Mathf.MoveTowards(this.StoryPanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			this.StoryPanel.alpha = Mathf.MoveTowards(this.StoryPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (this.Yandere.position.z > 110f && this.Yandere.position.z < 120f)
		{
			this.MorePanel.alpha = Mathf.MoveTowards(this.MorePanel.alpha, 1f, Time.deltaTime * 0.5f);
		}
		else
		{
			this.MorePanel.alpha = Mathf.MoveTowards(this.MorePanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
		if (this.Yandere.position.z > 130f && this.Yandere.position.z < 140f)
		{
			this.CrowdfundPanel.alpha = Mathf.MoveTowards(this.CrowdfundPanel.alpha, 1f, Time.deltaTime * 0.5f);
			if (Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				return;
			}
		}
		else
		{
			this.CrowdfundPanel.alpha = Mathf.MoveTowards(this.CrowdfundPanel.alpha, 0f, Time.deltaTime * 0.5f);
		}
	}

	// Token: 0x04003F1D RID: 16157
	public CameraEffectsScript CameraEffects;

	// Token: 0x04003F1E RID: 16158
	public UIPanel ThankYouPanel;

	// Token: 0x04003F1F RID: 16159
	public UIPanel FinalGamePanel;

	// Token: 0x04003F20 RID: 16160
	public UIPanel RivalPanel;

	// Token: 0x04003F21 RID: 16161
	public UIPanel QualityPanel;

	// Token: 0x04003F22 RID: 16162
	public UIPanel WeaponsPanel;

	// Token: 0x04003F23 RID: 16163
	public UIPanel StoryPanel;

	// Token: 0x04003F24 RID: 16164
	public UIPanel MorePanel;

	// Token: 0x04003F25 RID: 16165
	public UIPanel CrowdfundPanel;

	// Token: 0x04003F26 RID: 16166
	public UIPanel SkipPanel;

	// Token: 0x04003F27 RID: 16167
	public AudioSource Jukebox;

	// Token: 0x04003F28 RID: 16168
	public Transform Yandere;

	// Token: 0x04003F29 RID: 16169
	public UISprite SkipCircle;

	// Token: 0x04003F2A RID: 16170
	public UISprite Darkness;

	// Token: 0x04003F2B RID: 16171
	public Animation YandereKun;

	// Token: 0x04003F2C RID: 16172
	public Animation Ryoba;

	// Token: 0x04003F2D RID: 16173
	public bool FadeOut;

	// Token: 0x04003F2E RID: 16174
	public float Alpha;
}
