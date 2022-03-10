using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x0600210E RID: 8462 RVA: 0x001E6F2F File Offset: 0x001E512F
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x001E6F38 File Offset: 0x001E5138
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

	// Token: 0x06002110 RID: 8464 RVA: 0x001E6FB9 File Offset: 0x001E51B9
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002111 RID: 8465 RVA: 0x001E6FC8 File Offset: 0x001E51C8
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048CD RID: 18637
	public Animator pull;

	// Token: 0x040048CE RID: 18638
	public bool open;

	// Token: 0x040048CF RID: 18639
	public Transform Player;
}
