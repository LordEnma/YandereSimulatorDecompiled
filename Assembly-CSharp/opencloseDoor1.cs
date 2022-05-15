using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x0600214F RID: 8527 RVA: 0x001EE111 File Offset: 0x001EC311
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002150 RID: 8528 RVA: 0x001EE11C File Offset: 0x001EC31C
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

	// Token: 0x06002151 RID: 8529 RVA: 0x001EE193 File Offset: 0x001EC393
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x001EE1A2 File Offset: 0x001EC3A2
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049AB RID: 18859
	public Animator openandclose1;

	// Token: 0x040049AC RID: 18860
	public bool open;

	// Token: 0x040049AD RID: 18861
	public Transform Player;
}
