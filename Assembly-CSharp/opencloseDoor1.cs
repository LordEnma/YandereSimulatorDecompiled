using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020C4 RID: 8388 RVA: 0x001E1219 File Offset: 0x001DF419
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020C5 RID: 8389 RVA: 0x001E1224 File Offset: 0x001DF424
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

	// Token: 0x060020C6 RID: 8390 RVA: 0x001E129B File Offset: 0x001DF49B
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020C7 RID: 8391 RVA: 0x001E12AA File Offset: 0x001DF4AA
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400481A RID: 18458
	public Animator openandclose1;

	// Token: 0x0400481B RID: 18459
	public bool open;

	// Token: 0x0400481C RID: 18460
	public Transform Player;
}
