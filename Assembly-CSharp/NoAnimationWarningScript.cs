using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037C RID: 892
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A1D RID: 6685 RVA: 0x001121C2 File Offset: 0x001103C2
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A1E RID: 6686 RVA: 0x001121E8 File Offset: 0x001103E8
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

	// Token: 0x04002A6F RID: 10863
	public UISprite Darkness;

	// Token: 0x04002A70 RID: 10864
	public bool FadeOut;

	// Token: 0x04002A71 RID: 10865
	public float Alpha;
}
