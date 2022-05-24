using System;
using UnityEngine;

// Token: 0x02000236 RID: 566
public class CameraShake : MonoBehaviour
{
	// Token: 0x0600122A RID: 4650 RVA: 0x0008BE22 File Offset: 0x0008A022
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = base.GetComponent<Transform>();
		}
	}

	// Token: 0x0600122B RID: 4651 RVA: 0x0008BE3E File Offset: 0x0008A03E
	private void OnEnable()
	{
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x0600122C RID: 4652 RVA: 0x0008BE54 File Offset: 0x0008A054
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

	// Token: 0x040016E6 RID: 5862
	public Transform camTransform;

	// Token: 0x040016E7 RID: 5863
	public float shake;

	// Token: 0x040016E8 RID: 5864
	public float shakeAmount = 0.7f;

	// Token: 0x040016E9 RID: 5865
	public float decreaseFactor = 1f;

	// Token: 0x040016EA RID: 5866
	private Vector3 originalPos;
}
