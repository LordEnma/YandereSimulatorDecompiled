using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x0600216D RID: 8557 RVA: 0x001EEBAA File Offset: 0x001ECDAA
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600216E RID: 8558 RVA: 0x001EEBB4 File Offset: 0x001ECDB4
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

	// Token: 0x0600216F RID: 8559 RVA: 0x001EEC2B File Offset: 0x001ECE2B
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002170 RID: 8560 RVA: 0x001EEC3A File Offset: 0x001ECE3A
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049D0 RID: 18896
	public Animator openandclosewindow1;

	// Token: 0x040049D1 RID: 18897
	public bool open;

	// Token: 0x040049D2 RID: 18898
	public Transform Player;
}
