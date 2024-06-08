using System.Collections.Generic;
using UnityEngine.UIElements;

public static class Database {

    public enum Unit {
        gram,
        ml,
        piece
    }

    public static string ToString(Unit unit) {
        switch (unit) {
            case Unit.gram:  return "g";
            case Unit.ml:    return "ml";
            case Unit.piece: return "개";
            default:         return "";
        }
    }

    public struct Food {
        public string name;
        public float amount;
        public Unit unit;
        public float price;
		public string url;
        public Food(string name, float amount, Unit unit, float price) {
            this.name = name;
            this.amount = amount;
            this.unit = unit;
            this.price = price;
			this.url = "https://www.coupang.com/np/search?component=&q=" + name;
        }
    }

    public readonly static List<Food> food = new List<Food>{
        new Food("김치", 100.0f, Unit.gram,   630.0f),
        new Food("대파",  10.0f, Unit.piece, 2720.0f),
        new Food("두부",   1.0f, Unit.piece, 1750.0f),
        new Food("계란",  30.0f, Unit.piece, 6990.0f),
        new Food("소금", 100.0f, Unit.gram,   950.0f),

        new Food("된장", 100.0f, Unit.gram,  2000.0f),
        new Food("감자", 200.0f, Unit.gram,  1500.0f),
        new Food("양파", 150.0f, Unit.piece, 800.0f),
        new Food("호박", 200.0f, Unit.gram,  1800.0f),
        new Food("고추", 50.0f, Unit.gram,   500.0f),

        new Food("파스타면", 200.0f, Unit.gram,  3000.0f),
        new Food("크림소스", 150.0f, Unit.ml,    2500.0f),
        new Food("버섯", 100.0f, Unit.gram,      1500.0f),
        new Food("치즈", 50.0f, Unit.gram,       2000.0f),

        new Food("짜장소스", 200.0f, Unit.gram,  2500.0f),
        new Food("돼지고기", 150.0f, Unit.gram,  3000.0f),
        new Food("짜장면면", 200.0f, Unit.gram,  2000.0f),

        new Food("피자도우", 300.0f, Unit.gram,  5000.0f), 

        new Food("소고기", 200.0f, Unit.gram,  8000.0f),
        new Food("닭고기", 200.0f, Unit.gram,  5000.0f),
        new Food("생선", 200.0f, Unit.gram,  7000.0f),
        new Food("밥", 200.0f, Unit.gram,  1000.0f),
        new Food("간장", 50.0f, Unit.ml,  500.0f),
        new Food("오이", 100.0f, Unit.gram,  1500.0f),
        new Food("돼지 등심", 200.0f, Unit.gram,  5000.0f), 
    };

    public enum RecipeType {
        Korean,
        Chinese,
        Japanese,
        Western
    }

    public struct Foodset {
        public Food food;
        public float amount;
        public Foodset(string name, float amount) {
            this.food = Database.food.Find(x => x.name == name);
            this.amount = amount;
        }
    }

    public struct Recipe {
        public string name;
        public RecipeType type;
        public List<Foodset> foodset;
        public List<string> steps; // 추가된 부분
        public Recipe(string name, RecipeType type, List<Foodset> foodset, List<string> steps) { // 변경된 부분
            this.name = name;
            this.type = type;
            this.foodset = foodset;
            this.steps = steps; // 추가된 부분
        }
    }

