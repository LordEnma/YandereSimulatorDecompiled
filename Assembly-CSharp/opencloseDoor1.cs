using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x06002150 RID: 8528 RVA: 0x001EE679 File Offset: 0x001EC879
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002151 RID: 8529 RVA: 0x001EE684 File Offset: 0x001EC884
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

	// Token: 0x06002152 RID: 8530 RVA: 0x001EE6FB File Offset: 0x001EC8FB
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002153 RID: 8531 RVA: 0x001EE70A File Offset: 0x001EC90A
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049B4 RID: 18868
	public Animator openandclose1;

	// Token: 0x040049B5 RID: 18869
	public bool open;

	// Token: 0x040049B6 RID: 18870
	public Transform Player;
}
