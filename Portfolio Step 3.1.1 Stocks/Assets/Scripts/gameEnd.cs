using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameEnd : MonoBehaviour
{
	public GameObject MainCanvasGO;
	public GameObject endGamePanel;
	public GameObject PlayerPanelGO;
	public GameObject SectorPanelGO;
	public GameObject bottomPanelGO;
	public GameObject realEstatePanelGO;
	public GameObject bondsPanelGO;

	public Text textEndGame;
	public Text incomeWorkText;
	public Text incomeDivText;
	public Text incomeDivPerYear;
	public Text assetsValueText;
	public Text incomeBondsLifetimeText;
	public Text capGainStockText;
	public Text totalReturnAssets;

	public float incomeDuringLifeWork;
	public float incomeDuringLifeDividend;
	public float incomeDividendRestOfLifePerYear;

	public float utiAmount;
	public float finAmount;
	public float techAmount;

	public float utiDiv;
	public float finDiv;
	public float techDiv;

	public float divPerYear;

	public float incomeBondsLifetime;

	public float incomeRentLifetime;

	public float assetsValue;
	public float stockPortfolioValue;
	public float bondPortfolioValue;
	public float realestateValue;
	public float capGainStock;
	public float totBusinessValue;

	public float stocksInvestmentTotAmount;
	public float bondsInvestmentTotAmount;
	public float realEstateInvestmentTotAmount;
	public float businessInvestmentTotAmount;
	public float totalInvestAssets;

	public void endOfGame()
    {
		//Income
		incomeDuringLifeWork = PlayerPanelGO.GetComponent<incomeWork>().incomeWorkLife;
		incomeDuringLifeDividend = PlayerPanelGO.GetComponent<totalCash>().incomeTotDivNow;


		utiAmount = PlayerPanelGO.GetComponent<portfolio>().utiAmount;
		finAmount = PlayerPanelGO.GetComponent<portfolio>().finAmount;
		techAmount = PlayerPanelGO.GetComponent<portfolio>().techAmount;

		utiDiv = MainCanvasGO.GetComponent<infoStockSector>().divUtiNow;
		finDiv = MainCanvasGO.GetComponent<infoStockSector>().divFinNow;
		techDiv = MainCanvasGO.GetComponent<infoStockSector>().divTechNow;

		divPerYear = utiAmount*utiDiv + finAmount*finDiv + techAmount*techDiv;

		//Value assets
		stockPortfolioValue = PlayerPanelGO.GetComponent<portfolio>().portfolioValue;
		bondPortfolioValue = PlayerPanelGO.GetComponent<bondsPortfolio>().totalValueBonds;
		realEstatePanelGO.GetComponent<buyRealEstate>().valueRealEstate();
		realestateValue = realEstatePanelGO.GetComponent<buyRealEstate>().valueRE;
		totBusinessValue  = PlayerPanelGO.GetComponent<ownedBusiness>().totValueBusiness;
			
		assetsValue = stockPortfolioValue+bondPortfolioValue+realestateValue+totBusinessValue;

		//Update text
		endGamePanel.SetActive (true);
		realEstatePanelGO.SetActive (false);
		bondsPanelGO.SetActive (false);
		SectorPanelGO.SetActive (false);

		totalReturn ();

		textEndGame.text = "The end!";
		incomeWorkText.text = "Income from Work: " + incomeDuringLifeWork;
		incomeDivText.text = "Income from Dividends: " + incomeDuringLifeDividend;
		assetsValueText.text = "Assets value: " + assetsValue;
		incomeBondsLifetimeText.text = "Bonds income: " + incomeBondsLifetime;
		incomeDivPerYear.text = "Income/year to live from: " + divPerYear;
		capGainStockText.text = "Capital Gain from Stocks: " + capGainStock;
		totalReturnAssets.text = "Total Return Assets: " + Mathf.Round((assetsValue / totalInvestAssets-1)*100) + " %";


    }

	//Total return for the player. (Return / Invested capital)
	public void totalReturn(){

		PlayerPanelGO.GetComponent<portfolio> ().totalInvestedStock ();
		PlayerPanelGO.GetComponent<portfolio>().totalReturnStock ();

		//Return (Dividend + Interest + Rent + Capital gains)
		incomeDuringLifeDividend = PlayerPanelGO.GetComponent<totalCash>().incomeTotDivNow;
		incomeBondsLifetime = PlayerPanelGO.GetComponent<totalCash>().incomeBondsLifetime;
		incomeRentLifetime = PlayerPanelGO.GetComponent<totalCash> ().incomeRealEstateLifetime;
		capGainStock = PlayerPanelGO.GetComponent<portfolio>().totalReturnAmountStocks;


		//Invested capital (Stocks + Bonds + Real Estate + Business)
		stocksInvestmentTotAmount = PlayerPanelGO.GetComponent<portfolio>().totalStockInvestment;
		bondsInvestmentTotAmount = PlayerPanelGO.GetComponent<bondsPortfolio>().totalBondsInvest;
		realEstateInvestmentTotAmount = PlayerPanelGO.GetComponent<realEstatePortfolio>().totInvestRealEstate;
		businessInvestmentTotAmount = PlayerPanelGO.GetComponent<ownedBusiness>().totalInvestAmount;

		totalInvestAssets = stocksInvestmentTotAmount + bondsInvestmentTotAmount + realEstateInvestmentTotAmount + businessInvestmentTotAmount;
		Debug.Log ("Total invest: " + totalInvestAssets);
	}
}
