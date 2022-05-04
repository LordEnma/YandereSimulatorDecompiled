using System;
using UnityEngine;

// Token: 0x02000388 RID: 904
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A4F RID: 6735 RVA: 0x00116D94 File Offset: 0x00114F94
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

	// Token: 0x04002B19 RID: 11033
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002B1A RID: 11034
	public GameObject BloodSplatterEffect;

	// Token: 0x04002B1B RID: 11035
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002B1C RID: 11036
	public AudioClip VictoryMusic;

	// Token: 0x04002B1D RID: 11037
	public AudioSource Jukebox;

	// Token: 0x04002B1E RID: 11038
	public Transform Head;

	// Token: 0x04002B1F RID: 11039
	public UILabel Label;

	// Token: 0x04002B20 RID: 11040
	public bool Advance;

	// Token: 0x04002B21 RID: 11041
	public float Timer;

	// Token: 0x04002B22 RID: 11042
	public int ID;
}
