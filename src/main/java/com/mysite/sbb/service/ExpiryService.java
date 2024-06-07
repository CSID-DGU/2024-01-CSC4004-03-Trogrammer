package com.mysite.sbb.service;

import java.util.List;
import java.util.Map;

public interface ExpiryService {
	List<Map<String,Object>> get_past();
	List<Map<String,Object>> get_three();
	List<Map<String,Object>> get_threetofive();
	List<Map<String,Object>> get_overfive();
}
