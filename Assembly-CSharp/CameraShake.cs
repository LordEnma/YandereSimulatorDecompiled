using System;
using UnityEngine;

// Token: 0x02000235 RID: 565
public class CameraShake : MonoBehaviour
{
	// Token: 0x06001228 RID: 4648 RVA: 0x0008B7BE File Offset: 0x000899BE
	private void Awake()
	{
		if (this.camTransform == null)
		{
			this.camTransform = base.GetComponent<Transform>();
		}
	}

	// Token: 0x06001229 RID: 4649 RVA: 0x0008B7DA File Offset: 0x000899DA
	private void OnEnable()
	{
		this.originalPos = this.camTransform.localPosition;
	}

	// Token: 0x0600122A RID: 4650 RVA: 0x0008B7F0 File Offset: 0x000899F0
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

	// Token: 0x040016DC RID: 5852
	public Transform camTransform;

	// Token: 0x040016DD RID: 5853
	public float shake;

	// Token: 0x040016DE RID: 5854
	public float shakeAmount = 0.7f;

	// Token: 0x040016DF RID: 5855
	public float decreaseFactor = 1f;

	// Token: 0x040016E0 RID: 5856
	private Vector3 originalPos;
}
