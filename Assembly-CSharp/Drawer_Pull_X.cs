using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x06002131 RID: 8497 RVA: 0x001EA655 File Offset: 0x001E8855
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x001EA660 File Offset: 0x001E8860
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

	// Token: 0x06002133 RID: 8499 RVA: 0x001EA6E1 File Offset: 0x001E88E1
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002134 RID: 8500 RVA: 0x001EA6F0 File Offset: 0x001E88F0
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400495B RID: 18779
	public Animator pull_01;

	// Token: 0x0400495C RID: 18780
	public bool open;

	// Token: 0x0400495D RID: 18781
	public Transform Player;
}
