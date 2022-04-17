using System;
using UnityEngine;

// Token: 0x02000388 RID: 904
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A4B RID: 6731 RVA: 0x001168A4 File Offset: 0x00114AA4
	private void Update()
	{
		if (this.Advance)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 14f)
			{
				Application.Quit();
				return;
			}
			if (this.Timer > 3f)
			{
				this.Label.text = "Congratulations! You have beaten Yandere Simulator!";
				if (!this.Jukebox.isPlaying)
				{
					this.Jukebox.clip = this.VictoryMusic;
					this.Jukebox.Play();
					return;
				}
			}
		}
		else if (Input.GetKeyDown("f"))
		{
			this.Rotation[0].enabled = false;
			this.Rotation[1].enabled = false;
			this.Rotation[2].enabled = false;
			this.Rotation[3].enabled = false;
			this.Rotation[4].enabled = false;
			this.Rotation[5].enabled = false;
			this.Rotation[6].enabled = false;
			this.Rotation[7].enabled = false;
			UnityEngine.Object.Instantiate<GameObject>(this.BloodSplatterEffect, this.Head.position, Quaternion.identity);
			this.Head.localScale = new Vector3(0f, 0f, 0f);
			this.Jukebox.clip = this.BloodSplatterSFX;
			this.Jukebox.Play();
			this.Label.text = "";
			this.Advance = true;
		}
	}

	// Token: 0x04002B10 RID: 11024
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002B11 RID: 11025
	public GameObject BloodSplatterEffect;

	// Token: 0x04002B12 RID: 11026
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002B13 RID: 11027
	public AudioClip VictoryMusic;

	// Token: 0x04002B14 RID: 11028
	public AudioSource Jukebox;

	// Token: 0x04002B15 RID: 11029
	public Transform Head;

	// Token: 0x04002B16 RID: 11030
	public UILabel Label;

	// Token: 0x04002B17 RID: 11031
	public bool Advance;

	// Token: 0x04002B18 RID: 11032
	public float Timer;

	// Token: 0x04002B19 RID: 11033
	public int ID;
}
