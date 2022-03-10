using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x06002104 RID: 8452 RVA: 0x001E6DD5 File Offset: 0x001E4FD5
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002105 RID: 8453 RVA: 0x001E6DE0 File Offset: 0x001E4FE0
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 15f)
		{
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

	// Token: 0x06002106 RID: 8454 RVA: 0x001E6E57 File Offset: 0x001E5057
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x001E6E66 File Offset: 0x001E5066
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048C7 RID: 18631
	public Animator openandclose1;

	// Token: 0x040048C8 RID: 18632
	public bool open;

	// Token: 0x040048C9 RID: 18633
	public Transform Player;
}
