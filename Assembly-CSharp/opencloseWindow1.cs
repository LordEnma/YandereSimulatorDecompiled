using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x060020F5 RID: 8437 RVA: 0x001E346E File Offset: 0x001E166E
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E3478 File Offset: 0x001E1678
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

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E34EF File Offset: 0x001E16EF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x001E34FE File Offset: 0x001E16FE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400487E RID: 18558
	public Animator openandclosewindow1;

	// Token: 0x0400487F RID: 18559
	public bool open;

	// Token: 0x04004880 RID: 18560
	public Transform Player;
}
