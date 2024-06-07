package com.mysite.sbb.service;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.apache.ibatis.annotations.Param;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestParam;

import com.mysite.sbb.dto.Ingredients;

@Service
public class RecipeServiceImpl implements RecipeService{
	

	@Override
	public List<Map<String, Object>> getRecipe(String RCP_PARTS_DTLS) {
		StringBuffer response = null;
		List<Map<String, Object>> list = new ArrayList<>();
		//예외처리
        try {
            String apiURL = "http://openapi.foodsafetykorea.go.kr/api/8ac3e95b730b4d998a2f/COOKRCP01/json/1/100/RCP_PARTS_DTLS="+RCP_PARTS_DTLS;
            URL url = new URL(apiURL);
            HttpURLConnection con = (HttpURLConnection)url.openConnection();
            con.setRequestMethod("GET");
            //con.setRequestProperty("Authorization", header);
            int responseCode = con.getResponseCode();
            BufferedReader br;
            if(responseCode==200) { // 정상 호출
                br = new BufferedReader(new InputStreamReader(con.getInputStream()));
                
            } else {  // 에러 발생
                br = new BufferedReader(new InputStreamReader(con.getErrorStream()));
            }
            String inputLine;
            
            response = new StringBuffer();
            while ((inputLine = br.readLine()) != null) {
                response.append(inputLine);
            }
            br.close();
            //System.out.println(response);
        } catch (Exception e) {
            System.out.println(e);
        }
        
        try	{
        	JSONParser jsonParser = new JSONParser();
        	JSONObject jsonObject = (JSONObject)jsonParser.parse(response.toString());
        	jsonObject = (JSONObject)jsonObject.get("COOKRCP01");
        	int totalcount = Integer.parseInt((String)jsonObject.get("total_count"));
        	JSONArray jsonarray = (JSONArray)jsonObject.get("row");
        	
        	for(int i = 0; i<totalcount; i++) {
        		Map<String, Object> map = new HashMap<String, Object>();
        		jsonObject = (JSONObject)jsonarray.get(i);
        		Set<String> keyset = jsonObject.keySet();
        		Iterator<String> iter = keyset.iterator();
        		
        		while(iter.hasNext())	{
        			String keyname = iter.next();
        			String value = (String)jsonObject.get(keyname);
        			map.put(keyname, value);
        		}
        		list.add(map);
        	}
        	//System.out.println(list);
        } catch(Exception e) {
        	System.out.println(e);
        }
        
		return list;
	}
	

}
