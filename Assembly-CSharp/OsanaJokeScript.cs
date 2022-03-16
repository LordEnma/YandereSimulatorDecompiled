using System;
using UnityEngine;

// Token: 0x02000386 RID: 902
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A3B RID: 6715 RVA: 0x00115DD8 File Offset: 0x00113FD8
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

	// Token: 0x04002AF2 RID: 10994
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002AF3 RID: 10995
	public GameObject BloodSplatterEffect;

	// Token: 0x04002AF4 RID: 10996
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002AF5 RID: 10997
	public AudioClip VictoryMusic;

	// Token: 0x04002AF6 RID: 10998
	public AudioSource Jukebox;

	// Token: 0x04002AF7 RID: 10999
	public Transform Head;

	// Token: 0x04002AF8 RID: 11000
	public UILabel Label;

	// Token: 0x04002AF9 RID: 11001
	public bool Advance;

	// Token: 0x04002AFA RID: 11002
	public float Timer;

	// Token: 0x04002AFB RID: 11003
	public int ID;
}
