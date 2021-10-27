using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Kontrollera vilken data spelaren har tillgång till

public class stocksUnlockInfo : MonoBehaviour
{
	public chooseCompany ChooseCompany; 
	public utilitiesInfoStock UtilitiesInfoStock;
	public playerStats PlayerStats;
    
	public int[] utiDivPolicyUnlocked = new int[2];//0 = Spelaren har inte låst upp
	public int[] utiEPSGrowthUnlocked = new int[2];//0 = Spelaren har inte låst upp 

	public int activeSector;
	public int activeCompany;

	public GameObject playerScriptsGO;
	public GameObject scriptsStockGO;

	void Awake(){

		ChooseCompany = GetComponent<chooseCompany> ();
		UtilitiesInfoStock = scriptsStockGO.GetComponent<utilitiesInfoStock> ();
		PlayerStats = playerScriptsGO.GetComponent<playerStats> ();
	}

	public void unlockDivPolicy(){
		activeSector = ChooseCompany.activeSector;
		activeCompany = ChooseCompany.activeCompany;

		if (PlayerStats.RPleft >= UtilitiesInfoStock.costUnlockDivPolicy && utiDivPolicyUnlocked [activeCompany-1] == 0){
			if (activeSector == 1 && activeCompany == 1) {
				utiDivPolicyUnlocked [activeCompany-1] = 1;
				PlayerStats.RPleft--;
				PlayerStats.updateRPtext ();
			}
		}

		if (PlayerStats.RPleft >= UtilitiesInfoStock.costUnlockDivPolicy && utiDivPolicyUnlocked [activeCompany-1] == 0){
			if (activeSector == 1 && activeCompany == 2) {
				utiDivPolicyUnlocked [activeCompany-1] = 1;
				PlayerStats.RPleft--;
				PlayerStats.updateRPtext ();
			}
		}
	}

	public void growthEPS(){
		activeSector = ChooseCompany.activeSector;
		activeCompany = ChooseCompany.activeCompany;

		if (PlayerStats.RPleft >= UtilitiesInfoStock.costUnlockEPSGrowth && utiEPSGrowthUnlocked [activeCompany - 1] == 0) {
			if (activeSector == 1 && activeCompany == 1) {
				utiEPSGrowthUnlocked [activeCompany-1] = 1;
				PlayerStats.RPleft--;
				PlayerStats.updateRPtext ();
			}
		}

		if (PlayerStats.RPleft >= UtilitiesInfoStock.costUnlockEPSGrowth && utiEPSGrowthUnlocked [activeCompany - 1] == 0) {
			if (activeSector == 1 && activeCompany == 2) {
				utiEPSGrowthUnlocked [activeCompany-1] = 1;
				PlayerStats.RPleft--;
				PlayerStats.updateRPtext ();
			}
		}
}
}
