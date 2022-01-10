using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020ED RID: 8429 RVA: 0x001E3A37 File Offset: 0x001E1C37
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x001E3A40 File Offset: 0x001E1C40
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

	// Token: 0x060020EF RID: 8431 RVA: 0x001E3AC1 File Offset: 0x001E1CC1
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F0 RID: 8432 RVA: 0x001E3AD0 File Offset: 0x001E1CD0
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400487C RID: 18556
	public Animator pull;

	// Token: 0x0400487D RID: 18557
	public bool open;

	// Token: 0x0400487E RID: 18558
	public Transform Player;
}
