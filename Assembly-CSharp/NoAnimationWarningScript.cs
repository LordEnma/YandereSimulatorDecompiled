using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037D RID: 893
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A2C RID: 6700 RVA: 0x001133F6 File Offset: 0x001115F6
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A2D RID: 6701 RVA: 0x0011341C File Offset: 0x0011161C
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

	// Token: 0x04002A99 RID: 10905
	public UISprite Darkness;

	// Token: 0x04002A9A RID: 10906
	public bool FadeOut;

	// Token: 0x04002A9B RID: 10907
	public float Alpha;
}
