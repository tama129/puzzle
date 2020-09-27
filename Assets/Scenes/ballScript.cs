using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScript : MonoBehaviour
{
	private GameObject damageText;
	private GameObject damegeText2;
	public GameObject kaihukuText;
	Tern Tern;
	Daria daria;
	public GameObject ballPrefab;
	public Sprite[] ballSprites;
	public GameObject firstBall;
	public GameObject lastBall;
	private string currentName;
	List<GameObject> removableBallList = new List<GameObject>();
    internal int remove_cnt;
	private int damegedaria = 0;
	private int value = 0;
	private int kaihukudaria = 0;
	private int value2 = 0;

	void Start()
	{
		this.kaihukuText = GameObject.Find("kaihukuText");
		this.damageText = GameObject.Find("damageText");
		this.damegeText2 = GameObject.Find("damegeText2");
		StartCoroutine(DropBall(60));
		Tern = GameObject.Find("controller").GetComponent<Tern>();
		daria = GameObject.Find("daria").GetComponent<Daria>();
	}
	void Update()
	{
	}

	public void Mikata()
	{
		if (Input.GetMouseButtonDown(0) && firstBall == null)
		{
			OnDragStart();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			//クリックを終えた時
			OnDragEnd();
			Tern.turn = false;
			Debug.Log(Tern.countup);
			Tern.countup += Time.deltaTime;
		}
		else if (firstBall != null)
		{
			OnDragging();
		}
	}

	public void OnDragStart()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit.collider != null)
		{
			GameObject hitObj = hit.collider.gameObject;
			string ballName = hitObj.name;
			if (ballName.StartsWith("tama"))
			{
				firstBall = hitObj;
				lastBall = hitObj;
				currentName = hitObj.name;
				removableBallList = new List<GameObject>();
				PushToList(hitObj);
			}
		}
	}

	public void OnDragging()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null)
		{
			GameObject hitObj = hit.collider.gameObject;

			if (hitObj.name == currentName && lastBall != hitObj)
			{
				float distance = Vector2.Distance(hitObj.transform.position, lastBall.transform.position);
				if (distance < 1.0f)
				{
					lastBall = hitObj;
					PushToList(hitObj);
				}
			}
		}
	}

	public void OnDragEnd()
	{
		int remove_cnt = removableBallList.Count;
		if (remove_cnt >= 1)
		{
			for (int i = 0; i < remove_cnt; i++)
			{
				Destroy(removableBallList[i]);
			}
			//ボールを新たに生成
			StartCoroutine(DropBall(remove_cnt));
			Debug.Log(remove_cnt * daria.power);
			damegedaria = remove_cnt * daria.power;
			kaihukudaria = remove_cnt * daria.kaihuku;
			value = Random.Range(0, 99 + 1);
			value2 = Random.Range(0, 9 + 1);
			int damege = damegedaria + value;
			int kaihuku = kaihukudaria + value2;
			damageText.GetComponent<Text>().text = damege.ToString();
			damegeText2.GetComponent<Text>().text = damege.ToString();
			kaihukuText.GetComponent<Text>().text = kaihuku.ToString();
		}
		else
		{
			//色の透明度を100%に戻す
			for (int i = 0; i < remove_cnt; i++)
			{
				ChangeColor(removableBallList[i], 1.0f);
			}
		}
		firstBall = null;
		lastBall = null;
	}

	IEnumerator DropBall(int count)
	{
		for (int i = 0; i < count; i++)
		{
			Vector2 pos = new Vector2(Random.Range(-2.0f, 2.0f), 7f);
			GameObject ball = Instantiate(ballPrefab, pos,
				Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;
			int spriteId = Random.Range(0, 7);
			ball.name = "tama" + spriteId;
			SpriteRenderer spriteObj = ball.GetComponent<SpriteRenderer>();
			spriteObj.sprite = ballSprites[spriteId];
			yield return new WaitForSeconds(0.05f);
		}
	}

	void PushToList(GameObject obj)
	{
		removableBallList.Add(obj);
		//色の透明度を50%に落とす
		ChangeColor(obj, 0.5f);
	}
	void ChangeColor(GameObject obj, float transparency)
	{
		//SpriteRendererコンポーネントを取得
		SpriteRenderer ballTexture = obj.GetComponent<SpriteRenderer>();
		//Colorプロパティのうち、透明度のみ変更する
		ballTexture.color = new Color(ballTexture.color.r, ballTexture.color.g, ballTexture.color.b, transparency);
	}
}