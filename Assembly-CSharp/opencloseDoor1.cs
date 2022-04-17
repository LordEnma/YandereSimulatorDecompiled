using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x0600213B RID: 8507 RVA: 0x001EB539 File Offset: 0x001E9739
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x001EB544 File Offset: 0x001E9744
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

	// Token: 0x0600213D RID: 8509 RVA: 0x001EB5BB File Offset: 0x001E97BB
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600213E RID: 8510 RVA: 0x001EB5CA File Offset: 0x001E97CA
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400496E RID: 18798
	public Animator openandclose1;

	// Token: 0x0400496F RID: 18799
	public bool open;

	// Token: 0x04004970 RID: 18800
	public Transform Player;
}
