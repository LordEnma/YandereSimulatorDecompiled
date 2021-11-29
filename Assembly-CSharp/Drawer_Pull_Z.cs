using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020CE RID: 8398 RVA: 0x001E1373 File Offset: 0x001DF573
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020CF RID: 8399 RVA: 0x001E137C File Offset: 0x001DF57C
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

	// Token: 0x060020D0 RID: 8400 RVA: 0x001E13FD File Offset: 0x001DF5FD
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020D1 RID: 8401 RVA: 0x001E140C File Offset: 0x001DF60C
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004820 RID: 18464
	public Animator pull;

	// Token: 0x04004821 RID: 18465
	public bool open;

	// Token: 0x04004822 RID: 18466
	public Transform Player;
}
