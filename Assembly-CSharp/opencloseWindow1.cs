using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x0600211B RID: 8475 RVA: 0x001E692E File Offset: 0x001E4B2E
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600211C RID: 8476 RVA: 0x001E6938 File Offset: 0x001E4B38
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

	// Token: 0x0600211D RID: 8477 RVA: 0x001E69AF File Offset: 0x001E4BAF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600211E RID: 8478 RVA: 0x001E69BE File Offset: 0x001E4BBE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048C6 RID: 18630
	public Animator openandclosewindow1;

	// Token: 0x040048C7 RID: 18631
	public bool open;

	// Token: 0x040048C8 RID: 18632
	public Transform Player;
}
