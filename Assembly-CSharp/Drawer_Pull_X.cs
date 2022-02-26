using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x06002103 RID: 8451 RVA: 0x001E64A5 File Offset: 0x001E46A5
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002104 RID: 8452 RVA: 0x001E64B0 File Offset: 0x001E46B0
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

	// Token: 0x06002105 RID: 8453 RVA: 0x001E6531 File Offset: 0x001E4731
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x001E6540 File Offset: 0x001E4740
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048AD RID: 18605
	public Animator pull_01;

	// Token: 0x040048AE RID: 18606
	public bool open;

	// Token: 0x040048AF RID: 18607
	public Transform Player;
}
