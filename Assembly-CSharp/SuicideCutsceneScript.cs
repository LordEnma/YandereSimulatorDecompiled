using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200045B RID: 1115
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E4E RID: 7758 RVA: 0x001A06F4 File Offset: 0x0019E8F4
	private void Start()
	{
		this.PointLight.color = new Color(0.1f, 0.1f, 0.1f, 1f);
		this.Door.eulerAngles = new Vector3(0f, 0f, 0f);
		if (GameGlobals.Eighties)
		{
			this.MyAudio.clip = this.EightiesMother;
			this.RivalHair[1].SetActive(false);
			this.EightiesHair[DateGlobals.Week].SetActive(true);
		}
	}

	// Token: 0x06001E4F RID: 7759 RVA: 0x001A077C File Offset: 0x0019E97C
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.ID == 0)
		{
			if (this.Timer > 1f)
			{
				this.MyAudio.Play();
				this.ID++;
				return;
			}
		}
		else if (this.ID == 1)
		{
			if (this.Timer > 6f)
			{
				this.Speed += Time.deltaTime * 0.66666f;
				this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * this.Speed);
				this.PointLight.color = new Color(0.1f + this.Rotation / -45f * 0.9f, 0.1f + this.Rotation / -45f * 0.9f, 0.1f + this.Rotation / -45f * 0.9f, 1f);
				this.Door.eulerAngles = new Vector3(0f, this.Rotation, 0f);
			}
			if (this.Timer > 8.5f)
			{
				this.Mom.CrossFade("f02_shock_00");
			}
			if (this.Timer > 9.5f)
			{
				this.DirectionalLight.color = new Color(0f, 0f, 0f);
				this.PointLight.color = new Color(0f, 0f, 0f);
			}
			if (this.Timer > 11f)
			{
				GameGlobals.SpecificEliminationID = 19;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Suicide", 1);
				}
				SchoolGlobals.SchoolAtmosphere -= 0.1f;
				GameGlobals.SenpaiMourning = true;
				SceneManager.LoadScene("HomeScene");
			}
		}
	}

	// Token: 0x04003E0C RID: 15884
	public AudioSource MyAudio;

	// Token: 0x04003E0D RID: 15885
	public AudioClip EightiesMother;

	// Token: 0x04003E0E RID: 15886
	public Light DirectionalLight;

	// Token: 0x04003E0F RID: 15887
	public Light PointLight;

	// Token: 0x04003E10 RID: 15888
	public Transform Door;

	// Token: 0x04003E11 RID: 15889
	public Animation Mom;

	// Token: 0x04003E12 RID: 15890
	public float Timer;

	// Token: 0x04003E13 RID: 15891
	public float Rotation;

	// Token: 0x04003E14 RID: 15892
	public float Speed;

	// Token: 0x04003E15 RID: 15893
	public int ID;

	// Token: 0x04003E16 RID: 15894
	public GameObject[] RivalHair;

	// Token: 0x04003E17 RID: 15895
	public GameObject[] EightiesHair;
}
