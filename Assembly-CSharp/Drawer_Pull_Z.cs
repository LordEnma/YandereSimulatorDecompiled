using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x06002126 RID: 8486 RVA: 0x001E8E97 File Offset: 0x001E7097
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002127 RID: 8487 RVA: 0x001E8EA0 File Offset: 0x001E70A0
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

	// Token: 0x06002128 RID: 8488 RVA: 0x001E8F21 File Offset: 0x001E7121
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x001E8F30 File Offset: 0x001E7130
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400492C RID: 18732
	public Animator pull;

	// Token: 0x0400492D RID: 18733
	public bool open;

	// Token: 0x0400492E RID: 18734
	public Transform Player;
}
