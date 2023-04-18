using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownHandler2: MonoBehaviour
{

	public Dropdown Option;
	public static int sendercopy2;
	public void Start()
	{
		Option.onValueChanged.AddListener(delegate 
		{
			OptionValueChangeHappened(Option);
		});
	}
	public void OptionValueChangeHappened(Dropdown sender2)
	{
		sendercopy2=sender2.value;
	Debug.Log("You have selected :"+sender2.value);
	}
}