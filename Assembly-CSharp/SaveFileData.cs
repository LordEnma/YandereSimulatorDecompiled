using System;
using System.Xml.Serialization;

// Token: 0x0200040F RID: 1039
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x0400321A RID: 12826
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x0400321B RID: 12827
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x0400321C RID: 12828
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x0400321D RID: 12829
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x0400321E RID: 12830
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x0400321F RID: 12831
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x04003220 RID: 12832
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x04003221 RID: 12833
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x04003222 RID: 12834
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x04003223 RID: 12835
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x04003224 RID: 12836
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x04003225 RID: 12837
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x04003226 RID: 12838
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x04003227 RID: 12839
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x04003228 RID: 12840
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x04003229 RID: 12841
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x0400322A RID: 12842
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x0400322B RID: 12843
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x0400322C RID: 12844
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x0400322D RID: 12845
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x0400322E RID: 12846
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
