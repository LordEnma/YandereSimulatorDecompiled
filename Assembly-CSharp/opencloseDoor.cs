using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x06002117 RID: 8471 RVA: 0x001E8C97 File Offset: 0x001E6E97
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x001E8CA0 File Offset: 0x001E6EA0
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

	// Token: 0x06002119 RID: 8473 RVA: 0x001E8D17 File Offset: 0x001E6F17
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600211A RID: 8474 RVA: 0x001E8D26 File Offset: 0x001E6F26
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004923 RID: 18723
	public Animator openandclose;

	// Token: 0x04004924 RID: 18724
	public bool open;

	// Token: 0x04004925 RID: 18725
	public Transform Player;
}
