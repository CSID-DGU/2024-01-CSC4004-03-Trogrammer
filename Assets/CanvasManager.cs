using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;





public class CanvasManager : MonoBehaviour {
	RectTransform rect;
	Text text;
	Button button;





	void Start() {
		int foodCount = PlayerPrefs.GetInt("foodCount");
        for (int i = 0; i < foodCount; i++) {
			string name = PlayerPrefs.GetString("name" + i);
			string date = PlayerPrefs.GetString("date" + i);
			DateTime expirationDate = DateTime.ParseExact(date, "yyyy.MM.dd", null);
			FoodObject foodObject = AddFood(name, expirationDate);
			listFood.Add(foodObject);
		}

        InitMain();
		InitRefrigerator();
		InitRecipe();
		InitAnalysis();
		InitStatusBar();
		InitNavigationBar();

		pageMain.gameObject.SetActive(true);
	}

	void Update() {
		if (barStatus.gameObject.activeSelf) textTime.text = DateTime.Now.ToString("HH:mm");
		if (Input.GetKeyDown(KeyCode.Escape)) Back();
	}

	void ChangePageTo(Canvas page) {
		pageMain        .gameObject.SetActive(false);
		pageRefrigerator.gameObject.SetActive(false);
		pageRecipe      .gameObject.SetActive(false);
		pageAnalysis    .gameObject.SetActive(false);
		page            .gameObject.SetActive(true );
	}

	void Back() {
		if (pageMain             .gameObject.activeSelf) {
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}
		else if (pageRefrigerator.gameObject.activeSelf) {
			if (!buttonAddFood.gameObject.activeSelf) {
				buttonAddFood .gameObject.SetActive(true );
				inputFoodInfo .gameObject.SetActive(false);
				return;
			}
			ChangePageTo(pageMain);
		}
		else if (pageRecipe      .gameObject.activeSelf) {
			if (rectRecipePopup.gameObject.activeSelf) {
				rectRecipePopup.gameObject.SetActive(false);
				return;
			}
			ChangePageTo(pageMain);
		}
		else if (pageAnalysis     .gameObject.activeSelf) {
			ChangePageTo(pageRecipe);
		}
	}

	static string AddComma(float value) {
		string result = value.ToString("F0");
		for (int i = result.Length - 3; 0 < i; i -= 3) result = result.Insert(i, ",");
		return result;
	}





	[Header("Main")]
	[SerializeField] Canvas pageMain;

	[SerializeField] Button buttonMainToRefrigerator;
	[SerializeField] Button buttonMainToRecipe;

	void InitMain() {
		pageMain.gameObject.SetActive(false);

		buttonMainToRefrigerator.onClick.AddListener(() => {
			ChangePageTo(pageRefrigerator);
		});
		buttonMainToRecipe.onClick.AddListener(() => {
			ChangePageTo(pageRecipe);
		});
	}





	[Header("Refrigerator")]
	[SerializeField] Canvas pageRefrigerator;

	[SerializeField] ScrollRect rectFood;
	[SerializeField] ScrollRect rectFoodDangerous;

	[SerializeField] Button buttonAddFood;
	[SerializeField] Image inputFoodInfo;
	[SerializeField] InputField inputFoodName;
	[SerializeField] InputField inputFoodYear;
	[SerializeField] InputField inputFoodMonth;
	[SerializeField] InputField inputFoodDay;
	[SerializeField] Button buttonChangeInputField;
	[SerializeField] Button buttonSubmitFood;

	[SerializeField] GameObject prefabFood;

	struct FoodObject {
		public GameObject gameObject;
		public string name;
		public DateTime expirationDate;
	}
	List<FoodObject> listFood = new List<FoodObject>();

