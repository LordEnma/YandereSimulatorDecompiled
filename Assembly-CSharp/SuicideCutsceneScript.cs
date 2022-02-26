using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000460 RID: 1120
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E71 RID: 7793 RVA: 0x001A3660 File Offset: 0x001A1860
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

	// Token: 0x06001E72 RID: 7794 RVA: 0x001A36E8 File Offset: 0x001A18E8
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

	// Token: 0x04003E50 RID: 15952
	public AudioSource MyAudio;

	// Token: 0x04003E51 RID: 15953
	public AudioClip EightiesMother;

	// Token: 0x04003E52 RID: 15954
	public Light DirectionalLight;

	// Token: 0x04003E53 RID: 15955
	public Light PointLight;

	// Token: 0x04003E54 RID: 15956
	public Transform Door;

	// Token: 0x04003E55 RID: 15957
	public Animation Mom;

	// Token: 0x04003E56 RID: 15958
	public float Timer;

	// Token: 0x04003E57 RID: 15959
	public float Rotation;

	// Token: 0x04003E58 RID: 15960
	public float Speed;

	// Token: 0x04003E59 RID: 15961
	public int ID;

	// Token: 0x04003E5A RID: 15962
	public GameObject[] RivalHair;

	// Token: 0x04003E5B RID: 15963
	public GameObject[] EightiesHair;
}
