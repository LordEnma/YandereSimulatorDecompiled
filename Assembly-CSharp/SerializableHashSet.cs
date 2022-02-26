using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004AA RID: 1194
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F76 RID: 8054 RVA: 0x001BA564 File Offset: 0x001B8764
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F77 RID: 8055 RVA: 0x001BA578 File Offset: 0x001B8778
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F78 RID: 8056 RVA: 0x001BA5D8 File Offset: 0x001B87D8
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F79 RID: 8057 RVA: 0x001BA614 File Offset: 0x001B8814
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x001BA618 File Offset: 0x001B8818
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001F7B RID: 8059 RVA: 0x001BA67C File Offset: 0x001B887C
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004191 RID: 16785
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004192 RID: 16786
	private const string XML_Element = "Element";
}
