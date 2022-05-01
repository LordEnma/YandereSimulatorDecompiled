using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000069 RID: 105
[AddComponentMenu("NGUI/Interaction/Toggled Objects")]
public class UIToggledObjects : MonoBehaviour
{
	// Token: 0x060002DE RID: 734 RVA: 0x0001F0A0 File Offset: 0x0001D2A0
	private void Awake()
	{
		if (this.target != null)
		{
			if (this.activate.Count == 0 && this.deactivate.Count == 0)
			{
				if (this.inverse)
				{
					this.deactivate.Add(this.target);
				}
				else
				{
					this.activate.Add(this.target);
				}
			}
			else
			{
				this.target = null;
			}
		}
		EventDelegate.Add(base.GetComponent<UIToggle>().onChange, new EventDelegate.Callback(this.Toggle));
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0001F128 File Offset: 0x0001D328
	public void Toggle()
	{
		bool value = UIToggle.current.value;
		if (base.enabled)
		{
			for (int i = 0; i < this.activate.Count; i++)
			{
				this.Set(this.activate[i], value);
			}
			for (int j = 0; j < this.deactivate.Count; j++)
			{
				this.Set(this.deactivate[j], !value);
			}
		}
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0001F19D File Offset: 0x0001D39D
	private void Set(GameObject go, bool state)
	{
		if (go != null)
		{
			NGUITools.SetActive(go, state);
		}
	}

	// Token: 0x04000470 RID: 1136
	public List<GameObject> activate;

	// Token: 0x04000471 RID: 1137
	public List<GameObject> deactivate;

	// Token: 0x04000472 RID: 1138
	[HideInInspector]
	[SerializeField]
	private GameObject target;

	// Token: 0x04000473 RID: 1139
	[HideInInspector]
	[SerializeField]
	private bool inverse;
}
