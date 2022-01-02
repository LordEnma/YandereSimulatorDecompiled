using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020D3 RID: 8403 RVA: 0x001E2E97 File Offset: 0x001E1097
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020D4 RID: 8404 RVA: 0x001E2EA0 File Offset: 0x001E10A0
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

	// Token: 0x060020D5 RID: 8405 RVA: 0x001E2F17 File Offset: 0x001E1117
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x001E2F26 File Offset: 0x001E1126
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400485F RID: 18527
	public Animator openandclose;

	// Token: 0x04004860 RID: 18528
	public bool open;

	// Token: 0x04004861 RID: 18529
	public Transform Player;
}