	void InitRefrigerator() {
		pageRefrigerator.gameObject.SetActive(false);
		buttonAddFood   .gameObject.SetActive(true );
		inputFoodInfo   .gameObject.SetActive(false);
		RefreshFood();

		buttonAddFood.onClick.AddListener(() => {
			buttonAddFood .gameObject.SetActive(false);
			inputFoodInfo .gameObject.SetActive(true );
			inputFoodName .gameObject.SetActive(true );
			inputFoodYear .gameObject.SetActive(false);
			inputFoodMonth.gameObject.SetActive(false);
			inputFoodDay  .gameObject.SetActive(false);
			inputFoodName .text = "";
			DateTime date = DateTime.Now + new TimeSpan(30, 0, 0, 0);
			inputFoodYear .text = date.ToString("yyyy");
			inputFoodMonth.text = date.ToString(  "MM");
			inputFoodDay  .text = date.ToString(  "dd");
			RefreshInputFoodName();
		});
		buttonChangeInputField.onClick.AddListener(() => {
			RefreshInputFoodName(!inputFoodName.gameObject.activeSelf);
		});
		buttonSubmitFood.onClick.AddListener(() => {
			if (inputFoodName.text == "") return;
			buttonAddFood .gameObject.SetActive(true );
			inputFoodInfo .gameObject.SetActive(false);
			DateTime date;
			try {
				date = new DateTime(
					int.Parse(inputFoodYear .text),
					int.Parse(inputFoodMonth.text),
					int.Parse(inputFoodDay  .text));
			}
			catch {
				date = DateTime.Now + new TimeSpan(30, 0, 0, 0);
			}
			FoodObject foodObject = AddFood(inputFoodName.text, date);
			listFood.Add(foodObject);
			RefreshFood();
		});
	}

	void RefreshInputFoodName(bool value = true) {
		buttonChangeInputField.transform.GetChild(0).TryGetComponent(out text);
		if (value) {
			text.text = "유통기한";
			inputFoodName .gameObject.SetActive(true );
			inputFoodYear .gameObject.SetActive(false);
			inputFoodMonth.gameObject.SetActive(false);
			inputFoodDay  .gameObject.SetActive(false);
		}
		else {
			text.text = "식재료명";
			inputFoodName .gameObject.SetActive(false);
			inputFoodYear .gameObject.SetActive(true );
			inputFoodMonth.gameObject.SetActive(true );
			inputFoodDay  .gameObject.SetActive(true );
		}
	}

	FoodObject AddFood(string name, DateTime date) {
		FoodObject foodObject = new FoodObject {
			gameObject = Instantiate(prefabFood, transform), name = name, expirationDate = date
		};
		foodObject.gameObject.name = foodObject.name;
		foodObject.gameObject.transform.GetChild(0).TryGetComponent(out text);
		text.text = foodObject.name;
		foodObject.gameObject.transform.GetChild(1).TryGetComponent(out text);
		text.text = foodObject.expirationDate.ToString("yyyy.MM.dd");
		foodObject.gameObject.transform.GetChild(2).TryGetComponent(out button);
		button.onClick.AddListener(() => {
			Destroy(foodObject.gameObject);
			listFood.Remove(foodObject);
			RefreshFood();
		});
		return foodObject;
	}

	void RefreshFood() {
		DateTime date = DateTime.Now + new TimeSpan(3, 0, 0, 0);

		RectTransform contentFood;
		RectTransform contentFoodDangerous;
		rectFood         .transform.GetChild(1).GetChild(0).TryGetComponent(out contentFood);
		rectFoodDangerous.transform.GetChild(1).GetChild(0).TryGetComponent(out contentFoodDangerous);

		int lengthFood          = 0;
		int lengthFoodDangerous = 0;
		for (int i = 0; i < listFood.Count; i++) {
			listFood[i].gameObject.TryGetComponent(out rect);
			if (date <= listFood[i].expirationDate) {
				listFood[i].gameObject.transform.SetParent(contentFood);
				rect.offsetMin = new Vector2(0,   0);
				rect.offsetMax = new Vector2(0, 100);
				rect.anchoredPosition = new Vector2(0, -lengthFood * 100);
				lengthFood++;
			}
			else {
				listFood[i].gameObject.transform.SetParent(contentFoodDangerous);
				rect.offsetMin = new Vector2(0,   0);
				rect.offsetMax = new Vector2(0, 100);
				rect.anchoredPosition = new Vector2(0, -lengthFoodDangerous * 100);
				lengthFoodDangerous++;
			}
			PlayerPrefs.SetString("name" + i, listFood[i].name);
			PlayerPrefs.SetString("date" + i, listFood[i].expirationDate.ToString("yyyy.MM.dd"));
		}
		PlayerPrefs.SetInt("foodCount", listFood.Count);
		contentFood         .sizeDelta = new Vector2(0, lengthFood          * 100);
		contentFoodDangerous.sizeDelta = new Vector2(0, lengthFoodDangerous * 100);

		if (lengthFood == 0)  rectFood.gameObject.SetActive(false);
		else                  rectFood.gameObject.SetActive(true );
		if (lengthFoodDangerous == 0) {
			rectFoodDangerous.gameObject.SetActive(false);
			rectFood.TryGetComponent(out rect);
			rect.anchoredPosition = new Vector2(0,  -820);
		}
		else {
			rectFoodDangerous.gameObject.SetActive(true );
			rectFood.TryGetComponent(out rect);
			rect.anchoredPosition = new Vector2(0, -1220);
		}
	}





