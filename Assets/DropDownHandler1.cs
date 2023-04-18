using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownHandler1: MonoBehaviour
{

	public Dropdown Option;
	public static int sendercopy1;
	public void Start()
	{
		Option.onValueChanged.AddListener(delegate 
		{
			OptionValueChangeHappened(Option);
		});
	}
	public void OptionValueChangeHappened(Dropdown sender1)
	{
		sendercopy1=sender1.value;
		Debug.Log("You have selected :"+sender1.value);
	}
}