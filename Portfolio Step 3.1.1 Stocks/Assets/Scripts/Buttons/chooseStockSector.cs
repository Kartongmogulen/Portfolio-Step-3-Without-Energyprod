using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseStockSector : MonoBehaviour
{
	bool utiSector;
	bool techSector;

	public int activeSector; //Vilken sektor spelaren har valt. Används av andra script vid t.ex köp.

	public GameObject companyPanelUti;
	public GameObject companyPanelMaterial;
	public GameObject companyPanelTech;

	public void deactivateAll() {
		companyPanelUti.SetActive (false);
		companyPanelTech.SetActive (false);
		companyPanelMaterial.SetActive (false);
		activeSector = 0;
	}

	public void utiSectorSelection(){
		deactivateAll ();
		//companyPanelUti.SetActive (true);
		activeSector = 1;
	}

	public void techSectorSelection(){
		deactivateAll ();
		companyPanelTech.SetActive (true);
		activeSector = 2;
	}

	public void materialSectorSelection(){
		deactivateAll ();
		companyPanelMaterial.SetActive (true);
		activeSector = 3;
	}






}
