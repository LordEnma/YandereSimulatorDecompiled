using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000069 RID: 105
[AddComponentMenu("NGUI/Interaction/Toggled Objects")]
public class UIToggledObjects : MonoBehaviour
{
	// Token: 0x060002DE RID: 734 RVA: 0x0001EDB8 File Offset: 0x0001CFB8
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

	// Token: 0x060002DF RID: 735 RVA: 0x0001EE40 File Offset: 0x0001D040
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

	// Token: 0x060002E0 RID: 736 RVA: 0x0001EEB5 File Offset: 0x0001D0B5
	private void Set(GameObject go, bool state)
	{
		if (go != null)
		{
			NGUITools.SetActive(go, state);
		}
	}

	// Token: 0x04000463 RID: 1123
	public List<GameObject> activate;

	// Token: 0x04000464 RID: 1124
	public List<GameObject> deactivate;

	// Token: 0x04000465 RID: 1125
	[HideInInspector]
	[SerializeField]
	private GameObject target;

	// Token: 0x04000466 RID: 1126
	[HideInInspector]
	[SerializeField]
	private bool inverse;
}
