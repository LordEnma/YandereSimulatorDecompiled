using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004EC RID: 1260
public class YanvaniaTryAgainScript : MonoBehaviour
{
	// Token: 0x060020E1 RID: 8417 RVA: 0x001E5328 File Offset: 0x001E3528
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x001E533C File Offset: 0x001E353C
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

	// Token: 0x0400485E RID: 18526
	public InputManagerScript InputManager;

	// Token: 0x0400485F RID: 18527
	public GameObject ButtonEffect;

	// Token: 0x04004860 RID: 18528
	public Transform Highlight;

	// Token: 0x04004861 RID: 18529
	public UISprite Darkness;

	// Token: 0x04004862 RID: 18530
	public bool FadeOut;

	// Token: 0x04004863 RID: 18531
	public int Selected = 1;
}
