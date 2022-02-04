using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002108 RID: 8456 RVA: 0x001E5696 File Offset: 0x001E3896
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x001E56A0 File Offset: 0x001E38A0
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

	// Token: 0x0600210A RID: 8458 RVA: 0x001E5717 File Offset: 0x001E3917
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600210B RID: 8459 RVA: 0x001E5726 File Offset: 0x001E3926
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048AA RID: 18602
	public Animator openandclosewindow1;

	// Token: 0x040048AB RID: 18603
	public bool open;

	// Token: 0x040048AC RID: 18604
	public Transform Player;
}