	[Header("Recipe")]
	[SerializeField] Canvas pageRecipe;

	[SerializeField] InputField inputRecipe;
	[SerializeField] Button buttonSearch;

	[SerializeField] Button buttonKorean;
	[SerializeField] Button buttonChinese;
	[SerializeField] Button buttonJapanese;
	[SerializeField] Button buttonWestern;
	[SerializeField] ScrollRect rectRecipe;

	[SerializeField] RectTransform rectRecipePopup;
	[SerializeField] Text textRecipeName;
	[SerializeField] ScrollRect rectFoodDetail;
	[SerializeField] GameObject prefabFoodDetail;
	[SerializeField] ScrollRect rectStep;
	[SerializeField] Text textStep;
	[SerializeField] Button buttonRecipeToAnalysis;

	[SerializeField] GameObject prefabRecipe;
	[SerializeField] GameObject prefabStep;

	struct RecipeObject {
		public GameObject gameObject;
		public Database.Recipe recipe;
	}
	List<RecipeObject> listRecipe     = new List<RecipeObject>();
	List<GameObject>   listFoodDetail = new List<GameObject>  ();

	void InitRecipe() {
		pageRecipe     .gameObject.SetActive(false);
		rectRecipePopup.gameObject.SetActive(false);
		RefreshRecipe(Database.RecipeType.Korean);

		buttonSearch.onClick.AddListener(() => {
			for (int i = 0; i < Database.recipe.Count; i++) {
				if (Database.recipe[i].name == inputRecipe.text) {
					PopupRecipe(Database.recipe[i]);
					break;
				}
			}
		});
		buttonKorean.onClick.AddListener(() => {
			RefreshRecipe(Database.RecipeType.Korean);
		});
		buttonChinese.onClick.AddListener(() => {
			RefreshRecipe(Database.RecipeType.Chinese);
		});
		buttonJapanese.onClick.AddListener(() => {
			RefreshRecipe(Database.RecipeType.Japanese);
		});
		buttonWestern.onClick.AddListener(() => {
			RefreshRecipe(Database.RecipeType.Western);
		});
		buttonRecipeToAnalysis.onClick.AddListener(() => {
			ChangePageTo(pageAnalysis);
			RefreshAnalysis();
		});
	}

	RecipeObject AddRecipe(Database.Recipe recipe, RectTransform parent = null) {
		RecipeObject recipeObject = new RecipeObject {
			gameObject = Instantiate(prefabRecipe, parent), recipe = recipe
		};
		recipeObject.gameObject.name = recipeObject.recipe.name;
		recipeObject.gameObject.transform.GetChild(0).TryGetComponent(out text);
		text.text = recipeObject.recipe.name;
		recipeObject.gameObject.transform.TryGetComponent(out button);
		button.onClick.AddListener(() => {
			PopupRecipe(recipeObject.recipe);
		});
		return recipeObject;
	}

	void RefreshRecipe(Database.RecipeType type) {
		for (int i = 0; i < listRecipe.Count; i++) Destroy(listRecipe[i].gameObject);
		listRecipe.Clear();
		RectTransform contentRecipe;
		rectRecipe.transform.GetChild(1).GetChild(0).TryGetComponent(out contentRecipe);

		int length = 0;
		for (int i = 0; i < Database.recipe.Count; i++) {
			if (Database.recipe[i].type == type) {
				RecipeObject recipeObject = AddRecipe(Database.recipe[i], contentRecipe);
				listRecipe.Add(recipeObject);
				recipeObject.gameObject.TryGetComponent(out rect);
				rect.anchoredPosition = new Vector2(0, -length * 160);
				length++;
			}
		}
		contentRecipe.sizeDelta = new Vector2(0, length * 160);
	}

