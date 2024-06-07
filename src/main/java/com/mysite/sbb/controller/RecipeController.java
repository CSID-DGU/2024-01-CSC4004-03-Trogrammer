package com.mysite.sbb.controller;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.mysite.sbb.dto.Ingredients;
import com.mysite.sbb.service.IngredientsService;
import com.mysite.sbb.service.RecipeService;

@RestController
public class RecipeController {
	
	@Autowired
	private RecipeService recipeService;
	@Autowired
	private IngredientsService ingredientservice;
	
	//냉장고 식재료에 따라 레시피 추천
	@RequestMapping(value = "/recommend", method = RequestMethod.GET)
	public ArrayList<Map<String, Object>> getapiRecipe() {
		
		//사용자 냉장고 가져오기
		List<Ingredients> ingreList = ingredientservice.selingredient();
		System.out.println(ingreList);
		List<Map<String, Object>> recipeList = null;
		Map<String, Object> recipeMap = new HashMap<>();
		//냉장고 식재료를 사용하는 레시피 가져오기
		for(int i = 0; i<ingreList.size(); i++)	{
			System.out.println("------------------------------- " + i);
			recipeList = recipeService.getRecipe(ingreList.get(i).getIngrename());
			System.out.println(recipeList);
			//레시피 count하여 식재료가 가장 많이 일치하는 레시피 찾기
			for(Map<String, Object> recipe : recipeList) {
				String rcp_seq = (String)recipe.get("RCP_SEQ");
				Map<String, Object> dataMap = new HashMap<String, Object>();
				if(recipeMap.get(rcp_seq) == null)	{
					dataMap.put("count", 1);
				}
				else {
					System.out.println("중복------" + recipeMap.get(rcp_seq));

					dataMap.put("count", (int)((Map<String, Object>) recipeMap.get(rcp_seq)).get("count") + 1);
				}
				dataMap.put("data", recipe );
				recipeMap.put(rcp_seq ,dataMap);
			}
		}
		//가지고 있는 식재료가 3개 이상일 경우의 레시피만 추천 
		ArrayList<Map<String, Object>> resultList = new ArrayList<Map<String, Object>>();
		for(String key: recipeMap.keySet()) {
			if((int)((Map<String, Object>) recipeMap.get(key)).get("count") >= 3){
				resultList.add((Map<String, Object>)((Map<String, Object>) recipeMap.get(key)).get("data"));
			}
				
		}

		return resultList;
	}
}

