using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x06002108 RID: 8456 RVA: 0x001E6557 File Offset: 0x001E4757
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x001E6560 File Offset: 0x001E4760
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

	// Token: 0x0600210A RID: 8458 RVA: 0x001E65E1 File Offset: 0x001E47E1
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600210B RID: 8459 RVA: 0x001E65F0 File Offset: 0x001E47F0
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048B0 RID: 18608
	public Animator pull;

	// Token: 0x040048B1 RID: 18609
	public bool open;

	// Token: 0x040048B2 RID: 18610
	public Transform Player;
}