	void PopupRecipe(Database.Recipe recipe) {
		rectRecipePopup.gameObject.SetActive(true);

		for (int i = 0; i < listFoodDetail.Count; i++) Destroy(listFoodDetail[i]);
		listFoodDetail.Clear();
		RectTransform contentFoodDetail;
		rectFoodDetail.transform.GetChild(3).GetChild(0).TryGetComponent(out contentFoodDetail);

		textRecipeName.text = recipe.name;

		int length = 0;
		bool exist = false;
		for (int i = 0; i < recipe.foodset.Count; i++) {
			exist = false;
			for (int j = 0; j < listFood.Count; j++) {
				if (recipe.foodset[i].food.name == listFood[j].name) {
					exist = true;
					break;
				}
			}
			GameObject prefab = Instantiate(prefabFoodDetail, contentFoodDetail);
			prefab.gameObject.TryGetComponent(out rect);
			rect.anchoredPosition = new Vector2(0, -length * 100);
			listFoodDetail.Add(prefab);
			length++;

			prefab.transform.GetChild(0).TryGetComponent(out text);
			text.text = recipe.foodset[i].food.name;
			prefab.transform.GetChild(1).TryGetComponent(out text);
			string unit = Database.ToString(recipe.foodset[i].food.unit);
			text.text = AddComma(recipe.foodset[i].amount) + unit;
			prefab.transform.GetChild(2).TryGetComponent(out text);
			text.text = exist ? "o" : "";
			prefab.transform.GetChild(3).TryGetComponent(out button);
			string url = recipe.foodset[i].food.url;
			button.onClick.AddListener(() => {
				Application.OpenURL(url);
			});
		}
		contentFoodDetail.sizeDelta = new Vector2(0, length * 100);

		textStep.text = "";
		for (int i = 0; i < recipe.steps.Count; i++) textStep.text += recipe.steps[i] + "\n";
		
		selected = recipe;
	}





	[Header("Analysis")]
	[SerializeField] Canvas pageAnalysis;

	[SerializeField] Text textSelected;
	[SerializeField] ScrollRect rectCost;
	[SerializeField] Text textCostTotal;
	[SerializeField] ScrollRect rectRestaurant;
	[SerializeField] RawImage imageRestaurant;
	[SerializeField] Button buttonOpenURL;

	[SerializeField] GameObject prefabResult;

	List<GameObject> listCost       = new List<GameObject>();
	List<GameObject> listRestaurant = new List<GameObject>();

	Database.Recipe selected;
	Database.Restaurant selectedRestaurant;

	void InitAnalysis() {
		pageAnalysis.gameObject.SetActive(false);
		buttonOpenURL.onClick.AddListener(() => {
			Application.OpenURL(selectedRestaurant.url);
		});
	}

