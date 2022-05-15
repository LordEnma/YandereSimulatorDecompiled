using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000479 RID: 1145
public class ThanksForPlayingScript : MonoBehaviour
{
	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B5A1C File Offset: 0x001B3C1C
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

	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B5AF8 File Offset: 0x001B3CF8
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

	// Token: 0x04004036 RID: 16438
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004037 RID: 16439
	public ParticleSystem[] Hearts;

	// Token: 0x04004038 RID: 16440
	public UIPanel ThankYouPanel;

	// Token: 0x04004039 RID: 16441
	public UIPanel FinalGamePanel;

	// Token: 0x0400403A RID: 16442
	public UIPanel RivalPanel;

	// Token: 0x0400403B RID: 16443
	public UIPanel QualityPanel;

	// Token: 0x0400403C RID: 16444
	public UIPanel WeaponsPanel;

	// Token: 0x0400403D RID: 16445
	public UIPanel StoryPanel;

	// Token: 0x0400403E RID: 16446
	public UIPanel MorePanel;

	// Token: 0x0400403F RID: 16447
	public UIPanel CrowdfundPanel;

	// Token: 0x04004040 RID: 16448
	public UIPanel SkipPanel;

	// Token: 0x04004041 RID: 16449
	public AudioSource Jukebox;

	// Token: 0x04004042 RID: 16450
	public Transform Yandere;

	// Token: 0x04004043 RID: 16451
	public UISprite SkipCircle;

	// Token: 0x04004044 RID: 16452
	public UISprite Darkness;

	// Token: 0x04004045 RID: 16453
	public Animation YandereKun;

	// Token: 0x04004046 RID: 16454
	public Animation Ryoba;

	// Token: 0x04004047 RID: 16455
	public bool FadeOut;

	// Token: 0x04004048 RID: 16456
	public float Alpha;
}
