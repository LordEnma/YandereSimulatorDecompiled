using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(UIToggle))]
[AddComponentMenu("NGUI/Interaction/Toggled Components")]
public class UIToggledComponents : MonoBehaviour
{
	public List<MonoBehaviour> activate;

	public List<MonoBehaviour> deactivate;

	[HideInInspector]
	[SerializeField]
	private MonoBehaviour target;

	[HideInInspector]
	[SerializeField]
	private bool inverse;

	private void Awake()
	{
		if (target != null)
		{
			if (activate.Count == 0 && deactivate.Count == 0)
			{
				if (inverse)
				{
					deactivate.Add(target);
				}
				else
				{
					activate.Add(target);
				}
			}
			else
			{
				target = null;
			}
		}
		EventDelegate.Add(GetComponent<UIToggle>().onChange, Toggle);
	}

	public void Toggle()
	{
		if (base.enabled)
		{
			for (int i = 0; i < activate.Count; i++)
			{
				activate[i].enabled = UIToggle.current.value;
			}
			for (int j = 0; j < deactivate.Count; j++)
			{
				deactivate[j].enabled = !UIToggle.current.value;
			}
		}
	}
}
