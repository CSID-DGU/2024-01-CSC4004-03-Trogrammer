import requests
from requests.utils import quote

API_KEY = ''    # 발급받은 API Key 입력 
API_URL = "https://api.data.go.kr/openapi/tn_pubr_public_mrkt_price_info_api"

encoded_api_key = quote(API_KEY, safe='')

# API 요청 파라미터 설정
params = {
    'serviceKey': '',   # 발급받은 API Key 입력 
    'pageNo': '1',
    'numOfRows': '10',
    'type': 'json',  
    'examinDe': '20230520',  
    'whsalMrktNewNm': '가락도매시장', 
    'prdlstNm': '사과',
}

# API 호출
def get_product_price_info(params):
    response = requests.get(API_URL, params=params, verify=False)
    
    if response.status_code == 200:
        try:
            return response.json()
        except ValueError:
            return {'error': 'Invalid JSON response', 'content': response.text}
    else:
        return {'error': response.status_code, 'message': response.text}

# 상품 가격 정보 조회
product_price_info = get_product_price_info(params)
print(product_price_info)
