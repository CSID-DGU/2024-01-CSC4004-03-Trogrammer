import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.util.HashMap;
import java.util.Map;

import org.json.JSONObject;
import org.json.JSONArray;

public class APIRequest {
    private static final String API_KEY = ""; // 발급받은 API Key 입력
    private static final String API_URL = "https://api.data.go.kr/openapi/tn_pubr_public_mrkt_price_info_api";

    public static void main(String[] args) {
        try {
            // API 요청 파라미터 설정
            Map<String, String> params = new HashMap<>();
            params.put("serviceKey", ""); // 발급받은 API Key 입력
            params.put("pageNo", "1");
            params.put("numOfRows", "10");
            params.put("type", "json");
            params.put("examinDe", "20230520");
            params.put("whsalMrktNewNm", URLEncoder.encode("가락도매시장", "UTF-8"));
            params.put("prdlstNm", URLEncoder.encode("사과", "UTF-8"));

            // API 호출 및 응답 받기
            String response = getProductPriceInfo(params);
            if (response != null) {
                JSONObject jsonResponse = new JSONObject(response);
                System.out.println(jsonResponse.toString(2));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static String getProductPriceInfo(Map<String, String> params) {
        try {
            // 파라미터를 URL에 추가
            StringBuilder urlBuilder = new StringBuilder(API_URL);
            urlBuilder.append("?");
            for (Map.Entry<String, String> entry : params.entrySet()) {
                if (urlBuilder.length() > 1) {
                    urlBuilder.append("&");
                }
                urlBuilder.append(URLEncoder.encode(entry.getKey(), "UTF-8"))
                          .append("=")
                          .append(URLEncoder.encode(entry.getValue(), "UTF-8"));
            }

            URL url = new URL(urlBuilder.toString());
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/json");
            conn.setDoOutput(true);

            int responseCode = conn.getResponseCode();
            if (responseCode == 200) {
                BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                String inputLine;
                StringBuilder response = new StringBuilder();

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }
                in.close();
                return response.toString();
            } else {
                return "{\"error\": \"" + responseCode + "\", \"message\": \"" + conn.getResponseMessage() + "\"}";
            }
        } catch (Exception e) {
            e.printStackTrace();
            return "{\"error\": \"Exception\", \"message\": \"" + e.getMessage() + "\"}";
        }
    }
}
