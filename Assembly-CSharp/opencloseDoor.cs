using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020E4 RID: 8420 RVA: 0x001E4DA7 File Offset: 0x001E2FA7
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x001E4DB0 File Offset: 0x001E2FB0
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

	// Token: 0x060020E6 RID: 8422 RVA: 0x001E4E27 File Offset: 0x001E3027
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E7 RID: 8423 RVA: 0x001E4E36 File Offset: 0x001E3036
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004885 RID: 18565
	public Animator openandclose;

	// Token: 0x04004886 RID: 18566
	public bool open;

	// Token: 0x04004887 RID: 18567
	public Transform Player;
}
