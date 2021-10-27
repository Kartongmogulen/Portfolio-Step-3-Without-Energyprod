using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script för vilken data som ska visas då Sector samt Föreatag har valts

public class chooseDataToShow : MonoBehaviour
{
    
	public GameObject divDataGO;
	public GameObject keyMetricGO;
	public GameObject week52PanelGO;

	private int dataToShowInt;

	public void divDataShow(){

		dataToShowInt = 0;
		divDataGO.SetActive (true);
		deactivatedOther ();
	}

	public void keyMetricShow()
	{
		dataToShowInt = 1;
		keyMetricGO.SetActive (true);
		week52PanelGO.SetActive (true);
		deactivatedOther ();
	}

	public void deactivatedOther()
	{
		if (dataToShowInt == 0) 
		{
			keyMetricGO.SetActive (false);
			week52PanelGO.SetActive (false);
		}

		if (dataToShowInt == 1) 
		{
			divDataGO.SetActive (false);
		}


	}


}
