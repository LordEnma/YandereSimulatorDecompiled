using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040048F3 RID: 18675
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040048F4 RID: 18676
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040048F5 RID: 18677
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
