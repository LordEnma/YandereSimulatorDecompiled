using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020F3 RID: 8435 RVA: 0x001E4FA7 File Offset: 0x001E31A7
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x001E4FB0 File Offset: 0x001E31B0
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 10f)
		{
			MonoBehaviour.print("object name");
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

	// Token: 0x060020F5 RID: 8437 RVA: 0x001E5031 File Offset: 0x001E3231
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E5040 File Offset: 0x001E3240
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400488E RID: 18574
	public Animator pull;

	// Token: 0x0400488F RID: 18575
	public bool open;

	// Token: 0x04004890 RID: 18576
	public Transform Player;
}
