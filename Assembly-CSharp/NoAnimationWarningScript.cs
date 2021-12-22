using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000377 RID: 887
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x060019ED RID: 6637 RVA: 0x0010F0EA File Offset: 0x0010D2EA
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x060019EE RID: 6638 RVA: 0x0010F110 File Offset: 0x0010D310
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

	// Token: 0x040029EE RID: 10734
	public UISprite Darkness;

	// Token: 0x040029EF RID: 10735
	public bool FadeOut;

	// Token: 0x040029F0 RID: 10736
	public float Alpha;
}
