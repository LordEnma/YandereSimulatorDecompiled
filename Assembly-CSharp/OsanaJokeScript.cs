using System;
using UnityEngine;

// Token: 0x02000386 RID: 902
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A30 RID: 6704 RVA: 0x00114EF0 File Offset: 0x001130F0
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

	// Token: 0x04002AB3 RID: 10931
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002AB4 RID: 10932
	public GameObject BloodSplatterEffect;

	// Token: 0x04002AB5 RID: 10933
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002AB6 RID: 10934
	public AudioClip VictoryMusic;

	// Token: 0x04002AB7 RID: 10935
	public AudioSource Jukebox;

	// Token: 0x04002AB8 RID: 10936
	public Transform Head;

	// Token: 0x04002AB9 RID: 10937
	public UILabel Label;

	// Token: 0x04002ABA RID: 10938
	public bool Advance;

	// Token: 0x04002ABB RID: 10939
	public float Timer;

	// Token: 0x04002ABC RID: 10940
	public int ID;
}
