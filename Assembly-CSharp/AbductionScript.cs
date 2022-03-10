using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x020000BF RID: 191
public class AbductionScript : MonoBehaviour
{
	// Token: 0x06000994 RID: 2452 RVA: 0x0004CA7C File Offset: 0x0004AC7C
	private void Start()
	{
		if (SchoolGlobals.SchoolAtmosphere > 0.5f)
		{
			this.Darkness.color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		}
		this.UpdateDOF(1f);
		if (GameGlobals.AbductionTarget > 0)
		{
			this.Renderer.material.SetTexture("_OverlayTex", this.RivalStockings[GameGlobals.AbductionTarget - 10]);
		}
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x0004CB18 File Offset: 0x0004AD18
	private void Update()
	{
		this.StartTimer += Time.deltaTime;
		if (this.StartTimer > 1f)
		{
			if ((double)this.StartTimer > 2.5 && !this.MyAudio.isPlaying && !this.PlayedAudio)
			{
				this.PlayedAudio = true;
				this.MyAudio.Play();
			}
			if (this.Phase == 0)
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime * 0.33333f);
				if (this.Darkness.alpha == 0f)
				{
					this.Anim1.Play();
					this.Anim2.enabled = true;
					this.Phase++;
					return;
				}
			}
			else if (this.Anim1["Scene"].time >= this.Anim1["Scene"].length)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 2f)
				{
					this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.33333f);
					if (this.Darkness.alpha == 1f)
					{
						SceneManager.LoadScene("LoadingScene");
					}
				}
			}
		}
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x0004CC84 File Offset: 0x0004AE84
	private void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x04000848 RID: 2120
	public SkinnedMeshRenderer Renderer;

	// Token: 0x04000849 RID: 2121
	public Texture[] RivalStockings;

	// Token: 0x0400084A RID: 2122
	public AudioSource MyAudio;

	// Token: 0x0400084B RID: 2123
	public UISprite Darkness;

	// Token: 0x0400084C RID: 2124
	public Camera MainCamera;

	// Token: 0x0400084D RID: 2125
	public float StartTimer;

	// Token: 0x0400084E RID: 2126
	public float Timer;

	// Token: 0x0400084F RID: 2127
	public bool PlayedAudio;

	// Token: 0x04000850 RID: 2128
	public int Phase;

	// Token: 0x04000851 RID: 2129
	public Animation Anim1;

	// Token: 0x04000852 RID: 2130
	public Animator Anim2;

	// Token: 0x04000853 RID: 2131
	public PostProcessingProfile Profile;
}
