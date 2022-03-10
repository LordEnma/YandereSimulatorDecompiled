using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002121 RID: 8481 RVA: 0x001E7306 File Offset: 0x001E5506
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002122 RID: 8482 RVA: 0x001E7310 File Offset: 0x001E5510
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

	// Token: 0x06002123 RID: 8483 RVA: 0x001E7387 File Offset: 0x001E5587
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x001E7396 File Offset: 0x001E5596
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048E3 RID: 18659
	public Animator openandclosewindow1;

	// Token: 0x040048E4 RID: 18660
	public bool open;

	// Token: 0x040048E5 RID: 18661
	public Transform Player;
}
