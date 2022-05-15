using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037D RID: 893
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A2B RID: 6699 RVA: 0x001131F2 File Offset: 0x001113F2
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A2C RID: 6700 RVA: 0x00113218 File Offset: 0x00111418
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

	// Token: 0x04002A92 RID: 10898
	public UISprite Darkness;

	// Token: 0x04002A93 RID: 10899
	public bool FadeOut;

	// Token: 0x04002A94 RID: 10900
	public float Alpha;
}
