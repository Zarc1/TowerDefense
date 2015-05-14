using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretUpgrade : MonoBehaviour 
{
	GameObject Tower;
	int cLevel;
	float CoolD;
	int dam;
	bool isMagic;


	public GameObject lvl;
	public GameObject dmg;
	public GameObject cdr;
	public GameObject Upg;
	public GameObject spawn;
	public GameObject goldobj;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{
				if (hit.transform.tag == "MagicT")
				{
					Upg.SetActive (true);
					spawn.SetActive (false);
					Tower = hit.transform.gameObject;
					TowerInfoM (Tower);
					isMagic = true;
				}	
				if (hit.transform.tag == "ArrowT")
				{
					Upg.SetActive (true);
					spawn.SetActive (false);
					Tower = hit.transform.gameObject;
					TowerInfoA (Tower);
					isMagic = false;
				}	
			}
		}
	}
	public void Upgrade()
	{
		if (Tower)//make sure spawn location exists 
		{
			if (goldobj.GetComponentInChildren<Gold>().goldAmount >= 1000)//make sure we have enough gold
			{
				if(isMagic)
				{
					Tower.GetComponentInChildren<MagicTower>().level ++;
					Tower.GetComponentInChildren<MagicTower>().damage ++;
					Tower.GetComponentInChildren<MagicTower>().CDR -= 1f;
					TowerInfoM (Tower);
				}
				else
				{
					Tower.GetComponentInChildren<ArrowTower>().level ++;
					Tower.GetComponentInChildren<ArrowTower>().damage += .5f;
					Tower.GetComponentInChildren<ArrowTower>().CoolDown -= .25f;
					TowerInfoA (Tower);
				}
				goldobj.GetComponentInChildren<Gold>().LoseGold (1000);//call the lose gold function
			}
		}
	}
	void TowerInfoM(GameObject g)
	{
		lvl.GetComponent<Text>().text = "Level: " + g.GetComponentInChildren<MagicTower>().level;
		dmg.GetComponent<Text>().text = "Damage: " + g.GetComponentInChildren<MagicTower>().damage;
		cdr.GetComponent<Text>().text = "CoolDown: " + g.GetComponentInChildren<MagicTower>().CDR;
	}
	void TowerInfoA(GameObject g)
	{
		lvl.GetComponent<Text>().text = "Level: " + g.GetComponentInChildren<ArrowTower>().level;
		dmg.GetComponent<Text>().text = "Damage: " + g.GetComponentInChildren<ArrowTower>().damage;
		cdr.GetComponent<Text>().text = "CoolDown: " + g.GetComponentInChildren<ArrowTower>().CoolDown;
	}
}
