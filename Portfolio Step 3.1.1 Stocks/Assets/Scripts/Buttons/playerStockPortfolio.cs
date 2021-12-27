using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStockPortfolio : MonoBehaviour
{
	public GameObject portfolioPanelGO;
	public GameObject ScriptsGO;
	//public GameObject sectorInfoPanelGO;

	public portfolioStock PortfolioStock;

	private int portfolioPanelStatus;

	void Awake(){
		PortfolioStock = ScriptsGO.GetComponent<portfolioStock> ();
	}

	public void activatePortPanel(){

		if (portfolioPanelStatus == 0){

		portfolioPanelGO.SetActive (true);
		//sectorInfoPanelGO.SetActive (false);
		portfolioPanelStatus = 1;

		PortfolioStock.showPortfolioData ();
		}

		else {
			portfolioPanelGO.SetActive (false);
			//sectorInfoPanelGO.SetActive (false);
			portfolioPanelStatus = 0;

		}
	}
}
