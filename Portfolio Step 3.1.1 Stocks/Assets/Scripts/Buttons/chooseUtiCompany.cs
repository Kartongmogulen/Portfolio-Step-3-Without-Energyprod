using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseUtiCompany : MonoBehaviour
{
	//public GameObject buttonsScriptGO;
	public utilitiesInfoStock UtilitiesInfoStock;
	public priceChange PriceChange;
	public portfolioStock PortfolioStock;

	public GameObject buttonsScriptsGO;
	public stocksUnlockInfo StocksUnlockInfo;

	public Text divYieldText;
	public Text divPayoutText;
	public Text divUtiShareText;
	public Text divPolicyText;
	public Text priceText;

	public Text EPSText;
	public Text EPSGrowth;
	public Text PEtext;

	public Text GAVtext;

	public Text ownedStocks;

	//[SerializeField] private int activeCompany;
	[SerializeField] private float divPayoutShare;

	public int activeCompany;
	public float activeCompanyPrice;

	void Awake()
	{
		UtilitiesInfoStock = GetComponent<utilitiesInfoStock> ();
		PriceChange = GetComponent<priceChange> ();
		PortfolioStock = GetComponent<portfolioStock> ();
		StocksUnlockInfo = buttonsScriptsGO.GetComponent<stocksUnlockInfo> ();
	}

	void Update (){

		if (activeCompany == 0) {
			companyOne ();
		}

		if (activeCompany == 1) {
			companyTwo ();
		}

	}

	public void companyNumber (int i)
	{
		activeCompany = i;
		divPayoutText.text = "Annual dividend: " + UtilitiesInfoStock.divPayout [i];
		divPayoutShare = UtilitiesInfoStock.divPayoutShare[i];

		divUtiShareText.text = "Div.Share: " + Mathf.Round(divPayoutShare*100) + "%";

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.utiDivPolicyUnlocked [i] == 1) {
			divPolicyText.text = "Maximum payout ratio: " + UtilitiesInfoStock.dividendMaxPayout [i] + "% and aims to increase the dividend with " + UtilitiesInfoStock.dividendPayoutIncrease [i] + "% per year.";
		} else {
			divPolicyText.text = "Div.Policy: LOCKED. Cost (Time Points): " + UtilitiesInfoStock.costUnlockDivPolicy;
		}

		EPSText.text = "EPS: " + Mathf.Round(UtilitiesInfoStock.EPSNow [i]*100)/100;

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.utiEPSGrowthUnlocked [i] == 1) {
			EPSGrowth.text = "EPS Growth: " + UtilitiesInfoStock.utiCompanyMinEPSGrowth [i] + " to " + UtilitiesInfoStock.utiCompanyMaxEPSGrowth [i] + "%/year";
		} else {
			EPSGrowth.text = "EPS Growth: LOCKED. Cost (Time Points): " + UtilitiesInfoStock.costUnlockEPSGrowth;
		}

		Debug.Log ("EPS: " + EPSGrowth.text);

		GAVtext.text = "GAV: " +  Mathf.Round(PortfolioStock.utiGAV [i]*10)/10;

		ownedStocks.text = "Owned: " + PortfolioStock.utiCompanySharesOwned [i];
	}

	public void companyOne()
	{
		companyNumber (0);
		priceText.text = "Price: " + UtilitiesInfoStock.companyOnePriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(UtilitiesInfoStock.divPayout[0]/UtilitiesInfoStock.companyOnePriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((UtilitiesInfoStock.companyOnePriceHist[PriceChange.amountPriceChange]/UtilitiesInfoStock.EPSNow [0])*100)/100;

		activeCompanyPrice = UtilitiesInfoStock.companyOnePriceHist[PriceChange.amountPriceChange];
	}

	public void companyTwo()
	{
		companyNumber (1);
		priceText.text = "Price: " + UtilitiesInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(UtilitiesInfoStock.divPayout[1]/UtilitiesInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((UtilitiesInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange]/UtilitiesInfoStock.EPSNow [1])*100)/100;

		activeCompanyPrice = UtilitiesInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange];
	}

	public void companyThree()
	{
		companyNumber (2);
		priceText.text = "Price: " + UtilitiesInfoStock.companyThreePriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(UtilitiesInfoStock.divPayout[2]/UtilitiesInfoStock.companyThreePriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((UtilitiesInfoStock.companyThreePriceHist[PriceChange.amountPriceChange]/UtilitiesInfoStock.EPSNow [2])*100)/100;

		activeCompanyPrice = UtilitiesInfoStock.companyThreePriceHist[PriceChange.amountPriceChange];
	}
}
