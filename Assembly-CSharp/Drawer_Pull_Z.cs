using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020F5 RID: 8437 RVA: 0x001E52BF File Offset: 0x001E34BF
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E52C8 File Offset: 0x001E34C8
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

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E5349 File Offset: 0x001E3549
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x001E5358 File Offset: 0x001E3558
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004894 RID: 18580
	public Animator pull;

	// Token: 0x04004895 RID: 18581
	public bool open;

	// Token: 0x04004896 RID: 18582
	public Transform Player;
}
