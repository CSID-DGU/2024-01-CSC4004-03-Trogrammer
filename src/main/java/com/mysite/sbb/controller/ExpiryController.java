package com.mysite.sbb.controller;

import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.mysite.sbb.service.ExpiryService;

@RestController
@RequestMapping("/expiry")
public class ExpiryController {
	
	@Autowired
	private ExpiryService expriryService;
	
	@RequestMapping(value = "/past", method = RequestMethod.GET)
	public List<Map<String, Object>> past(){
		return expriryService.get_past();
	}
	@RequestMapping(value = "/three", method = RequestMethod.GET)
	public List<Map<String, Object>> three(){
		return expriryService.get_three();
	}
	@RequestMapping(value = "/threetofive", method = RequestMethod.GET)
	public List<Map<String, Object>> threetofive(){
		return expriryService.get_threetofive();
	}
	@RequestMapping(value = "/overfive", method = RequestMethod.GET)
	public List<Map<String, Object>> overfive(){
		return expriryService.get_overfive();
	}
}
