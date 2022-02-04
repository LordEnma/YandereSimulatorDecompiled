using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000378 RID: 888
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x060019F4 RID: 6644 RVA: 0x0010FDD6 File Offset: 0x0010DFD6
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x060019F5 RID: 6645 RVA: 0x0010FDFC File Offset: 0x0010DFFC
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

	// Token: 0x04002A02 RID: 10754
	public UISprite Darkness;

	// Token: 0x04002A03 RID: 10755
	public bool FadeOut;

	// Token: 0x04002A04 RID: 10756
	public float Alpha;
}
