using UnityEngine;
using System.Collections;

public class HighSoreScript : MonoBehaviour 
{

	public class TestScript : MonoBehaviour 
	{
		// Når man gemmer ting på harddisken via PlayerPrefs, så gemmer man ting i et "dictionary", som har en "key" og en "value"
		// En "key" er altid en string, som du kan se som et slags variabel-navn
		// En "value" er det som den indeholder (integer, float eller string)
		// Vi skal først definere nogle "keys", som ikke må blive ændret. De fortæller os hvad vores "variabler" hedder i PlayerPrefs.
		private const string highScoreOnDisk1         = "Score_1_Points";    // 'const' står for 'constant', hvilket betyder at der kun er én, og den ændrer sig aldrig
		private const string highScoreNameOnDisk1     = "Score_1_Name";
		
		private const string highScoreOnDisk2         = "Score_2_Points";
		private const string highScoreNameOnDisk2     = "Score_2_Name";
		
		private const string highScoreOnDisk3         = "Score_3_Points";
		private const string highScoreNameOnDisk3     = "Score_3_Name";
		
		void Start () 
		{
			//Først skal vi sørge for at vores "keys" findes, og at vi kan hente fra dem
			
			if( !PlayerPrefs.HasKey(highScoreOnDisk1) )        //Hvis der ikke er en "key" med dette navn, så lav en ny tom key med det navn
				PlayerPrefs.SetInt(highScoreOnDisk1, 0);
			
			if( !PlayerPrefs.HasKey(highScoreNameOnDisk1) )    
				PlayerPrefs.SetString(highScoreNameOnDisk1, "N/A");
			
			if( !PlayerPrefs.HasKey(highScoreOnDisk2) )    
				PlayerPrefs.SetInt(highScoreOnDisk2, 0);
			
			if( !PlayerPrefs.HasKey(highScoreNameOnDisk2) )    
				PlayerPrefs.SetString(highScoreNameOnDisk2, "N/A");
			
			if( !PlayerPrefs.HasKey(highScoreOnDisk3) )    
				PlayerPrefs.SetInt(highScoreOnDisk3, 0);
			
			if( !PlayerPrefs.HasKey(highScoreNameOnDisk3) )    
				PlayerPrefs.SetString(highScoreNameOnDisk3, "N/A");
		}
		
		//Når vi har en ny score, så skal vi hente alle de scores (og navne) fra harddisken, og sammenligne med vores nye score
		public void UpdateScoreOnDisk(int myScore, string myName)
		{
			//Først skal vi hente de gamle scores
			int oldScore1 = PlayerPrefs.GetInt(highScoreOnDisk1);
			int oldScore2 = PlayerPrefs.GetInt(highScoreOnDisk2);
			int oldScore3 = PlayerPrefs.GetInt(highScoreOnDisk3);
			
			string oldName1 = PlayerPrefs.GetString(highScoreNameOnDisk1);
			string oldName2 = PlayerPrefs.GetString(highScoreNameOnDisk2);
			string oldName3 = PlayerPrefs.GetString(highScoreNameOnDisk3);
			
			//Vi gør klar til at sammenligne med vores nye score, og kopierer de gamle værdier i de nye felter
			int newScore1 = oldScore1;
			int newScore2 = oldScore2;
			int newScore3 = oldScore3;
			
			string newName1 = oldName1;
			string newName2 = oldName2;
			string newName3 = oldName3;
			
			//Når vi sammenligner værdierne, er det vigtigt vi starter fra bunden
			
			//Hvis vi har slået scoren, så skal den rykkes ned, og vi sætter vores ind på dens plads
			if(myScore > oldScore3)    
			{
				//Vi har slået denne værdi, og der er ikke flere værdier, så vi glemmer den gamle værdi
				//Indsæt vores navn og score på placeringen
				newScore3 = myScore;
				newName3 = myName;
				
				//Se om vi OGSÅ har slået den næste i rækken
				if (myScore > oldScore2)
				{
					//Vi har slået denne værdi, så FØRST skub dens værdier til den næste score før vi sætter vores værdier ind
					newScore3 = oldScore2;
					newName3 = oldName2;
					
					//Indsæt vores navn og score
					newScore2 = myScore;
					newName2 = myName;
					
					//Se om vi OGSÅ har slået den næste i rækken
					if (myScore > oldScore1)
					{
						//Vi har slået denne værdi, så FØRST skub dens værdier til den næste score før vi sætter vores værdier ind
						newScore2 = oldScore1;
						newName2 = oldName1;
						
						//Indsæt vores navn og score
						newScore1 = myScore;
						newName1 = myName;
					}
				}
			}
			
			//Gem de nye scores til harddisken
			PlayerPrefs.SetInt(highScoreOnDisk1, newScore1);
			PlayerPrefs.SetInt(highScoreOnDisk2, newScore2);
			PlayerPrefs.SetInt(highScoreOnDisk3, newScore3);
			
			PlayerPrefs.SetString(highScoreNameOnDisk1, newName1);
			PlayerPrefs.SetString(highScoreNameOnDisk2, newName2);
			PlayerPrefs.SetString(highScoreNameOnDisk3, newName3);
		}
	}
}
