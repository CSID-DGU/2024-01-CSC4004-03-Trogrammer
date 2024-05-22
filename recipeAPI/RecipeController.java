package com.mysite.sbb;

import java.util.Map;
import java.util.HashMap;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.context.annotation.RequestScope;

@RestController
public class RecipeController {
	
	@Autowired
	private RecipeService recipeService;
	
	@RequestMapping(value = "/test", method = RequestMethod.GET)
	public List<Map<String, Object>> getRecipe(@RequestParam(value = "rcp_nm") String rcp_nm) {
		System.out.println(rcp_nm);
		List<Map<String, Object>> list = recipeService.getRecipe(rcp_nm);

		return list;
	}
}

