using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x0400498B RID: 18827
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x0400498C RID: 18828
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x0400498D RID: 18829
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
