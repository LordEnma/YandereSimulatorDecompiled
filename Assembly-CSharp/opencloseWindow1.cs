using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x060020E1 RID: 8417 RVA: 0x001E174A File Offset: 0x001DF94A
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x001E1754 File Offset: 0x001DF954
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 15f)
		{
			if (!this.open)
			{
				if (Input.GetMouseButtonDown(0))
				{
					base.StartCoroutine(this.opening());
					return;
				}
			}
			else if (this.open && Input.GetMouseButtonDown(0))
			{
				base.StartCoroutine(this.closing());
			}
		}
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x001E17CB File Offset: 0x001DF9CB
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x001E17DA File Offset: 0x001DF9DA
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004836 RID: 18486
	public Animator openandclosewindow1;

	// Token: 0x04004837 RID: 18487
	public bool open;

	// Token: 0x04004838 RID: 18488
	public Transform Player;
}
