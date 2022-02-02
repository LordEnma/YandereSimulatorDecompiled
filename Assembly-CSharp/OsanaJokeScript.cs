using System;
using UnityEngine;

// Token: 0x02000384 RID: 900
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A1E RID: 6686 RVA: 0x00113FE4 File Offset: 0x001121E4
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

	// Token: 0x04002A99 RID: 10905
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002A9A RID: 10906
	public GameObject BloodSplatterEffect;

	// Token: 0x04002A9B RID: 10907
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002A9C RID: 10908
	public AudioClip VictoryMusic;

	// Token: 0x04002A9D RID: 10909
	public AudioSource Jukebox;

	// Token: 0x04002A9E RID: 10910
	public Transform Head;

	// Token: 0x04002A9F RID: 10911
	public UILabel Label;

	// Token: 0x04002AA0 RID: 10912
	public bool Advance;

	// Token: 0x04002AA1 RID: 10913
	public float Timer;

	// Token: 0x04002AA2 RID: 10914
	public int ID;
}