    public readonly static List<Recipe> recipe = new List<Recipe>{
        new Recipe("김치찌개", RecipeType.Korean, new List<Foodset>{
            new Foodset("김치", 100.0f),
            new Foodset("대파",   1.0f),
            new Foodset("두부",   1.0f),
        },
        new List<string> { // 김치찌개 요리 과정
            "1. 김치를 적당한 크기로 자릅니다.",
            "2. 대파는 어슷썰기합니다.",
            "3. 두부는 먹기 좋은 크기로 자릅니다.",
            "4. 냄비에 물을 붓고 김치를 넣고 끓입니다.",
            "5. 김치가 어느 정도 익으면 대파를 넣고 끓입니다.",
            "6. 마지막으로 두부를 넣고 한 번 더 끓입니다.",
            "7. 모든 재료가 잘 익으면 김치찌개를 그릇에 담아냅니다."
        }),
        new Recipe("계란말이", RecipeType.Korean, new List<Foodset>{
            new Foodset("계란",   4.0f),
            new Foodset("대파",   1.0f),
            new Foodset("소금",   1.0f),
        },
        new List<string> {
            "1. 계란을 풀어 소금으로 간을 맞춥니다.",
            "2. 대파를 잘게 썰어 계란물에 섞습니다.",
            "3. 팬에 기름을 두르고 계란물을 얇게 부칩니다.",
            "4. 계란이 익기 시작하면 말아줍니다.",
            "5. 완성된 계란말이를 적당한 크기로 자릅니다."
        }),

        new Recipe("된장찌개", RecipeType.Korean, new List<Foodset>{
            new Foodset("된장", 50.0f),
            new Foodset("감자", 100.0f),
            new Foodset("양파", 0.5f),
            new Foodset("호박", 100.0f),
            new Foodset("고추", 10.0f),
        },
        new List<string> { // 된장찌개 요리 과정
            "1. 감자와 호박을 적당한 크기로 자릅니다.",
            "2. 양파는 얇게 슬라이스합니다.",
            "3. 고추는 얇게 썰어 준비합니다.",
            "4. 냄비에 물을 붓고 된장을 풀어줍니다.",
            "5. 된장이 풀린 물에 감자와 호박을 넣고 끓입니다.",
            "6. 감자가 익으면 양파와 고추를 넣고 다시 끓입니다.",
            "7. 모든 재료가 잘 익으면 된장찌개를 그릇에 담아냅니다."
        }),

        new Recipe("크림파스타", RecipeType.Western, new List<Foodset>{
            new Foodset("파스타면", 200.0f),
            new Foodset("크림소스", 150.0f),
            new Foodset("버섯", 50.0f),
            new Foodset("치즈", 30.0f),
        },
        new List<string> {
            "1. 파스타면을 끓는 물에 삶아줍니다.",
            "2. 팬에 크림소스를 붓고 데웁니다.",
            "3. 버섯을 썰어 팬에 넣고 익힙니다.",
            "4. 삶은 파스타면을 팬에 넣고 소스와 섞어줍니다.",
            "5. 치즈를 넣고 잘 섞어줍니다.",
            "6. 완성된 크림파스타를 접시에 담아냅니다."
        }),

        new Recipe("짜장면", RecipeType.Chinese, new List<Foodset>{
            new Foodset("짜장소스", 200.0f),
            new Foodset("돼지고기", 100.0f),
            new Foodset("양파", 1.0f),
            new Foodset("짜장면", 200.0f),
        },
        new List<string> {
            "1. 돼지고기를 적당한 크기로 자릅니다.",
            "2. 양파를 썰어줍니다.",
            "3. 팬에 기름을 두르고 돼지고기와 양파를 볶습니다.",
            "4. 짜장소스를 팬에 붓고 함께 끓입니다.",
            "5. 짜장면을 끓는 물에 삶아줍니다.",
            "6. 삶은 짜장면을 접시에 담고 소스를 부어줍니다."
        }),

        new Recipe("불고기", RecipeType.Korean, new List<Foodset>{
            new Foodset("소고기", 200.0f),
            new Foodset("양파", 1.0f),
            new Foodset("간장", 20.0f),
        },
        new List<string> {
            "1. 소고기를 얇게 썰어줍니다.",
            "2. 양파를 썰어줍니다.",
            "3. 팬에 소고기와 양파를 넣고 볶습니다.",
            "4. 간장을 넣고 잘 섞어줍니다.",
            "5. 소고기가 익으면 불고기를 접시에 담아냅니다."
        }),

        new Recipe("삼계탕", RecipeType.Korean, new List<Foodset>{
            new Foodset("닭고기", 300.0f),
            new Foodset("대파", 1.0f),
            new Foodset("소금", 5.0f),
        },
        new List<string> {
            "1. 닭고기를 깨끗이 씻습니다.",
            "2. 냄비에 물을 붓고 닭고기를 넣고 끓입니다.",
            "3. 대파를 썰어 냄비에 넣습니다.",
            "4. 소금으로 간을 맞춥니다.",
            "5. 닭고기가 익으면 삼계탕을 그릇에 담아냅니다."
        }),

        new Recipe("비빔밥", RecipeType.Korean, new List<Foodset>{
            new Foodset("밥", 200.0f),
            new Foodset("김치", 50.0f),
            new Foodset("계란", 1.0f),
        },
        new List<string> {
            "1. 밥을 그릇에 담습니다.",
            "2. 김치를 적당한 크기로 자릅니다.",
            "3. 계란을 프라이팬에 부쳐줍니다.",
            "4. 밥 위에 김치와 계란을 올립니다.",
            "5. 고추장이나 다른 양념을 넣고 비벼줍니다."
        }),

        new Recipe("탕수육", RecipeType.Chinese, new List<Foodset>{
            new Foodset("돼지고기", 200.0f),
            new Foodset("양파", 1.0f),
            new Foodset("간장", 30.0f),
        },
        new List<string> {
            "1. 돼지고기를 적당한 크기로 자릅니다.",
            "2. 양파를 썰어줍니다.",
            "3. 돼지고기에 전분을 묻혀줍니다.",
            "4. 팬에 기름을 두르고 돼지고기를 튀깁니다.",
            "5. 소스를 만들어 돼지고기와 양파를 넣고 볶습니다.",
            "6. 완성된 탕수육을 접시에 담아냅니다."
        }),

        new Recipe("짬뽕", RecipeType.Chinese, new List<Foodset>{
            new Foodset("돼지고기", 150.0f),
            new Foodset("고추", 20.0f),
            new Foodset("양파", 1.0f),
        },
        new List<string> {
            "1. 돼지고기를 적당한 크기로 자릅니다.",
            "2. 양파를 썰어줍니다.",
            "3. 고추를 썰어줍니다.",
            "4. 팬에 기름을 두르고 돼지고기와 양파, 고추를 볶습니다.",
            "5. 물을 넣고 끓입니다.",
            "6. 면을 삶아 짬뽕 국물에 넣습니다.",
            "7. 완성된 짬뽕을 그릇에 담아냅니다."
        }),

        new Recipe("마파두부", RecipeType.Chinese, new List<Foodset>{
            new Foodset("두부", 200.0f),
            new Foodset("돼지고기", 100.0f),
            new Foodset("양파", 1.0f),
        },
        new List<string> {
            "1. 두부를 적당한 크기로 자릅니다.",
            "2. 돼지고기를 적당한 크기로 자릅니다.",
            "3. 양파를 썰어줍니다.",
            "4. 팬에 기름을 두르고 돼지고기와 양파를 볶습니다.",
            "5. 두부를 넣고 함께 볶습니다.",
            "6. 소스를 넣고 잘 섞어줍니다.",
            "7. 완성된 마파두부를 접시에 담아냅니다."
        }),

        new Recipe("초밥", RecipeType.Japanese, new List<Foodset>{
            new Foodset("밥", 200.0f),
            new Foodset("생선", 100.0f),
            new Foodset("간장", 10.0f),
        },
        new List<string> {
            "1. 밥을 준비합니다.",
            "2. 생선을 얇게 썰어줍니다.",
            "3. 밥을 손으로 뭉쳐 생선을 올립니다.",
            "4. 간장을 곁들여서 제공합니다."
        }),

        new Recipe("라멘", RecipeType.Japanese, new List<Foodset>{
            new Foodset("돼지고기", 100.0f),
            new Foodset("파스타면", 200.0f),
            new Foodset("간장", 20.0f),
        },
        new List<string> {
            "1. 돼지고기를 적당한 크기로 자릅니다.",
            "2. 파스타면을 끓는 물에 삶아줍니다.",
            "3. 팬에 돼지고기를 볶습니다.",
            "4. 면을 국물에 넣고 돼지고기를 올립니다.",
            "5. 간장으로 간을 맞춥니다.",
            "6. 완성된 라멘을 그릇에 담아냅니다."
        }),

        new Recipe("돈까스", RecipeType.Japanese, new List<Foodset>{ 
            new Foodset("돼지 등심", 200.0f),
            new Foodset("소금", 5.0f),
            new Foodset("계란", 1.0f),
        },
        new List<string> {
            "1. 돼지 등심에 소금과 후추로 간을 합니다.",
            "2. 계란을 풀어 돼지 등심에 묻힙니다.",
            "3. 빵가루를 묻혀줍니다.",
            "4. 팬에 기름을 두르고 돼지 등심을 튀깁니다.",
            "5. 완성된 돈까스를 적당한 크기로 자릅니다."
        }),

        new Recipe("스테이크", RecipeType.Western, new List<Foodset>{
            new Foodset("소고기", 300.0f),
            new Foodset("소금", 5.0f),
            new Foodset("버섯", 50.0f),
        },
        new List<string> {
            "1. 소고기에 소금과 후추로 간을 합니다.",
            "2. 팬에 기름을 두르고 소고기를 구워줍니다.",
            "3. 버섯을 썰어 함께 구워줍니다.",
            "4. 완성된 스테이크를 접시에 담아냅니다."
        }),

        new Recipe("샐러드", RecipeType.Western, new List<Foodset>{
            new Foodset("오이", 50.0f),
            new Foodset("양파", 1.0f),
            new Foodset("소금", 5.0f),
        },
        new List<string> {
            "1. 오이를 얇게 썰어줍니다.",
            "2. 양파를 얇게 썰어줍니다.",
            "3. 모든 재료를 볼에 넣고 소금을 뿌려줍니다.",
            "4. 잘 섞어줍니다."
        }),

        new Recipe("피자", RecipeType.Western, new List<Foodset>{
            new Foodset("치즈", 100.0f),
            new Foodset("버섯", 50.0f),
            new Foodset("피자도우", 300.0f),
        },
        new List<string> {
            "1. 피자도우를 준비합니다.",
            "2. 치즈와 버섯을 올립니다.",
            "3. 오븐에 구워줍니다.",
            "4. 완성된 피자를 적당한 크기로 자릅니다."
        }),
    };

