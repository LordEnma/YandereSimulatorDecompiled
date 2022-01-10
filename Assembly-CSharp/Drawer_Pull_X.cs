using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020E8 RID: 8424 RVA: 0x001E3985 File Offset: 0x001E1B85
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E9 RID: 8425 RVA: 0x001E3990 File Offset: 0x001E1B90
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

	// Token: 0x060020EA RID: 8426 RVA: 0x001E3A11 File Offset: 0x001E1C11
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x001E3A20 File Offset: 0x001E1C20
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004879 RID: 18553
	public Animator pull_01;

	// Token: 0x0400487A RID: 18554
	public bool open;

	// Token: 0x0400487B RID: 18555
	public Transform Player;
}
