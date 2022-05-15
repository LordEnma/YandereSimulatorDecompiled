using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C37 RID: 7223 RVA: 0x0014A757 File Offset: 0x00148957
	public static EventSaveData ReadFromGlobals()
	{
		return new EventSaveData
		{
			befriendConversation = EventGlobals.BefriendConversation,
			event1 = EventGlobals.Event1,
			event2 = EventGlobals.Event2,
			kidnapConversation = EventGlobals.KidnapConversation,
			livingRoom = EventGlobals.LivingRoom
		};
	}

	// Token: 0x06001C38 RID: 7224 RVA: 0x0014A795 File Offset: 0x00148995
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x040031BA RID: 12730
	public bool befriendConversation;

	// Token: 0x040031BB RID: 12731
	public bool event1;

	// Token: 0x040031BC RID: 12732
	public bool event2;

	// Token: 0x040031BD RID: 12733
	public bool kidnapConversation;

	// Token: 0x040031BE RID: 12734
	public bool livingRoom;
}
