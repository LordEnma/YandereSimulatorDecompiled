using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000379 RID: 889
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x060019FD RID: 6653 RVA: 0x00110212 File Offset: 0x0010E412
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x060019FE RID: 6654 RVA: 0x00110238 File Offset: 0x0010E438
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

	// Token: 0x04002A0B RID: 10763
	public UISprite Darkness;

	// Token: 0x04002A0C RID: 10764
	public bool FadeOut;

	// Token: 0x04002A0D RID: 10765
	public float Alpha;
}
