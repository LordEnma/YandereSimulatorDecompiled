using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002106 RID: 8454 RVA: 0x001E537E File Offset: 0x001E357E
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x001E5388 File Offset: 0x001E3588
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

	// Token: 0x06002108 RID: 8456 RVA: 0x001E53FF File Offset: 0x001E35FF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x001E540E File Offset: 0x001E360E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048A4 RID: 18596
	public Animator openandclosewindow1;

	// Token: 0x040048A5 RID: 18597
	public bool open;

	// Token: 0x040048A6 RID: 18598
	public Transform Player;
}
