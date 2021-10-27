using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseTechCompany : MonoBehaviour
{
	public techInfoStock TechInfoStock;
	public priceChange PriceChange;
	public portfolioStock PortfolioStock;

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
	}

	public void companyNumber (int i)
	{
		activeCompany = i;
		divPayoutText.text = "Annual dividend: " + Mathf.Round(TechInfoStock.divPayout [i]*100)/100;

		divPayoutShare = TechInfoStock.divPayoutShare[i];

		divShareText.text = "Div.Share: " + Mathf.Round(divPayoutShare*100) + "%";

		divPolicyText.text = "Start paying out a dividend when EPS reach: " + TechInfoStock.EPSBeforePayingDividend [i] + ". Aims to increase the dividend with: " + TechInfoStock.dividendPayoutIncrease[i] + "% per year.";//TechInfoStock.dividendMaxPayout [i] + "% and aims to increase the dividend with " + ;

		EPSText.text = "EPS: " + TechInfoStock.EPSNow [i];

		EPSGrowth.text = "EPS Growth: " + TechInfoStock.CompanyMinEPSGrowth [i] + " to " + TechInfoStock.CompanyMaxEPSGrowth [i] + "%/year";

		GAVtext.text = "GAV: " + Mathf.Round(PortfolioStock.techGAV [i]*10)/10;

		ownedStocks.text = "Owned: " + PortfolioStock.techCompanySharesOwned [i];
	}

	public void companyOne()
	{
		
		companyNumber (0);

		priceText.text = "Price: " + TechInfoStock.companyOnePriceHist[PriceChange.amountPriceChange];
		Debug.Log ("Tech 1");
		divYieldText.text = "Div. yield: " + Mathf.Round(TechInfoStock.divPayout[0]/TechInfoStock.companyOnePriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((TechInfoStock.companyOnePriceHist[PriceChange.amountPriceChange]/TechInfoStock.EPSNow [0])*100)/100;

		activeCompanyPrice = TechInfoStock.companyOnePriceHist[PriceChange.amountPriceChange];
	}

	public void companyTwo()
	{

		companyNumber (1);

		priceText.text = "Price: " + TechInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(TechInfoStock.divPayout[1]/TechInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((TechInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange]/TechInfoStock.EPSNow [1])*100)/100;

		activeCompanyPrice = TechInfoStock.companyTwoPriceHist[PriceChange.amountPriceChange];
	}

	public void companyThree()
	{

		companyNumber (2);

		priceText.text = "Price: " + TechInfoStock.companyThreePriceHist[PriceChange.amountPriceChange];
		divYieldText.text = "Div. yield: " + Mathf.Round(TechInfoStock.divPayout[2]/TechInfoStock.companyThreePriceHist[PriceChange.amountPriceChange]*10000)/100 + "%";
		PEtext.text = "P/E: " + Mathf.Round((TechInfoStock.companyThreePriceHist[PriceChange.amountPriceChange]/TechInfoStock.EPSNow [2])*100)/100;

		activeCompanyPrice = TechInfoStock.companyThreePriceHist[PriceChange.amountPriceChange];
	}
}
