using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200045A RID: 1114
public class SuicideCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E42 RID: 7746 RVA: 0x0019F5DC File Offset: 0x0019D7DC
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

	// Token: 0x06001E43 RID: 7747 RVA: 0x0019F664 File Offset: 0x0019D864
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
				GameGlobals.SenpaiMourning = true;
				SceneManager.LoadScene("HomeScene");
			}
		}
	}

	// Token: 0x04003DD5 RID: 15829
	public AudioSource MyAudio;

	// Token: 0x04003DD6 RID: 15830
	public AudioClip EightiesMother;

	// Token: 0x04003DD7 RID: 15831
	public Light DirectionalLight;

	// Token: 0x04003DD8 RID: 15832
	public Light PointLight;

	// Token: 0x04003DD9 RID: 15833
	public Transform Door;

	// Token: 0x04003DDA RID: 15834
	public Animation Mom;

	// Token: 0x04003DDB RID: 15835
	public float Timer;

	// Token: 0x04003DDC RID: 15836
	public float Rotation;

	// Token: 0x04003DDD RID: 15837
	public float Speed;

	// Token: 0x04003DDE RID: 15838
	public int ID;

	// Token: 0x04003DDF RID: 15839
	public GameObject[] RivalHair;

	// Token: 0x04003DE0 RID: 15840
	public GameObject[] EightiesHair;
}
