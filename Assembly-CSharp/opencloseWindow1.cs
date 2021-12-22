using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x060020F2 RID: 8434 RVA: 0x001E2E7E File Offset: 0x001E107E
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E2E88 File Offset: 0x001E1088
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

	// Token: 0x060020F4 RID: 8436 RVA: 0x001E2EFF File Offset: 0x001E10FF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F5 RID: 8437 RVA: 0x001E2F0E File Offset: 0x001E110E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004875 RID: 18549
	public Animator openandclosewindow1;

	// Token: 0x04004876 RID: 18550
	public bool open;

	// Token: 0x04004877 RID: 18551
	public Transform Player;
}
