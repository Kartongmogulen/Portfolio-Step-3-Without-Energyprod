using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseCompany : MonoBehaviour
{
	public chooseStockSector ChooseStockSector;
	public GameObject ScriptsGO;
	public chooseUtiCompany ChooseUtiCompany;

	public int activeSector;
	public int activeCompany;

	//Kontrollerar vilken sektor som är aktiv och sedan vilket bolag inom sektorn som väljs

	void Awake(){
		ChooseStockSector = GetComponent<chooseStockSector>();
		ChooseUtiCompany = ScriptsGO.GetComponent<chooseUtiCompany>();
	}

	public void chosenCompanyOne(){
		activeSector = ChooseStockSector.activeSector;

		if (activeSector == 1) {
			ChooseUtiCompany.companyOne ();
			activeCompany = 1;
		}
	}

	public void chosenCompanyTwo(){
		activeSector = ChooseStockSector.activeSector;

		if (activeSector == 1) {
			ChooseUtiCompany.companyTwo ();
			activeCompany = 2;
		}
	}

}
