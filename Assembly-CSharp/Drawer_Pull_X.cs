using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020C9 RID: 8393 RVA: 0x001E12C1 File Offset: 0x001DF4C1
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020CA RID: 8394 RVA: 0x001E12CC File Offset: 0x001DF4CC
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 10f)
		{
			MonoBehaviour.print("object name");
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

	// Token: 0x060020CB RID: 8395 RVA: 0x001E134D File Offset: 0x001DF54D
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020CC RID: 8396 RVA: 0x001E135C File Offset: 0x001DF55C
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400481D RID: 18461
	public Animator pull_01;

	// Token: 0x0400481E RID: 18462
	public bool open;

	// Token: 0x0400481F RID: 18463
	public Transform Player;
}