	void RefreshAnalysis() {
		for (int i = 0; i < listCost      .Count; i++) Destroy(listCost      [i]);
		for (int i = 0; i < listRestaurant.Count; i++) Destroy(listRestaurant[i]);
		listCost      .Clear();
		listRestaurant.Clear();
		RectTransform contentCost;
		RectTransform contentRestaurant;
		rectCost      .transform.GetChild(1).GetChild(0).TryGetComponent(out contentCost);
		rectRestaurant.transform.GetChild(1).GetChild(0).TryGetComponent(out contentRestaurant);

		textSelected.text = selected.name;

		bool  exist = false;
		float total = 0.0f;
		int   length = 0;
		for (int i = 0; i < selected.foodset.Count; i++) {
			exist = false;
			for (int j = 0; j < listFood.Count; j++) {
				if (selected.foodset[i].food.name == listFood[j].name) {
					exist = true;
					break;
				}
			}
			if (exist) continue;
			GameObject prefab = Instantiate(prefabFoodDetail, contentCost);
			prefab.gameObject.TryGetComponent(out rect);
			rect.anchoredPosition = new Vector2(0, -length * 100);
			listCost.Add(prefab);
			length++;

			float amount = selected.foodset[i].amount;
			float price = selected.foodset[i].food.price / selected.foodset[i].food.amount * amount;
			string unit = Database.ToString(selected.foodset[i].food.unit);
			prefab.transform.GetChild(0).TryGetComponent(out text);
			text.text = "   - " + selected.foodset[i].food.name;
			prefab.transform.GetChild(1).TryGetComponent(out text);
			text.text = "";
			prefab.transform.GetChild(2).TryGetComponent(out text);
			text.text = AddComma(amount) + unit + " : " + AddComma(price) + "원";
			prefab.transform.GetChild(3).TryGetComponent(out button);
			string url = selected.foodset[i].food.url;
			button.onClick.AddListener(() => {
				Application.OpenURL(url);
			});
			total += price;
		}
		contentCost.sizeDelta = new Vector2(0, length * 100);
		textCostTotal.text = AddComma(total) + "원";

		exist = false;
		total = -1;
		length = 0;
		int r = -1;
		for (int i = 0; i < Database.restaurant.Count; i++) {
			for (int j = 0; j < Database.restaurant[i].menuset.Count; j++) {
				if (Database.restaurant[i].menuset[j].category == selected.name) {
					
					int k = listRestaurant.Count - 1;
					if (r != i) {
						r = i;
						GameObject restaurant = Instantiate(prefabResult, contentRestaurant);
						restaurant.name = Database.restaurant[i].name;
						restaurant.gameObject.TryGetComponent(out rect);
						rect.anchoredPosition = new Vector2(0, -length * 100);
						listRestaurant.Add(restaurant);
						length++;

						restaurant.transform.GetChild(0).TryGetComponent(out text);
						text.text = "   " + Database.restaurant[i].name;
						restaurant.transform.GetChild(1).TryGetComponent(out text);
						text.text = "";
					}

					GameObject prefab = Instantiate(prefabResult, contentRestaurant);
					prefab.name = Database.restaurant[i].menuset[j].name;
					prefab.gameObject.TryGetComponent(out rect);
					rect.anchoredPosition = new Vector2(0, -length * 100);
					listRestaurant.Add(prefab);
					length++;

					prefab.transform.GetChild(0).TryGetComponent(out text);
					text.text = "      - " + Database.restaurant[i].menuset[j].name;
					prefab.transform.GetChild(1).TryGetComponent(out text);
					text.text = AddComma(Database.restaurant[i].menuset[j].price) + "원";

					exist = true;
					if (total == -1 || Database.restaurant[i].menuset[j].price < total) {
						total = Database.restaurant[i].menuset[j].price;
						selectedRestaurant = Database.restaurant[i];
					}
				}
			}
		}
		contentRestaurant.sizeDelta = new Vector2(0, length * 100);
		buttonOpenURL.onClick.RemoveAllListeners();
		buttonOpenURL.transform.GetChild(0).TryGetComponent(out text);
		if (exist) {
			text.text = "웹에서 "+ selectedRestaurant.name + " 보기";
			buttonOpenURL.onClick.AddListener(() => {
				Application.OpenURL(selectedRestaurant.url);
			});
		}
		else {
			text.text = "주변에 이 음식을 파는 식당이 없습니다.";
			buttonOpenURL.onClick.AddListener(() => {
				Back();
			});
		}
	}





	[Header("Status Bar")]
	[SerializeField] Canvas barStatus;
	[SerializeField] Text textTime;

	void InitStatusBar() {
		#if UNITY_EDITOR
			barStatus.gameObject.SetActive(true );
		#else
			barStatus.gameObject.SetActive(false);
		#endif
	}





	[Header("Navigation Bar")]
	[SerializeField] Canvas barNavigation;
	[SerializeField] Button buttonMenu;
	[SerializeField] Button buttonHome;
	[SerializeField] Button buttonBack;

	void InitNavigationBar() {
		#if UNITY_EDITOR
			barNavigation.gameObject.SetActive(true );
		#else
			barNavigation.gameObject.SetActive(false);
		#endif
		buttonBack.onClick.AddListener(() => { Back(); });
	}
}
