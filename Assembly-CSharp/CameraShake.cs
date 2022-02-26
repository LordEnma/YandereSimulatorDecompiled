using System;
using UnityEngine;

// Token: 0x02000235 RID: 565
public class CameraShake : MonoBehaviour
{
	// Token: 0x06001226 RID: 4646 RVA: 0x0008B2AE File Offset: 0x000894AE
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = base.GetComponent<Transform>();
		}
	}

	// Token: 0x06001227 RID: 4647 RVA: 0x0008B2CA File Offset: 0x000894CA
	private void OnEnable()
	{
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x06001228 RID: 4648 RVA: 0x0008B2E0 File Offset: 0x000894E0
	private void Update()
	{
		if (this.shake > 0f)
		{
			this.camTransform.localPosition = this.originalPos + UnityEngine.Random.insideUnitSphere * this.shakeAmount;
			this.shake -= 0.016666668f * this.decreaseFactor;
			return;
		}
		this.shake = 0f;
		this.camTransform.localPosition = this.originalPos;
	}

	// Token: 0x040016CD RID: 5837
	public Transform camTransform;

	// Token: 0x040016CE RID: 5838
	public float shake;

	// Token: 0x040016CF RID: 5839
	public float shakeAmount = 0.7f;

	// Token: 0x040016D0 RID: 5840
	public float decreaseFactor = 1f;

	// Token: 0x040016D1 RID: 5841
	private Vector3 originalPos;
}
