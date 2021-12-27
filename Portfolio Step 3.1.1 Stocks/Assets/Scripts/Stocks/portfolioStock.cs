using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portfolioStock : MonoBehaviour
{
	//Lista där antal aktier i specifik sector sparas
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
	public float utiTotalValue;

	public float[] techTotalInvest; //Summan som har investerats i specifikt företag
	public float techTotalInvestAmount;
	public float[] techGAV; 
	public float techTotalReturn;
	public float techTotalValue;

	public float[] materialsTotalInvest; //Summan som har investerats i specifikt företag
	public float materialsTotalInvestAmount;
	public float[] materialsGAV; 
	public float materialsTotalReturn;

	public float[] returnUti;
	public float[] returnTech;

	//UTDELNINGAR
	public float totalDivIncome;
	public float divUtiCompanyOne;
	public float divUtiCompanyTwo;
	public float divTechCompanyOne;
	public float divTechCompanyTwo;

	//ANDEL PORTFÖLJ
	public float utiSharePortfolio;
	public Text utiSharePortfolioText;
	public float techSharePortfolio;
	public Text techSharePortfolioText;

	//SEKTORNS AVKASTNING
	public Text utiReturnText;
	public Text techReturnText;


	public priceChange PriceChange;

	public Text valuePortfolioText;
	public Text returnPortfolioText;
	public Text dividendPerYearText;

	public utilitiesInfoStock UtilitiesInfoStock;
	public techInfoStock TechInfoStock;

	void Awake(){
		
		PriceChange = GetComponent<priceChange> ();
		UtilitiesInfoStock = GetComponent<utilitiesInfoStock> ();
		TechInfoStock = GetComponent<techInfoStock> ();
	}

	void Update(){
		//dividendIncome ();
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

	public void dividendIncome(){

		divUtiCompanyOne = utiCompanySharesOwned [0] * UtilitiesInfoStock.divPayout [0];
		divUtiCompanyTwo = utiCompanySharesOwned [1] * UtilitiesInfoStock.divPayout [1];

		divTechCompanyOne = techCompanySharesOwned [0] * TechInfoStock.divPayout [0];
		divTechCompanyTwo = techCompanySharesOwned [1] * TechInfoStock.divPayout [1]; 

		totalDivIncome = divUtiCompanyOne + divUtiCompanyTwo;
		dividendPerYearText.text = "Div./Year: " + totalDivIncome;
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
		dividendIncome ();
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

	public void showPortfolioData(){

		returnPortfolio ();

		utiSharePortfolio = 0;
		techSharePortfolio = 0;
		utiTotalValue = 0;
		techTotalValue = 0;

		//SEKTORNS ANDEL AV PORTFÖLJEN
		for (int i = 0; i < returnUti.Length; i++) {
			utiTotalValue = (utiCompanySharesOwned [i]*PriceChange.priceNowUti[i]);
			utiSharePortfolio += utiTotalValue;
			Debug.Log ("UtiShare: " + utiSharePortfolio);
		}

		for (int i = 0; i < returnTech.Length; i++) {
			techTotalValue = (techCompanySharesOwned [i]*PriceChange.priceNowTech[i]);
			techSharePortfolio += techTotalValue;
			Debug.Log ("TechShare: " + techSharePortfolio);
		}
			
		utiSharePortfolioText.text = " " + Mathf.Round((utiSharePortfolio*100 / totalValuePortfolio)*100)/100 + "%";
		techSharePortfolioText.text = " " + Mathf.Round((techSharePortfolio*100 / totalValuePortfolio)*100)/100 + "%";

		//SEKTORNS AVKASTNING
		returnPortfolio();
		utiReturnText.text = " " + Mathf.Round(utiTotalReturn*10000)/100 + "%";
		techReturnText.text = " " + Mathf.Round(techTotalReturn*10000)/100 + "%";
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
