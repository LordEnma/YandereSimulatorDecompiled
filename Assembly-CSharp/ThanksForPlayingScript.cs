using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000478 RID: 1144
public class ThanksForPlayingScript : MonoBehaviour
{
	// Token: 0x06001EE7 RID: 7911 RVA: 0x001B47A8 File Offset: 0x001B29A8
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

	// Token: 0x06001EE8 RID: 7912 RVA: 0x001B4884 File Offset: 0x001B2A84
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
			}
			if (!this.Hearts[1].isPlaying)
			{
				this.Hearts[1].Play();
				this.Hearts[2].Play();
				return;
			}
		}
		else
		{
			this.CrowdfundPanel.alpha = Mathf.MoveTowards(this.CrowdfundPanel.alpha, 0f, Time.deltaTime * 0.5f);
			this.Hearts[1].Stop();
			this.Hearts[2].Stop();
		}
	}

	// Token: 0x04004018 RID: 16408
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004019 RID: 16409
	public ParticleSystem[] Hearts;

	// Token: 0x0400401A RID: 16410
	public UIPanel ThankYouPanel;

	// Token: 0x0400401B RID: 16411
	public UIPanel FinalGamePanel;

	// Token: 0x0400401C RID: 16412
	public UIPanel RivalPanel;

	// Token: 0x0400401D RID: 16413
	public UIPanel QualityPanel;

	// Token: 0x0400401E RID: 16414
	public UIPanel WeaponsPanel;

	// Token: 0x0400401F RID: 16415
	public UIPanel StoryPanel;

	// Token: 0x04004020 RID: 16416
	public UIPanel MorePanel;

	// Token: 0x04004021 RID: 16417
	public UIPanel CrowdfundPanel;

	// Token: 0x04004022 RID: 16418
	public UIPanel SkipPanel;

	// Token: 0x04004023 RID: 16419
	public AudioSource Jukebox;

	// Token: 0x04004024 RID: 16420
	public Transform Yandere;

	// Token: 0x04004025 RID: 16421
	public UISprite SkipCircle;

	// Token: 0x04004026 RID: 16422
	public UISprite Darkness;

	// Token: 0x04004027 RID: 16423
	public Animation YandereKun;

	// Token: 0x04004028 RID: 16424
	public Animation Ryoba;

	// Token: 0x04004029 RID: 16425
	public bool FadeOut;

	// Token: 0x0400402A RID: 16426
	public float Alpha;
}
