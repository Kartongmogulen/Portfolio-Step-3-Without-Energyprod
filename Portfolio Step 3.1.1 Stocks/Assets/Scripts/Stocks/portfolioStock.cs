using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portfolioStock : MonoBehaviour
{

	public List<float> utiCompanySharesOwned = new List<float> ();
	public List<float> techCompanySharesOwned = new List<float> ();
	public List<float> materialsCompanySharesOwned = new List<float> ();

	public float totalValuePortfolio;
	public float totalInvestAmountPortfolio;
	public float totalReturnPortfolio;
	public float totalValueUti;
	public float totalValueTech;

	public float[] utiTotalInvest; //Summan som har investerats i specifikt företag
	public float utiTotalInvestAmount;
	public float[] utiGAV; 
	public float utiTotalReturn;

	public float[] techTotalInvest; //Summan som har investerats i specifikt företag
	public float techTotalInvestAmount;
	public float[] techGAV; 
	public float techTotalReturn;

	public float[] materialsTotalInvest; //Summan som har investerats i specifikt företag
	public float materialsTotalInvestAmount;
	public float[] materialsGAV; 
	public float materialsTotalReturn;

	public float[] returnUti;
	public float[] returnTech;

	public priceChange PriceChange;

	public Text valuePortfolioText;
	public Text returnPortfolioText;

	void Awake(){
		PriceChange = GetComponent<priceChange> ();
	}

	public void addUtiShares(int shares, int activeCompany){
		utiCompanySharesOwned [activeCompany] += shares;

	}

	public void sellUtiShares(int shares, int activeCompany){
		utiCompanySharesOwned [activeCompany] -= shares;

	}

	public void addTechShares(int shares, int activeCompany){
		techCompanySharesOwned [activeCompany] += shares;

	}

	public void sellTechShares(int shares, int activeCompany){
		techCompanySharesOwned [activeCompany] -= shares;

	}

	public void addMaterialShares(int shares, int activeCompany){
		materialsCompanySharesOwned [activeCompany] += shares;

	}

	public void sellMaterialShares(int shares, int activeCompany){
		materialsCompanySharesOwned [activeCompany] -= shares;

	}

	void GAV(){

		for (int i = 0; i < utiGAV.Length; i++) {
			if (utiCompanySharesOwned [i] == 0) {
				utiGAV [i] = 0;
				utiTotalInvest [i] = 0;
			} else {
				utiGAV [i] = utiTotalInvest [i] / utiCompanySharesOwned [i];
			}
		}

		for (int i = 0; i < techGAV.Length; i++) {
			if (techCompanySharesOwned [i] == 0) {
				techGAV [i] = 0;
				techTotalInvest [i] = 0;
			} else {

				techGAV [i] = techTotalInvest [i] / techCompanySharesOwned [i];
			}
		}

		for (int i = 0; i < materialsGAV.Length; i++) {
			if (materialsCompanySharesOwned [i] == 0) {
				materialsGAV [i] = 0;
				materialsTotalInvest [i] = 0;
			} else {

				materialsGAV [i] = materialsTotalInvest [i] / materialsCompanySharesOwned [i];
			}
		}
	}

	public void returnPortfolio(){

		valuePortfolio ();

		utiTotalInvestAmount = 0;
		techTotalInvestAmount = 0;

		//Avkastning per företag
		for (int i = 0; i < returnUti.Length; i++) {
			returnUti[i] = (utiCompanySharesOwned [i]*PriceChange.priceNowUti[i])/utiTotalInvest [i];
		}

		for (int i = 0; i < returnTech.Length; i++) {
			returnTech[i] = (techCompanySharesOwned [i]*PriceChange.priceNowTech[i])/techTotalInvest [i];
		}

		//Total investering i sektorn
		for (int i = 0; i < utiTotalInvest.Length; i++) {
			utiTotalInvestAmount = utiTotalInvestAmount + utiGAV [i]*utiCompanySharesOwned [i];
		}

		for (int i = 0; i < techTotalInvest.Length; i++) {
			techTotalInvestAmount = techTotalInvestAmount + techGAV [i]*techCompanySharesOwned [i];
		}

		//Total avkastning i sektorn
		for (int i = 0; i < returnUti.Length; i++) {
			utiTotalReturn = totalValueUti/utiTotalInvestAmount-1;
		}

		for (int i = 0; i < returnTech.Length; i++) {
			techTotalReturn = totalValueTech/techTotalInvestAmount-1;
		}
	
		totalInvestAmountPortfolio = utiTotalInvestAmount + techTotalInvestAmount;
		totalReturnPortfolio = totalValuePortfolio / totalInvestAmountPortfolio-1;
		returnPortfolioText.text = "Return Portfolio: " + Mathf.Round(totalReturnPortfolio*100) + "%";
	}

	public void valuePortfolio(){

		totalValueUti = 0;

		for (int i = 0; i < utiCompanySharesOwned.Count; i++) {
			totalValueUti += PriceChange.priceNowUti [i] * utiCompanySharesOwned [i];
		}

		totalValueTech = 0;

		for (int i = 0; i < techCompanySharesOwned.Count; i++) {
			totalValueTech += PriceChange.priceNowTech [i] * techCompanySharesOwned [i];
		}

		totalValuePortfolio = totalValueUti + totalValueTech;

		valuePortfolioText.text = "Value: " + totalValuePortfolio;

		GAV ();
	}


}
