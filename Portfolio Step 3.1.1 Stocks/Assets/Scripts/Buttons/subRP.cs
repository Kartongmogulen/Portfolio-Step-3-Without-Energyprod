using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subRP : MonoBehaviour
{
	public int RPleft;

	public int stockRPNow;
	public int bondRPNow;
	public int realEstateRPNow;

	public Text textRPLeft;
	public Text textStockRPThisRound;
	public Text textBondRPThisRound;
	public Text textRealEstateRPThisRound;

	public GameObject playerPanelGO;

	public void subStockRP(){

		RPleft = playerPanelGO.GetComponent<playerStats>().RPleft;
		stockRPNow = playerPanelGO.GetComponent<playerStats>().stockRPNow;

		if (RPleft >= 0 && stockRPNow > 0) {
			RPleft++;
			playerPanelGO.GetComponent<playerStats> ().RPleft++;
			playerPanelGO.GetComponent<playerStats> ().stockRPNow--;
			stockRPNow = playerPanelGO.GetComponent<playerStats> ().stockRPNow;
			textStockRPThisRound.text = "Stock: " + stockRPNow;
			textRPLeft.text = "RP left: " + RPleft;
		}
	}

	public void subBondRP(){

		RPleft = playerPanelGO.GetComponent<playerStats>().RPleft;
		bondRPNow = playerPanelGO.GetComponent<playerStats>().bondRPNow;

		if (RPleft >= 0 && bondRPNow > 0) {
			RPleft++;
			playerPanelGO.GetComponent<playerStats> ().RPleft++;
			playerPanelGO.GetComponent<playerStats> ().bondRPNow--;
			bondRPNow = playerPanelGO.GetComponent<playerStats> ().bondRPNow;
			textBondRPThisRound.text = "Bond: " + bondRPNow;
			textRPLeft.text = "RP left: " + RPleft;
		}
	}

	public void subRealEstateRP(){

		RPleft = playerPanelGO.GetComponent<playerStats>().RPleft;
		realEstateRPNow = playerPanelGO.GetComponent<playerStats>().realEstateRPNow;

		if (RPleft >= 0 && realEstateRPNow > 0) {
			RPleft++;
			playerPanelGO.GetComponent<playerStats> ().RPleft++;
			playerPanelGO.GetComponent<playerStats> ().realEstateRPNow--;
			realEstateRPNow = playerPanelGO.GetComponent<playerStats> ().realEstateRPNow;
			textRealEstateRPThisRound.text = "RE: " + realEstateRPNow;
			textRPLeft.text = "RP left: " + RPleft;
		}
	}
}
