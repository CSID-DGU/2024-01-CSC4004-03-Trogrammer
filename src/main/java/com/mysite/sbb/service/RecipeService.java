package com.mysite.sbb.service;

import java.util.List;
import java.util.Map;

public interface RecipeService {
	List<Map<String, Object>> getRecipe(String RCP_PARTS_DTLS);
	
}
