using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseTechCompany : MonoBehaviour
{
	public techInfoStock TechInfoStock;
	public priceChange PriceChange;
	public portfolioStock PortfolioStock;

	public GameObject buttonsScriptsGO;
	public stocksUnlockInfo StocksUnlockInfo;

	public Text divYieldText;
	public Text divPayoutText;
	public Text divShareText;
	public Text divPolicyText;
	public Text priceText;

	public Text EPSText;
	public Text EPSGrowth;
	public Text PEtext;

	public Text GAVtext;

	public Text ownedStocks;

	//[SerializeField] private int activeCompany;
	[SerializeField] 
	private float divPayoutShare;

	public int activeCompany;
	public float activeCompanyPrice;

	void Awake()
	{
		TechInfoStock = GetComponent<techInfoStock> ();
		PriceChange = GetComponent<priceChange> ();
		PortfolioStock = GetComponent<portfolioStock> ();
		StocksUnlockInfo = buttonsScriptsGO.GetComponent<stocksUnlockInfo> ();
	}

	public void companyNumber (int i)
	{
		activeCompany = i;
		divPayoutText.text = "Annual dividend: " + TechInfoStock.divPayout [i];
		divPayoutShare = TechInfoStock.divPayoutShare[i];
		divShareText.text = "Div.Share: " + Mathf.Round(divPayoutShare*100) + "%";

		//Info spelaren måste låsa upp
		//divPolicyText.text = "Start paying out a dividend when EPS reach: " + TechInfoStock.EPSBeforePayingDividend [i] + ". Aims to increase the dividend with: " + TechInfoStock.dividendPayoutIncrease[i] + "% per year.";//TechInfoStock.dividendMaxPayout [i] + "% and aims to increase the dividend with " + ;
		if (StocksUnlockInfo.techEPSGrowthUnlocked [i] == 1) {
			EPSGrowth.text = "EPS Growth: " + TechInfoStock.CompanyMinEPSGrowth [i] + " to " + TechInfoStock.CompanyMaxEPSGrowth [i] + "%/year";
		} else {
			EPSGrowth.text = "EPS Growth: LOCKED. Cost (Time Points): " + TechInfoStock.costUnlockEPSGrowth;
		}


		EPSText.text = "EPS: " + TechInfoStock.EPSNow [i];

		GAVtext.text = "GAV: " + Mathf.Round(PortfolioStock.techGAV [i]*10)/10;

		ownedStocks.text = "Owned: " + PortfolioStock.techCompanySharesOwned [i];
	}

	public void companyOne()
	{
		int i = 0;
		companyNumber (i);

		priceText.text = "Price: " + TechInfoStock.companyOnePriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(TechInfoStock.divPayout[i]/TechInfoStock.companyOnePriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((TechInfoStock.companyOnePriceHist[PriceChange.amountPriceChange]/TechInfoStock.EPSNow [i])*100)/100;

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.techDivPolicyUnlocked [i] == 1) {
		divPolicyText.text = "Maximum payout ratio: " + TechInfoStock.dividendMaxPayout [i] + "%. Aims to increase the dividend with: " + TechInfoStock.dividendPayoutIncrease[i] + "% per year.";
		} else {
			divPolicyText.text = "Div.Policy: LOCKED. Cost (Time Points): " + TechInfoStock.costUnlockDivPolicy;
		}

		activeCompanyPrice = TechInfoStock.companyOnePriceHist[PriceChange.amountPriceChange];
	}

	public void companyTwo()
	{
		int i = 1;
		companyNumber (i);

		priceText.text = "Price: " + TechInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(TechInfoStock.divPayout[1]/TechInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((TechInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange]/TechInfoStock.EPSNow [1])*100)/100;

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.techDivPolicyUnlocked [i] == 1) {
			divPolicyText.text = "Will not pay a dividend. Focus on growth!";// + TechInfoStock.dividendMaxPayout [i] + "%. Aims to increase the dividend with: " + TechInfoStock.dividendPayoutIncrease[i] + "% per year.";
		} else {
			divPolicyText.text = "Div.Policy: LOCKED. Cost (Time Points): " + TechInfoStock.costUnlockDivPolicy;
		}

		activeCompanyPrice = TechInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange];
	}

	public void companyThree()
	{
		int i = 2;
		companyNumber (i);

		priceText.text = "Price: " + TechInfoStock.companyThreePriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(TechInfoStock.divPayout[2]/TechInfoStock.companyThreePriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((TechInfoStock.companyThreePriceHist[PriceChange.amountPriceChange]/TechInfoStock.EPSNow [2])*100)/100;

		activeCompanyPrice = TechInfoStock.companyThreePriceHist[PriceChange.amountPriceChange];
	}


}
