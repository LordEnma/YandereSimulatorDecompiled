using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037A RID: 890
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A06 RID: 6662 RVA: 0x00110B42 File Offset: 0x0010ED42
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A07 RID: 6663 RVA: 0x00110B68 File Offset: 0x0010ED68
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

	// Token: 0x04002A1A RID: 10778
	public UISprite Darkness;

	// Token: 0x04002A1B RID: 10779
	public bool FadeOut;

	// Token: 0x04002A1C RID: 10780
	public float Alpha;
}
