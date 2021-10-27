
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class incomeWork : MonoBehaviour
{
	//Script med data kring inkomst från jobb som erhålls då varje runda är slut

	public float workIncomeStart;
	public float workIncomeNow;
	public Text workIncomeText;

	public float incomeWorkLife; //Inkomst från arbete
	//public Text incomeWorkLifeText;

	public GameObject MoneyPanel;
	public int infoMoneyOnOrOff = 0;

	// Start is called before the first frame update
	void Start()
	{
		workIncomeNow = workIncomeStart;
	}

	// Update is called once per frame
	void Update()
	{
		workIncomeText.text = "Work/month: " + workIncomeNow;  
	}

	public void showMoneyPanel(){



		if (infoMoneyOnOrOff == 0){
			MoneyPanel.SetActive (true);
			infoMoneyOnOrOff++;
		}

		else {
			MoneyPanel.SetActive (false);
			infoMoneyOnOrOff--;
		}

	}

	public void incomeLifeFromWork()

	{
		incomeWorkLife = incomeWorkLife + workIncomeNow;
		//incomeWorkLifeText.text = "Income from Work: " + incomeWorkLife;
	}
}
