using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020DE RID: 8414 RVA: 0x001E3837 File Offset: 0x001E1A37
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020DF RID: 8415 RVA: 0x001E3840 File Offset: 0x001E1A40
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

	// Token: 0x060020E0 RID: 8416 RVA: 0x001E38B7 File Offset: 0x001E1AB7
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E1 RID: 8417 RVA: 0x001E38C6 File Offset: 0x001E1AC6
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004873 RID: 18547
	public Animator openandclose;

	// Token: 0x04004874 RID: 18548
	public bool open;

	// Token: 0x04004875 RID: 18549
	public Transform Player;
}
