using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStockPortfolio : MonoBehaviour
{
	public GameObject portfolioPanelGO;
	public GameObject sectorInfoPanelGO;

	private int portfolioPanelStatus;


	public void activatePortPanel(){

		if (portfolioPanelStatus == 0){

		portfolioPanelGO.SetActive (true);
		sectorInfoPanelGO.SetActive (false);
		portfolioPanelStatus = 1;
		}

		else {
			portfolioPanelGO.SetActive (false);
			//sectorInfoPanelGO.SetActive (false);
			portfolioPanelStatus = 0;

		}
	}
}
