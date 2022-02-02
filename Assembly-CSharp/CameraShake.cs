using System;
using UnityEngine;

// Token: 0x02000235 RID: 565
public class CameraShake : MonoBehaviour
{
	// Token: 0x06001225 RID: 4645 RVA: 0x0008B036 File Offset: 0x00089236
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = base.GetComponent<Transform>();
		}
	}

	// Token: 0x06001226 RID: 4646 RVA: 0x0008B052 File Offset: 0x00089252
	private void OnEnable()
	{
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x06001227 RID: 4647 RVA: 0x0008B068 File Offset: 0x00089268
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

	// Token: 0x040016C9 RID: 5833
	public Transform camTransform;

	// Token: 0x040016CA RID: 5834
	public float shake;

	// Token: 0x040016CB RID: 5835
	public float shakeAmount = 0.7f;

	// Token: 0x040016CC RID: 5836
	public float decreaseFactor = 1f;

	// Token: 0x040016CD RID: 5837
	private Vector3 originalPos;
}
