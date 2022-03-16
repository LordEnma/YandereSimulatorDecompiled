using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class LaptopScript : MonoBehaviour
{
	// Token: 0x0600195A RID: 6490 RVA: 0x000FE71C File Offset: 0x000FC91C
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

	// Token: 0x0600195B RID: 6491 RVA: 0x000FE7C0 File Offset: 0x000FC9C0
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

	// Token: 0x0600195C RID: 6492 RVA: 0x000FEB54 File Offset: 0x000FCD54
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

	// Token: 0x04002818 RID: 10264
	public SkinnedMeshRenderer SCPRenderer;

	// Token: 0x04002819 RID: 10265
	public Camera LaptopCamera;

	// Token: 0x0400281A RID: 10266
	public JukeboxScript Jukebox;

	// Token: 0x0400281B RID: 10267
	public YandereScript Yandere;

	// Token: 0x0400281C RID: 10268
	public AudioSource MyAudio;

	// Token: 0x0400281D RID: 10269
	public DynamicBone Hair;

	// Token: 0x0400281E RID: 10270
	public Transform LaptopScreen;

	// Token: 0x0400281F RID: 10271
	public AudioClip ShutDown;

	// Token: 0x04002820 RID: 10272
	public GameObject SCP;

	// Token: 0x04002821 RID: 10273
	public bool React;

	// Token: 0x04002822 RID: 10274
	public bool Off;

	// Token: 0x04002823 RID: 10275
	public float[] Cues;

	// Token: 0x04002824 RID: 10276
	public string[] Subs;

	// Token: 0x04002825 RID: 10277
	public Mesh[] Uniforms;

	// Token: 0x04002826 RID: 10278
	public int FirstFrame;

	// Token: 0x04002827 RID: 10279
	public float Timer;

	// Token: 0x04002828 RID: 10280
	public UILabel EventSubtitle;
}
