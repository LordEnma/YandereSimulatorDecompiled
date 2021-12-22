using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020D0 RID: 8400 RVA: 0x001E28A7 File Offset: 0x001E0AA7
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020D1 RID: 8401 RVA: 0x001E28B0 File Offset: 0x001E0AB0
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

	// Token: 0x060020D2 RID: 8402 RVA: 0x001E2927 File Offset: 0x001E0B27
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020D3 RID: 8403 RVA: 0x001E2936 File Offset: 0x001E0B36
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004856 RID: 18518
	public Animator openandclose;

	// Token: 0x04004857 RID: 18519
	public bool open;

	// Token: 0x04004858 RID: 18520
	public Transform Player;
}
