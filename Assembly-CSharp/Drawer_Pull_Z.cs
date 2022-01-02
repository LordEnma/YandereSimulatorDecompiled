using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020E2 RID: 8418 RVA: 0x001E3097 File Offset: 0x001E1297
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x001E30A0 File Offset: 0x001E12A0
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

	// Token: 0x060020E4 RID: 8420 RVA: 0x001E3121 File Offset: 0x001E1321
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x001E3130 File Offset: 0x001E1330
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004868 RID: 18536
	public Animator pull;

	// Token: 0x04004869 RID: 18537
	public bool open;

	// Token: 0x0400486A RID: 18538
	public Transform Player;
}
