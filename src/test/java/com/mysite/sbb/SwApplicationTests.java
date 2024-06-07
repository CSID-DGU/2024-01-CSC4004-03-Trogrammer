package com.mysite.sbb;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import com.mysite.sbb.service.ExpiryService;

@SpringBootTest
class SwApplicationTests {
	@Autowired
	private ExpiryService expriryService;
	
	
	
	@Test
	public void test() {
		System.out.println(expriryService);
	}


}
