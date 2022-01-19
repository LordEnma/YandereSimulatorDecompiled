using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000378 RID: 888
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x060019F3 RID: 6643 RVA: 0x0010F8D6 File Offset: 0x0010DAD6
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x060019F4 RID: 6644 RVA: 0x0010F8FC File Offset: 0x0010DAFC
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

	// Token: 0x040029FB RID: 10747
	public UISprite Darkness;

	// Token: 0x040029FC RID: 10748
	public bool FadeOut;

	// Token: 0x040029FD RID: 10749
	public float Alpha;
}
