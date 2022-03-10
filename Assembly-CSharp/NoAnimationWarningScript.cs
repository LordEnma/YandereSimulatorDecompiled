using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037A RID: 890
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A07 RID: 6663 RVA: 0x00110EEE File Offset: 0x0010F0EE
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A08 RID: 6664 RVA: 0x00110F14 File Offset: 0x0010F114
	private void Update()
	{
		if (!this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f && Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				return;
			}
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 1f)
			{
				SceneManager.LoadScene("BusStopScene");
			}
		}
	}

	// Token: 0x04002A30 RID: 10800
	public UISprite Darkness;

	// Token: 0x04002A31 RID: 10801
	public bool FadeOut;

	// Token: 0x04002A32 RID: 10802
	public float Alpha;
}
