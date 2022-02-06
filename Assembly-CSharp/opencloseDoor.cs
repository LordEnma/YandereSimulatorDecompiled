using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020E9 RID: 8425 RVA: 0x001E52C3 File Offset: 0x001E34C3
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020EA RID: 8426 RVA: 0x001E52CC File Offset: 0x001E34CC
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

	// Token: 0x060020EB RID: 8427 RVA: 0x001E5343 File Offset: 0x001E3543
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020EC RID: 8428 RVA: 0x001E5352 File Offset: 0x001E3552
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400488E RID: 18574
	public Animator openandclose;

	// Token: 0x0400488F RID: 18575
	public bool open;

	// Token: 0x04004890 RID: 18576
	public Transform Player;
}
