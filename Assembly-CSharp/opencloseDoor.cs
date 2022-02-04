using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020E6 RID: 8422 RVA: 0x001E50BF File Offset: 0x001E32BF
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E7 RID: 8423 RVA: 0x001E50C8 File Offset: 0x001E32C8
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

	// Token: 0x060020E8 RID: 8424 RVA: 0x001E513F File Offset: 0x001E333F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E9 RID: 8425 RVA: 0x001E514E File Offset: 0x001E334E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400488B RID: 18571
	public Animator openandclose;

	// Token: 0x0400488C RID: 18572
	public bool open;

	// Token: 0x0400488D RID: 18573
	public Transform Player;
}
