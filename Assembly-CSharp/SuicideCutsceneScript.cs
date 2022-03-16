using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000462 RID: 1122
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E84 RID: 7812 RVA: 0x001A5430 File Offset: 0x001A3630
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

	// Token: 0x06001E85 RID: 7813 RVA: 0x001A54B8 File Offset: 0x001A36B8
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

	// Token: 0x04003EB1 RID: 16049
	public AudioSource MyAudio;

	// Token: 0x04003EB2 RID: 16050
	public AudioClip EightiesMother;

	// Token: 0x04003EB3 RID: 16051
	public Light DirectionalLight;

	// Token: 0x04003EB4 RID: 16052
	public Light PointLight;

	// Token: 0x04003EB5 RID: 16053
	public Transform Door;

	// Token: 0x04003EB6 RID: 16054
	public Animation Mom;

	// Token: 0x04003EB7 RID: 16055
	public float Timer;

	// Token: 0x04003EB8 RID: 16056
	public float Rotation;

	// Token: 0x04003EB9 RID: 16057
	public float Speed;

	// Token: 0x04003EBA RID: 16058
	public int ID;

	// Token: 0x04003EBB RID: 16059
	public GameObject[] RivalHair;

	// Token: 0x04003EBC RID: 16060
	public GameObject[] EightiesHair;
}
