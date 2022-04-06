using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x06002139 RID: 8505 RVA: 0x001EAB85 File Offset: 0x001E8D85
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600213A RID: 8506 RVA: 0x001EAB90 File Offset: 0x001E8D90
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

	// Token: 0x0600213B RID: 8507 RVA: 0x001EAC11 File Offset: 0x001E8E11
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x001EAC20 File Offset: 0x001E8E20
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400495F RID: 18783
	public Animator pull_01;

	// Token: 0x04004960 RID: 18784
	public bool open;

	// Token: 0x04004961 RID: 18785
	public Transform Player;
}
