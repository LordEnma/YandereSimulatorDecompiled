using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x0600210B RID: 8459 RVA: 0x001E589A File Offset: 0x001E3A9A
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x001E58A4 File Offset: 0x001E3AA4
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

	// Token: 0x0600210D RID: 8461 RVA: 0x001E591B File Offset: 0x001E3B1B
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x001E592A File Offset: 0x001E3B2A
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048AD RID: 18605
	public Animator openandclosewindow1;

	// Token: 0x040048AE RID: 18606
	public bool open;

	// Token: 0x040048AF RID: 18607
	public Transform Player;
}
