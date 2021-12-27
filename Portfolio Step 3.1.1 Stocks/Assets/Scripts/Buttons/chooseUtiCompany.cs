using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseUtiCompany : MonoBehaviour
{
	public GameObject stockMarketGO;
	public GameObject playerScriptsGO;
	public stockMarketManager StockMarketManager;

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

		StockMarketManager = stockMarketGO.GetComponent<stockMarketManager>();

		UtilitiesInfoStock = GetComponent<utilitiesInfoStock> ();
		PriceChange = GetComponent<priceChange> ();
		PortfolioStock = playerScriptsGO.GetComponent<portfolioStock> ();
		StocksUnlockInfo = buttonsScriptsGO.GetComponent<stocksUnlockInfo> ();
	}

	/*void Update (){

		if (activeCompany == 0) {
			companyOne ();
		}

		if (activeCompany == 1) {
			companyTwo ();
		}

	}*/

	public void companyNumber (int i)
	{
		activeCompany = i;
		
		divYieldText.text = "Div. yield: " + Mathf.Round(StockMarketManager.StockUtiList[i].divPayout / StockMarketManager.StockUtiList[i].StockPrice[StockMarketManager.StockUtiList[i].StockPrice.Count-1] * 10000)/100 + "%";

		divPayoutText.text = "Annual dividend: " + StockMarketManager.StockUtiList[i].divPayout;
		divPayoutShare = StockMarketManager.StockUtiList[i].divPayout/ StockMarketManager.StockUtiList[i].EPSnow;

		divUtiShareText.text = "Div.Share: " + Mathf.Round(divPayoutShare*100) + "%";

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.utiDivPolicyUnlocked [i] == 1) {
			divPolicyText.text = "Maximum payout ratio: " + StockMarketManager.StockUtiList[i].divPolicyMaxPayouRatio + "% and aims to increase the dividend with " + StockMarketManager.StockUtiList[i].divPolicyChangeDiv + "% per year.";
		} else {
			divPolicyText.text = "Div.Policy: LOCKED. Cost (Time Points): " + UtilitiesInfoStock.costUnlockDivPolicy;
		}

		EPSText.text = "EPS: " + Mathf.Round(StockMarketManager.StockUtiList[i].EPSnow * 100)/100;

		//Info spelaren måste låsa upp
		if (StocksUnlockInfo.utiEPSGrowthUnlocked [i] == 1) {
			EPSGrowth.text = "EPS Growth: " + StockMarketManager.StockUtiList[i].EPSGrowthMin + " to " + StockMarketManager.StockUtiList[i].EPSGrowthMax + "%/year";
		} else {
			EPSGrowth.text = "EPS Growth: LOCKED. Cost (Time Points): " + UtilitiesInfoStock.costUnlockEPSGrowth;
		}

		GAVtext.text = "GAV: " +  Mathf.Round(PortfolioStock.utiGAV [i]*10)/10;

		ownedStocks.text = "Owned: " + PortfolioStock.utiCompanySharesOwned [i];

		activeCompanyPrice = StockMarketManager.StockUtiList[i].StockPrice[StockMarketManager.StockUtiList[i].StockPrice.Count - 1];
		priceText.text = "Price: " + activeCompanyPrice;
	}

	public void companyOne()
	{
		companyNumber (0);
	}

	public void companyTwo()
	{
		companyNumber (1);
	}

	public void companyThree()
	{
		companyNumber (2);
	}

}
