using System;
using UnityEngine;

// Token: 0x02000235 RID: 565
public class CameraShake : MonoBehaviour
{
	// Token: 0x06001226 RID: 4646 RVA: 0x0008B3F6 File Offset: 0x000895F6
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = base.GetComponent<Transform>();
		}
	}

	// Token: 0x06001227 RID: 4647 RVA: 0x0008B412 File Offset: 0x00089612
	private void OnEnable()
	{
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x06001228 RID: 4648 RVA: 0x0008B428 File Offset: 0x00089628
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

	// Token: 0x040016D6 RID: 5846
	public Transform camTransform;

	// Token: 0x040016D7 RID: 5847
	public float shake;

	// Token: 0x040016D8 RID: 5848
	public float shakeAmount = 0.7f;

	// Token: 0x040016D9 RID: 5849
	public float decreaseFactor = 1f;

	// Token: 0x040016DA RID: 5850
	private Vector3 originalPos;
}
