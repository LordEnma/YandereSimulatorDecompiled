using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class LaptopScript : MonoBehaviour
{
	// Token: 0x06001975 RID: 6517 RVA: 0x0010004C File Offset: 0x000FE24C
	private void Start()
	{
		if (SchoolGlobals.SCP || GameGlobals.AlphabetMode)
		{
			this.LaptopScreen.localScale = Vector3.zero;
			this.LaptopCamera.enabled = false;
			this.SCP.SetActive(false);
			base.enabled = false;
			return;
		}
		this.SCPRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		Animation component = this.SCP.GetComponent<Animation>();
		component["f02_scp_00"].speed = 0f;
		component["f02_scp_00"].time = 0f;
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06001976 RID: 6518 RVA: 0x001000F0 File Offset: 0x000FE2F0
	private void Update()
	{
		if (this.FirstFrame == 2)
		{
			this.LaptopCamera.enabled = false;
		}
		this.FirstFrame++;
		if (!this.Off)
		{
			Animation component = this.SCP.GetComponent<Animation>();
			if (!this.React)
			{
				if (this.Yandere.transform.position.x > base.transform.position.x + 1f && Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) < 2f && this.Yandere.Followers == 0)
				{
					this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					component["f02_scp_00"].time = 0f;
					this.LaptopCamera.enabled = true;
					component.Play();
					this.Hair.enabled = true;
					this.Jukebox.Dip = 0.5f;
					this.MyAudio.Play();
					this.React = true;
				}
			}
			else
			{
				this.MyAudio.pitch = Time.timeScale;
				this.MyAudio.volume = 1f;
				if (this.Yandere.transform.position.y > base.transform.position.y + 3f || this.Yandere.transform.position.y < base.transform.position.y - 3f)
				{
					this.MyAudio.volume = 0f;
				}
				for (int i = 0; i < this.Cues.Length; i++)
				{
					if (this.MyAudio.time > this.Cues[i])
					{
						this.EventSubtitle.text = this.Subs[i];
					}
				}
				if (this.MyAudio.time >= this.MyAudio.clip.length - 1f || this.MyAudio.time == 0f)
				{
					component["f02_scp_00"].speed = 1f;
					this.Timer += Time.deltaTime;
				}
				else
				{
					component["f02_scp_00"].time = this.MyAudio.time;
				}
				if (this.Timer > 1f || Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) > 5f)
				{
					this.TurnOff();
				}
			}
			if (this.Yandere.StudentManager.Clock.HourTime > 16f || this.Yandere.Police.FadeOut)
			{
				this.TurnOff();
				return;
			}
		}
		else
		{
			if (this.LaptopScreen.localScale.x > 0.1f)
			{
				this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, Vector3.zero, Time.deltaTime * 10f);
				return;
			}
			if (base.enabled)
			{
				this.LaptopScreen.localScale = Vector3.zero;
				this.Hair.enabled = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x06001977 RID: 6519 RVA: 0x00100484 File Offset: 0x000FE684
	private void TurnOff()
	{
		this.MyAudio.clip = this.ShutDown;
		this.MyAudio.Play();
		this.EventSubtitle.text = string.Empty;
		SchoolGlobals.SCP = true;
		this.LaptopCamera.enabled = false;
		this.Jukebox.Dip = 1f;
		this.React = false;
		this.Off = true;
	}

	// Token: 0x04002857 RID: 10327
	public SkinnedMeshRenderer SCPRenderer;

	// Token: 0x04002858 RID: 10328
	public Camera LaptopCamera;

	// Token: 0x04002859 RID: 10329
	public JukeboxScript Jukebox;

	// Token: 0x0400285A RID: 10330
	public YandereScript Yandere;

	// Token: 0x0400285B RID: 10331
	public AudioSource MyAudio;

	// Token: 0x0400285C RID: 10332
	public DynamicBone Hair;

	// Token: 0x0400285D RID: 10333
	public Transform LaptopScreen;

	// Token: 0x0400285E RID: 10334
	public AudioClip ShutDown;

	// Token: 0x0400285F RID: 10335
	public GameObject SCP;

	// Token: 0x04002860 RID: 10336
	public bool React;

	// Token: 0x04002861 RID: 10337
	public bool Off;

	// Token: 0x04002862 RID: 10338
	public float[] Cues;

	// Token: 0x04002863 RID: 10339
	public string[] Subs;

	// Token: 0x04002864 RID: 10340
	public Mesh[] Uniforms;

	// Token: 0x04002865 RID: 10341
	public int FirstFrame;

	// Token: 0x04002866 RID: 10342
	public float Timer;

	// Token: 0x04002867 RID: 10343
	public UILabel EventSubtitle;
}
