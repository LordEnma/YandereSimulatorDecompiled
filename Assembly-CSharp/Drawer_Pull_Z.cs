using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020DF RID: 8415 RVA: 0x001E2AA7 File Offset: 0x001E0CA7
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E0 RID: 8416 RVA: 0x001E2AB0 File Offset: 0x001E0CB0
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

	// Token: 0x060020E1 RID: 8417 RVA: 0x001E2B31 File Offset: 0x001E0D31
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x001E2B40 File Offset: 0x001E0D40
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400485F RID: 18527
	public Animator pull;

	// Token: 0x04004860 RID: 18528
	public bool open;

	// Token: 0x04004861 RID: 18529
	public Transform Player;
}
