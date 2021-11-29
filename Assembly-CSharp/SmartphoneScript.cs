using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class SmartphoneScript : MonoBehaviour
{
	// Token: 0x06001C98 RID: 7320 RVA: 0x0015126C File Offset: 0x0014F46C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Dragging || this.Prompt.Yandere.Carrying)
			{
				this.Prompt.Yandere.EmptyHands();
			}
			this.Prompt.Yandere.CrushingPhone = true;
			this.Prompt.Yandere.PhoneToCrush = this;
			this.Prompt.Yandere.CanMove = false;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
			this.PhoneCrushingSpot = gameObject.transform;
			this.PhoneCrushingSpot.position = new Vector3(this.PhoneCrushingSpot.position.x, this.Prompt.Yandere.transform.position.y, this.PhoneCrushingSpot.position.z);
			this.PhoneCrushingSpot.LookAt(this.Prompt.Yandere.transform.position);
			this.PhoneCrushingSpot.Translate(Vector3.forward * 0.5f);
		}
	}

	// Token: 0x04003334 RID: 13108
	public Transform PhoneCrushingSpot;

	// Token: 0x04003335 RID: 13109
	public GameObject EmptyGameObject;

	// Token: 0x04003336 RID: 13110
	public Texture SmashedTexture;

	// Token: 0x04003337 RID: 13111
	public GameObject PhoneSmash;

	// Token: 0x04003338 RID: 13112
	public Renderer MyRenderer;

	// Token: 0x04003339 RID: 13113
	public PromptScript Prompt;

	// Token: 0x0400333A RID: 13114
	public MeshFilter MyMesh;

	// Token: 0x0400333B RID: 13115
	public Mesh SmashedMesh;
}
