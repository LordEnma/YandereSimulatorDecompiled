using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002112 RID: 8466 RVA: 0x001E5D4E File Offset: 0x001E3F4E
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002113 RID: 8467 RVA: 0x001E5D58 File Offset: 0x001E3F58
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

	// Token: 0x06002114 RID: 8468 RVA: 0x001E5DCF File Offset: 0x001E3FCF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x001E5DDE File Offset: 0x001E3FDE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048B6 RID: 18614
	public Animator openandclosewindow1;

	// Token: 0x040048B7 RID: 18615
	public bool open;

	// Token: 0x040048B8 RID: 18616
	public Transform Player;
}
