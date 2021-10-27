using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dividendRecieved : MonoBehaviour
{
	//Utdelningar som erhållits

	public GameObject playerPanelGO;

	public portfolioStock PortfolioStock; 
	public utilitiesInfoStock UtiInfoStock;
	public techInfoStock TechInfoStock;

	public List<float> utiCompanySharesOwned;
	public List<float> utiCompanyDivPayout;
	public List<float> utiCompanyDivRecieved = new List<float> ();

	public List<float> techCompanySharesOwned;
	public List<float> techCompanyDivPayout;
	public List<float> techCompanyDivRecieved = new List<float> ();

	public List<float> divRecPerYear = new List<float> ();

	public float totalDivRecieved;

	int year = 0; 

    // Start is called before the first frame update
    void Awake()
    {
		PortfolioStock = GetComponent<portfolioStock> ();
		UtiInfoStock =  GetComponent<utilitiesInfoStock> ();
		TechInfoStock =  GetComponent<techInfoStock> ();

    }

    // Update is called once per frame
	public void recievedDividends()
    {
		divRecPerYear.Add (0);
		utiCompanyDivPayout = UtiInfoStock.divPayout;
		utiCompanySharesOwned = PortfolioStock.utiCompanySharesOwned;
		techCompanyDivPayout = TechInfoStock.divPayout;
		techCompanySharesOwned = PortfolioStock.techCompanySharesOwned;


		//Gå igenom alla utilites-bolag
		for (int i = 0; i < utiCompanyDivPayout.Count; i++) {
			utiCompanyDivRecieved[i] = utiCompanyDivPayout [i] * utiCompanySharesOwned [i];
			divRecPerYear[year] += utiCompanyDivRecieved[i];
		}


		//Gå igenom alla tech-bolag
		for (int i = 0; i < techCompanyDivPayout.Count; i++) {
			techCompanyDivRecieved[i] = techCompanyDivPayout [i] * techCompanySharesOwned [i];
			divRecPerYear[year] += techCompanyDivRecieved[i];
		}

		playerPanelGO.GetComponent <totalCash> ().addMoney(divRecPerYear [year]);



		//Debug.Log("UTD: " + (utiCompanyDivPayout[0] * utiCompanySharesOwned [0]));

		year++;

    }
}
