using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020FA RID: 8442 RVA: 0x001E58C5 File Offset: 0x001E3AC5
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E58D0 File Offset: 0x001E3AD0
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

	// Token: 0x060020FC RID: 8444 RVA: 0x001E5951 File Offset: 0x001E3B51
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020FD RID: 8445 RVA: 0x001E5960 File Offset: 0x001E3B60
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400489D RID: 18589
	public Animator pull_01;

	// Token: 0x0400489E RID: 18590
	public bool open;

	// Token: 0x0400489F RID: 18591
	public Transform Player;
}
