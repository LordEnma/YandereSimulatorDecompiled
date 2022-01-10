using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000378 RID: 888
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x060019F3 RID: 6643 RVA: 0x0010F76E File Offset: 0x0010D96E
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x060019F4 RID: 6644 RVA: 0x0010F794 File Offset: 0x0010D994
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

	// Token: 0x040029F8 RID: 10744
	public UISprite Darkness;

	// Token: 0x040029F9 RID: 10745
	public bool FadeOut;

	// Token: 0x040029FA RID: 10746
	public float Alpha;
}
