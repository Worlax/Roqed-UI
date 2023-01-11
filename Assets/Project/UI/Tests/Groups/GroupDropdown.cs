using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class GroupDropdown : MonoBehaviour
{
	TMP_Dropdown dropdown;
	List<GroupData> groups = new List<GroupData>();
	List<GroupDropdown> children = new List<GroupDropdown>();

	static string ALL_GROUPS = "All";

	static public event Action<List<GroupData>> OnNewGroupsSelectd;

	GroupData FindGroup(string name) => groups.Find(x => x.Name == name);

	public void Init(List<GroupData> groups)
	{
		dropdown.options.Clear();
		this.groups = groups;
		CloseOptionsList();

		dropdown.options.Add(new TMP_Dropdown.OptionData(ALL_GROUPS));

		foreach (GroupData group in groups)
		{
			dropdown.options.Add(new TMP_Dropdown.OptionData(group.Name));
		}

		dropdown.value = 0;
		dropdown.onValueChanged.AddListener(ValueChanged);
	}

	void CloseOptionsList()
	{
		Transform optionsList = transform.Find("Dropdown List");
		if (optionsList != null) { Destroy(optionsList.gameObject); }
	}

	void CreateChildrenDropdown(List<GroupData> groups)
	{
		GroupDropdown newDropdown = Instantiate(this, transform.parent);
		children.Add(newDropdown);
		newDropdown.Init(groups);
	}

	void DestroyChildren()
	{
		foreach (GroupDropdown dropdown in children)
		{
			dropdown.DestroyChildren();
			Destroy(dropdown.gameObject);
		}

		children.Clear();
	}

	// Unity
	private void Awake()
	{
		dropdown = GetComponent<TMP_Dropdown>();
	}

	// Events
	void ValueChanged(int value)
	{
		DestroyChildren();

		if (dropdown.options[value].text == ALL_GROUPS)
		{
			if (groups[0].Parent != null)
			{
				OnNewGroupsSelectd?.Invoke(new List<GroupData>() { groups[0].Parent });
			}
			else
			{
				OnNewGroupsSelectd?.Invoke(groups);
			}
		}
		else
		{
			GroupData group = FindGroup(dropdown.options[value].text);

			if (group.Children.Count != 0)
			{
				CreateChildrenDropdown(group.Children.ToList());
			}

			OnNewGroupsSelectd?.Invoke(new List<GroupData>() { group });
		}
	}
}