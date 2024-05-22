package com.mysite.sbb;

import java.util.List;
import java.util.Map;

public interface RecipeService {
	List<Map<String, Object>> getRecipe(String rcp_nm);
	
}
