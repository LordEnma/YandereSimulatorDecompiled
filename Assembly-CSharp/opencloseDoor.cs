using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020F0 RID: 8432 RVA: 0x001E5777 File Offset: 0x001E3977
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E5780 File Offset: 0x001E3980
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

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E57F7 File Offset: 0x001E39F7
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E5806 File Offset: 0x001E3A06
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004897 RID: 18583
	public Animator openandclose;

	// Token: 0x04004898 RID: 18584
	public bool open;

	// Token: 0x04004899 RID: 18585
	public Transform Player;
}
