using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020DA RID: 8410 RVA: 0x001E29F5 File Offset: 0x001E0BF5
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x001E2A00 File Offset: 0x001E0C00
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

	// Token: 0x060020DC RID: 8412 RVA: 0x001E2A81 File Offset: 0x001E0C81
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020DD RID: 8413 RVA: 0x001E2A90 File Offset: 0x001E0C90
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400485C RID: 18524
	public Animator pull_01;

	// Token: 0x0400485D RID: 18525
	public bool open;

	// Token: 0x0400485E RID: 18526
	public Transform Player;
}
