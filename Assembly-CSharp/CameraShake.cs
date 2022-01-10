using System;
using UnityEngine;

// Token: 0x02000235 RID: 565
public class CameraShake : MonoBehaviour
{
	// Token: 0x06001225 RID: 4645 RVA: 0x0008AFFA File Offset: 0x000891FA
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = base.GetComponent<Transform>();
		}
	}

	// Token: 0x06001226 RID: 4646 RVA: 0x0008B016 File Offset: 0x00089216
	private void OnEnable()
	{
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x06001227 RID: 4647 RVA: 0x0008B02C File Offset: 0x0008922C
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

	// Token: 0x040016C7 RID: 5831
	public Transform camTransform;

	// Token: 0x040016C8 RID: 5832
	public float shake;

	// Token: 0x040016C9 RID: 5833
	public float shakeAmount = 0.7f;

	// Token: 0x040016CA RID: 5834
	public float decreaseFactor = 1f;

	// Token: 0x040016CB RID: 5835
	private Vector3 originalPos;
}
