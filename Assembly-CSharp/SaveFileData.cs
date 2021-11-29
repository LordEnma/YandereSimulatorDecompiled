using System;
using System.Xml.Serialization;

// Token: 0x02000403 RID: 1027
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x0400313E RID: 12606
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x0400313F RID: 12607
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x04003140 RID: 12608
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x04003141 RID: 12609
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x04003142 RID: 12610
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x04003143 RID: 12611
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x04003144 RID: 12612
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x04003145 RID: 12613
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x04003146 RID: 12614
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x04003147 RID: 12615
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x04003148 RID: 12616
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x04003149 RID: 12617
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x0400314A RID: 12618
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x0400314B RID: 12619
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x0400314C RID: 12620
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x0400314D RID: 12621
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x0400314E RID: 12622
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x0400314F RID: 12623
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x04003150 RID: 12624
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x04003151 RID: 12625
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x04003152 RID: 12626
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
