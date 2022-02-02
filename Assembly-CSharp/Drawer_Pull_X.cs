using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020EE RID: 8430 RVA: 0x001E4EF5 File Offset: 0x001E30F5
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x001E4F00 File Offset: 0x001E3100
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

	// Token: 0x060020F0 RID: 8432 RVA: 0x001E4F81 File Offset: 0x001E3181
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E4F90 File Offset: 0x001E3190
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400488B RID: 18571
	public Animator pull_01;

	// Token: 0x0400488C RID: 18572
	public bool open;

	// Token: 0x0400488D RID: 18573
	public Transform Player;
}
