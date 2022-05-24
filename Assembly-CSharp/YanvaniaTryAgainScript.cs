using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004EF RID: 1263
public class YanvaniaTryAgainScript : MonoBehaviour
{
	// Token: 0x06002105 RID: 8453 RVA: 0x001E93F4 File Offset: 0x001E75F4
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x001E9408 File Offset: 0x001E7608
	private void Update()
	{
		if (!this.FadeOut)
		{
			if (base.transform.localScale.x > 0.9f)
			{
				if (this.InputManager.TappedLeft)
				{
					this.Selected = 1;
				}
				if (this.InputManager.TappedRight)
				{
					this.Selected = 2;
				}
				if (this.Selected == 1)
				{
					this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, -100f, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
					this.Highlight.localScale = new Vector3(Mathf.Lerp(this.Highlight.localScale.x, -1f, Time.deltaTime * 10f), this.Highlight.localScale.y, this.Highlight.localScale.z);
				}
				else
				{
					this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, 100f, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
					this.Highlight.localScale = new Vector3(Mathf.Lerp(this.Highlight.localScale.x, 1f, Time.deltaTime * 10f), this.Highlight.localScale.y, this.Highlight.localScale.z);
				}
				if (Input.GetButtonDown("A") || Input.GetKeyDown("z") || Input.GetKeyDown("x"))
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ButtonEffect, this.Highlight.position, Quaternion.identity);
					gameObject.transform.parent = this.Highlight;
					gameObject.transform.localPosition = Vector3.zero;
					this.FadeOut = true;
					return;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				if (this.Selected == 1)
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
					return;
				}
				SceneManager.LoadScene("YanvaniaTitleScene");
			}
		}
	}

	// Token: 0x040048BA RID: 18618
	public InputManagerScript InputManager;

	// Token: 0x040048BB RID: 18619
	public GameObject ButtonEffect;

	// Token: 0x040048BC RID: 18620
	public Transform Highlight;

	// Token: 0x040048BD RID: 18621
	public UISprite Darkness;

	// Token: 0x040048BE RID: 18622
	public bool FadeOut;

	// Token: 0x040048BF RID: 18623
	public int Selected = 1;
}
