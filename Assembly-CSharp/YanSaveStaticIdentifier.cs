using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040048E2 RID: 18658
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040048E3 RID: 18659
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040048E4 RID: 18660
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
