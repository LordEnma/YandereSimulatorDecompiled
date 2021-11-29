using System;
using UnityEngine;

// Token: 0x02000234 RID: 564
public class CameraShake : MonoBehaviour
{
	// Token: 0x06001222 RID: 4642 RVA: 0x0008AE52 File Offset: 0x00089052
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = base.GetComponent<Transform>();
		}
	}

	// Token: 0x06001223 RID: 4643 RVA: 0x0008AE6E File Offset: 0x0008906E
	private void OnEnable()
	{
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x06001224 RID: 4644 RVA: 0x0008AE84 File Offset: 0x00089084
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

	// Token: 0x040016C5 RID: 5829
	public Transform camTransform;

	// Token: 0x040016C6 RID: 5830
	public float shake;

	// Token: 0x040016C7 RID: 5831
	public float shakeAmount = 0.7f;

	// Token: 0x040016C8 RID: 5832
	public float decreaseFactor = 1f;

	// Token: 0x040016C9 RID: 5833
	private Vector3 originalPos;
}
