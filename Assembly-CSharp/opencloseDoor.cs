using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x0600214A RID: 8522 RVA: 0x001EE06B File Offset: 0x001EC26B
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600214B RID: 8523 RVA: 0x001EE074 File Offset: 0x001EC274
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

	// Token: 0x0600214C RID: 8524 RVA: 0x001EE0EB File Offset: 0x001EC2EB
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x001EE0FA File Offset: 0x001EC2FA
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049A8 RID: 18856
	public Animator openandclose;

	// Token: 0x040049A9 RID: 18857
	public bool open;

	// Token: 0x040049AA RID: 18858
	public Transform Player;
}
