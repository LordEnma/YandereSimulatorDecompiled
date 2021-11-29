using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeZoomScript : MonoBehaviour
{
	// Token: 0x060018A6 RID: 6310 RVA: 0x000F1D48 File Offset: 0x000EFF48
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (Input.GetKeyDown(KeyCode.Z))
		{
			if (!this.Zoom)
			{
				this.Zoom = true;
				component.Play();
			}
			else
			{
				this.Zoom = false;
			}
		}
		if (this.Zoom)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, 1.5f, Time.deltaTime * 0.033333335f), base.transform.localPosition.z);
			this.YandereDestination.localPosition = Vector3.MoveTowards(this.YandereDestination.localPosition, new Vector3(-1.5f, 1.5f, 1f), Time.deltaTime * 0.033333335f);
			component.volume += Time.deltaTime * 0.01f;
			return;
		}
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, 1f, Time.deltaTime * 10f), base.transform.localPosition.z);
		this.YandereDestination.localPosition = Vector3.MoveTowards(this.YandereDestination.localPosition, new Vector3(-2.271312f, 2f, 3.5f), Time.deltaTime * 10f);
		component.volume = 0f;
	}

	// Token: 0x0400257F RID: 9599
	public Transform YandereDestination;

	// Token: 0x04002580 RID: 9600
	public bool Zoom;
}
