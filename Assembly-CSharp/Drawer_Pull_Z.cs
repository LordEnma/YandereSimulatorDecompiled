using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x06002136 RID: 8502 RVA: 0x001EA707 File Offset: 0x001E8907
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002137 RID: 8503 RVA: 0x001EA710 File Offset: 0x001E8910
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

	// Token: 0x06002138 RID: 8504 RVA: 0x001EA791 File Offset: 0x001E8991
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002139 RID: 8505 RVA: 0x001EA7A0 File Offset: 0x001E89A0
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400495E RID: 18782
	public Animator pull;

	// Token: 0x0400495F RID: 18783
	public bool open;

	// Token: 0x04004960 RID: 18784
	public Transform Player;
}