    public struct Menuset {
		public string name;
        public Recipe recipe;
        public float price;
        public string category;
        public Menuset(string name, float price, string category) {
			this.name = name;
            this.recipe = Database.recipe.Find(x => x.name == category);
			this.price = price;
            this.category = category;
        }
    }

    public struct Restaurant {
        public string name;
        public string url;
        public List<Menuset> menuset;
        public Restaurant(string name, List<Menuset> menuset) {
            this.name = name;
            this.url = "https://map.naver.com/p/search/" + name;
            this.menuset = menuset;
        }
    }

    public readonly static List<Restaurant> restaurant = new List<Restaurant>{
        new Restaurant("김치만선생 동대필동점", new List<Menuset>{
            new Menuset("김치찌개", 7000.0f, "김치찌개"),
            new Menuset("계란말이", 6000.0f, "계란말이"),
        }),

        new Restaurant("황토골", new List<Menuset>{
            new Menuset("김치찌개", 8000.0f, "김치찌개"),
            new Menuset("된장찌개", 8000.0f, "된장찌개"),
        }),

        new Restaurant("필동함박 충무로 본점", new List<Menuset>{
            new Menuset("까르보파스타", 11500.0f, "크림파스타"),
            new Menuset("투움바파스타", 11500.0f, "크림파스타"),
        }),
        new Restaurant("홍짜장 동국대점", new List<Menuset>{
            new Menuset("짜장면", 5500.0f, "짜장면"),
            new Menuset("짬뽕", 6500.0f, "짬뽕"),
        }),

        new Restaurant("평강삼계탕 장충점", new List<Menuset>{
            new Menuset("삼계탕", 17000.0f, "삼계탕"),
        }),
        new Restaurant("일미정", new List<Menuset>{
            new Menuset("불고기", 8000.0f, "불고기"),
            new Menuset("된장찌개", 9000.0f, "된장찌개"),
        }),
        new Restaurant("필동반점", new List<Menuset>{
            new Menuset("짬뽕", 7000.0f, "짬뽕"),
            new Menuset("짜장면", 6000.0f, "짜장면"),
        }),
        new Restaurant("스시노칸도 충무로역점", new List<Menuset>{
            new Menuset("초밥", 22000.0f, "초밥"),
        }),
        new Restaurant("스담", new List<Menuset>{
            new Menuset("초밥", 18000.0f, "초밥"),
        }),
		new Restaurant("낙원의소바", new List<Menuset>{
            new Menuset("돈까스", 15000.0f, "돈까스"),
            new Menuset("로스카츠", 13000.0f, "돈까스"),
        }),
        new Restaurant("서울카츠 충무로본점", new List<Menuset>{
            new Menuset("등심 카츠", 14000.0f, "돈까스"),
            new Menuset("안심 카츠", 15000.0f, "돈까스"),
        }),
        new Restaurant("모리짱", new List<Menuset>{
            new Menuset("돈코츠라멘", 8000.0f, "라멘"),
            new Menuset("소유라멘", 7000.0f, "라멘"),
        }),
        new Restaurant("도치피자 장충점", new List<Menuset>{
            new Menuset("디아볼라 피자", 24000.0f, "피자"),
            new Menuset("고르곤졸라 피자",22000.0f, "피자"),
        }),
        new Restaurant("미스터피자 충무로점", new List<Menuset>{
            new Menuset("포테이토골드 피자", 31500.0f, "피자"),
            new Menuset("페퍼로니 피자",20500.0f, "피자"),
            new Menuset("콤비네이션 피자",21500.0f, "피자"),
        }),
    };
}